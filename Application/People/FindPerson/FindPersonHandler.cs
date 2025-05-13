using AutoMapper;
using MediatR;
using PruebaTecnicaRenting.Application.Exceptions;
using PruebaTecnicaRenting.Application.People.Shared;
using PruebaTecnicaRenting.Domain.Entities;
using PruebaTecnicaRenting.Domain.Repositories;

namespace PruebaTecnicaRenting.Application.People.FindPerson
{
    public class FindPersonHandler : IRequestHandler<FindPersonQuery, PersonDto>
    {
        private readonly IRepository<Person> _repository;
        private readonly IMapper _mapper;

        public FindPersonHandler(IRepository<Person> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PersonDto> Handle(FindPersonQuery request, CancellationToken cancellationToken)
        {
            var person = await _repository.FindAsync(request.Id) ?? throw new NotFoundException($"No se ha encontrado una persona con el Id: {request.Id}");

            return _mapper.Map<PersonDto>(person);
        }
    }
}
