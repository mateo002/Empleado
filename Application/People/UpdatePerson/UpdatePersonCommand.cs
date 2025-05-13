using System.ComponentModel.DataAnnotations;
using MediatR;

namespace PruebaTecnicaRenting.Application.People.UpdatePerson
{
    public record UpdatePersonCommand(
        [Required] int Id,
        [Required] string FirstName,
        [Required] string LastName,
        [Required] string Email,
        [Required] DateTime DateOfBirth
        ) : IRequest;
}
