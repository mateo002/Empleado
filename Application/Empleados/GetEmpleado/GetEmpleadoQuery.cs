using MediatR;
using PruebaTecnicaRenting.Application.Empleados.Shared;

namespace PruebaTecnicaRenting.Application.Empleados.GetEmpleado
{
    public record GetEmpleadoQuery() : IRequest<IEnumerable<EmpleadoDto>>;
}
