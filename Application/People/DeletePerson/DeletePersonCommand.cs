using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaRenting.Application.People.DeletePerson
{
    public record DeletePersonCommand(
     [Required] int Id
     ) : IRequest;
}
