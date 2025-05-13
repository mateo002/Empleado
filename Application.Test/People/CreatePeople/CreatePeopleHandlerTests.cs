using AutoMapper;
using NSubstitute;
using PruebaTecnicaRenting.Application.People.CreatePeople;
using PruebaTecnicaRenting.Application.People.Shared;
using PruebaTecnicaRenting.Domain.Entities;
using PruebaTecnicaRenting.Domain.Repositories;

namespace Application.Test.People.CreatePeople
{
    public class CreatePeopleHandlerTests
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Person> _repository;
        private readonly IMapper _mapper;
        private readonly CreatePeopleHandler _handler;

        public CreatePeopleHandlerTests()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _repository = Substitute.For<IRepository<Person>>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CreatePeopleHandler(_unitOfWork, _repository, _mapper);
        }

        [Fact]
        public async Task Handle_CreatesNewPerson()
        {
            // Arrange
            var now = DateTime.Now;
            var command = new CreatePeopleCommand
            {
                new CreatePeopleCommand.Person("John", "Doe", "", now),
                new CreatePeopleCommand.Person("Jane", "Doe", "", now),
            };

            _mapper.Map<Person>(Arg.Any<PersonDto>()).Returns(new Person());

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            await _repository.Received(command.Count).AddAsync(Arg.Any<Person>());
            await _unitOfWork.Received(1).CommitAsync();
        }

        [Fact]
        public async Task Handle_BeginAsyncCalledOnce()
        {
            // Arrange
            var command = new CreatePeopleCommand();

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            await _unitOfWork.Received(1).BeginAsync(_repository);
        }
    }
}
