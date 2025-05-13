using AutoMapper;
using MediatR;
using PruebaTecnicaRenting.Domain.Entities;
using PruebaTecnicaRenting.Domain.Repositories;

namespace PruebaTecnicaRenting.Application.People.CreatePeople
{
    public class CreatePeopleHandler : IRequestHandler<CreatePeopleCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Person> _repository;
        private readonly IMapper _mapper;

        public CreatePeopleHandler(IUnitOfWork unitOfWork, IRepository<Person> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreatePeopleCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginAsync(_repository);

            foreach (var person in request)
            {
                var newPerson = _mapper.Map<Person>(person);

                await _repository.AddAsync(newPerson);
            }

            await _unitOfWork.CommitAsync();
        }
    }
}
