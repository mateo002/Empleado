using System.ComponentModel.DataAnnotations;
using MediatR;
using PruebaTecnicaRenting.Application.People.Shared;

namespace PruebaTecnicaRenting.Application.People.FindPerson
{
    public record FindPersonQuery([Required] int Id) : IRequest<PersonDto>;
}
