using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaRenting.Application.Empleados.GetEmpleado;
using PruebaTecnicaRenting.Application.Empleados.Shared;

namespace PruebaTecnicaRenting.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoContoller : Controller
    {
        private readonly IMediator _mediator;

        public EmpleadoContoller(IMediator mediator) => _mediator = mediator;

        /// <summary>Obtener una persona por Id</summary>
        /// <param name="id">Id del regisro a buscar</param>
        /// <returns>Retorna el registro de la persona soliciada</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EmpleadoDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<EmpleadoDto>> GetAsyn() => await _mediator.Send(new GetEmpleadoQuery());
    }
}
