using System.ComponentModel.DataAnnotations;
using PruebaTecnicaRenting.Domain.Entities.Base;

namespace PruebaTecnicaRenting.Domain.Entities
{
    public class Person : BaseEntity<int>
    {
        public const int MinimalAge = 18;

        [MaxLength(20)]
        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string Email { get; set; } = default!;

        public DateTime DateOfBirth { get; set; }

        public Person(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
        }
        public Person()
        {

        }

        public bool IsUnderAge => DateTime.Now.Year - DateOfBirth.Year + (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear ? -1 : 0) < MinimalAge;
    }
}
