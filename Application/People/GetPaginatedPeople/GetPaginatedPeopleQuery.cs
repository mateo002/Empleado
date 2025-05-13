using MediatR;
using PruebaTecnicaRenting.Application.People.Shared;
using PruebaTecnicaRenting.Domain.Repositories;

namespace PruebaTecnicaRenting.Application.People.GetPaginatedPeople
{
    public record GetPaginatedPeopleQuery(int PageIndex, int PageSize) : IRequest<IPaginatedResult<PersonDto>>;
}
