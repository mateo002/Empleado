using AutoMapper;
using PruebaTecnicaRenting.Application.Empleados.Shared;
using PruebaTecnicaRenting.Domain.Entities;

namespace PruebaTecnicaRenting.Application.Empleados
{
    public class EmpleadoProfile : Profile
    {
        public EmpleadoProfile()
        {
            CreateMap<Empleado, EmpleadoDto>();
        }
    }
}
