using AutoMapper;
using NSubstitute;
using PruebaTecnicaRenting.Application.People.CreatePerson;
using PruebaTecnicaRenting.Domain.Entities;
using PruebaTecnicaRenting.Domain.Repositories;

namespace Application.Test.People.CreatePerson
{
    public class CreatePersonHandlerTests
    {
        private readonly IRepository<Person> _repository;
        private readonly IMapper _mapper;

        public CreatePersonHandlerTests()
        {
            _repository = Substitute.For<IRepository<Person>>();
            _mapper = Substitute.For<IMapper>();
        }

        [Fact]
        public async Task Handle_ValidRequest_AddsPersonToRepository()
        {
            // Arrange
            var handler = new CreatePersonHandler(_repository, _mapper);
            var dateOfBirth = DateTime.Now.AddYears(-30);
            var request = new CreatePersonCommand("John", "Doe", "johndoe@example.com", dateOfBirth);

            _mapper.Map<Person>(request).Returns(new Person { FirstName = "John", LastName = "Doe", Email = "johndoe@example.com", DateOfBirth = dateOfBirth });

            // Act
            await handler.Handle(request, CancellationToken.None);

            // Assert
            await _repository.Received(1).AddAsync(Arg.Is<Person>(p => p.FirstName == "John" && p.LastName == "Doe" && p.Email == "johndoe@example.com" && p.DateOfBirth == dateOfBirth));
        }

        [Fact]
        public void Handle_NullRequest_ThrowsArgumentNullException()
        {
            // Arrange
            var handler = new CreatePersonHandler(_repository, _mapper);
            CreatePersonCommand? request = null;

            // Act & Assert
            var exception = Assert.ThrowsAsync<ArgumentNullException>(() => handler.Handle(request, CancellationToken.None));
            Assert.Equal("Value cannot be null. (Parameter 'request')", exception.Result.Message);
        }
    }
}
