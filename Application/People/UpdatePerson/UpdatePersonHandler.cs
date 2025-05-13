using MediatR;
using PruebaTecnicaRenting.Domain.Entities;
using PruebaTecnicaRenting.Domain.Repositories;

namespace PruebaTecnicaRenting.Application.People.UpdatePerson
{
    internal sealed class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand>
    {
        private readonly IRepository<Person> _repository;

        public UpdatePersonHandler(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));

            var person = await _repository.FindAsync(request.Id);

            if (person == null)
                throw new ArgumentNullException($"No se encontró ningún registro con el id {request.Id}");

            person.FirstName = request.FirstName;
            person.LastName = request.LastName;
            person.Email = request.Email;
            person.DateOfBirth = request.DateOfBirth;

            await _repository.UpdateAsync(person);
        }
    }
}
