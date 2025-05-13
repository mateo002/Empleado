using System.ComponentModel.DataAnnotations;
using MediatR;

namespace PruebaTecnicaRenting.Application.People.CreatePeople
{
    public class CreatePeopleCommand : List<CreatePeopleCommand.Person>, IRequest
    {
        public record Person(
            [Required] string FirstName,
            [Required] string LastName,
            [Required] string Email,
            [Required] DateTime? DateOfBirth);
    }
}
