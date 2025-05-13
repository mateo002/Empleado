using AutoMapper;
using PruebaTecnicaRenting.Application.People.CreatePeople;
using PruebaTecnicaRenting.Application.People.CreatePerson;
using PruebaTecnicaRenting.Application.People.Shared;
using PruebaTecnicaRenting.Domain.Entities;

namespace PruebaTecnicaRenting.Application.People
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<CreatePersonCommand, Person>();
            CreateMap<CreatePeopleCommand.Person, CreatePersonCommand>();
            CreateMap<Person, PersonDto>();
        }
    }
}
