using AutoMapper;
using MediatR;
using PruebaTecnicaRenting.Domain.Entities;
using PruebaTecnicaRenting.Domain.Repositories;

namespace PruebaTecnicaRenting.Application.People.CreatePerson
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand>
    { 
        private readonly IRepository<Person> _repository;
        private readonly IMapper _mapper;

        public CreatePersonHandler(IRepository<Person> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreatePersonCommand? request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));

            var person = _mapper.Map<Person>(request);

            await _repository.AddAsync(person);
        }
    }
}
