namespace PruebaTecnicaRenting.Application.People.Shared
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string Email { get; set; } = default!;

        public DateTime DateOfBirth { get; set; }
    }
}
