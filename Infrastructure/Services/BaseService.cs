using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Retry;
using Serilog;

namespace PruebaTecnicaRenting.Infrastructure.Services
{
    public class BaseService
    {
        private const int Exponent = 2;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly AsyncRetryPolicy _asyncRetryPolicy;

        public BaseService(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
            _asyncRetryPolicy = CreateAsyncRetryPolicy(); 
        }

        protected async Task<T> ExecuteAndRetryAsync<T>(Func<Task<T>> action, [CallerMemberName] string memberName = "")
        {
            try
            {
                var result = await _asyncRetryPolicy.ExecuteAndCaptureAsync(action);

                if (result.Outcome == OutcomeType.Successful)
                {
                    return result.Result;
                }

                throw result.FinalException;
            }
            catch (Exception exception)
            {
                _logger.Error(exception, "Se han completado todos los intentos para el método {MemberName} con el tipo {TypeName}", memberName, typeof(T).Name);

                throw;
            }
        }

        protected async Task ExecuteAndRetryAsync(Func<Task> action, [CallerMemberName] string memberName = "")
        {
            try
            {
                var result = await _asyncRetryPolicy.ExecuteAndCaptureAsync(action);

                if (result.Outcome == OutcomeType.Successful)
                {
                    return;
                }

                throw result.FinalException;
            }
            catch (Exception exception)
            {
                _logger.Error(exception, "Se han completado todos los intentos para el método {MemberName}", memberName);

                throw;
            }
        }

        private AsyncRetryPolicy CreateAsyncRetryPolicy()
        {
            return Policy.Handle<Exception>().
                WaitAndRetryAsync(_configuration.GetValue("RetryPolicy:RetryCount", 3),
                    retryCount => TimeSpan.FromSeconds(Math.Pow(Exponent, _configuration.GetValue("RetryPolicy:RetrySeconds", 3))),
                    onRetry: (exception, timeSpan) =>
                    {
                        _logger.Error(exception, "La ejecución ha fallado, siguiente reintento en {TimeSpan}", timeSpan);
                    });
        }
    }
}
