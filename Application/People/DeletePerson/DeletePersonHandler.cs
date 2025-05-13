using MediatR;
using PruebaTecnicaRenting.Domain.Entities;
using PruebaTecnicaRenting.Domain.Repositories;

namespace PruebaTecnicaRenting.Application.People.DeletePerson
{
    internal sealed class DeletePersonHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IRepository<Person> _repository;

        public DeletePersonHandler(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));

            var person = await _repository.FindAsync(request.Id);

            if (person == null)
                throw new ArgumentNullException($"No se encontró ningún registro con el id {request.Id}");

            await _repository.RemoveAsync(person);
        }
    }
}
