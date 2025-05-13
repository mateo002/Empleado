using System.ComponentModel.DataAnnotations;
using MediatR;

namespace PruebaTecnicaRenting.Application.People.CreatePerson
{
    public record CreatePersonCommand(
        [Required] string FirstName,
        [Required] string LastName,
        [Required] string Email,
        [Required] DateTime? DateOfBirth
    ) : IRequest;
}
