using AutoMapper;
using MediatR;
using PruebaTecnicaRenting.Application.People.Shared;
using PruebaTecnicaRenting.Domain.Entities;
using PruebaTecnicaRenting.Domain.Repositories;

namespace PruebaTecnicaRenting.Application.People.GetPaginatedPeople
{
    public class GetPaginatedPeopleHandler : IRequestHandler<GetPaginatedPeopleQuery, IPaginatedResult<PersonDto>>
    {
        private readonly IRepository<Person> _repository;
        private readonly IMapper _mapper;

        public GetPaginatedPeopleHandler(IRepository<Person> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IPaginatedResult<PersonDto>> Handle(GetPaginatedPeopleQuery request, CancellationToken cancellationToken)
        {
            var paginatedPeople = await _repository.GetPaginatedAsync(request.PageIndex, request.PageSize);

            return paginatedPeople.CreateFrom(_mapper.Map<IEnumerable<PersonDto>>(paginatedPeople.Items));
        }
    }
}
