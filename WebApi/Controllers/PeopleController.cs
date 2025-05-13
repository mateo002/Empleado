using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaRenting.Application.People.CreatePerson;
using PruebaTecnicaRenting.Application.People.DeletePerson;
using PruebaTecnicaRenting.Application.People.FindPerson;
using PruebaTecnicaRenting.Application.People.GetPaginatedPeople;
using PruebaTecnicaRenting.Application.People.Shared;
using PruebaTecnicaRenting.Application.People.UpdatePerson;
using PruebaTecnicaRenting.Domain.Repositories;

namespace PruebaTecnicaRenting.WebApi.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PeopleController(IMediator mediator) => _mediator = mediator;

        /// <summary>Obtener una persona por Id</summary>
        /// <param name="id">Id del regisro a buscar</param>
        /// <returns>Retorna el registro de la persona soliciada</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<PersonDto> FindAsync(int id) => await _mediator.Send(new FindPersonQuery(id));

        /// <summary>Crea un nuevo registro de persona</summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost("CreatePeople")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task CreateAsync(CreatePersonCommand person) => await _mediator.Send(person);

        /// <summary>Actualiza los datos de una persona</summary>
        /// <param name="person">Los datos de la persona a actualizar</param>
        /// <returns></returns>
        [HttpPut("EditPeople")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task UpdatePerson(UpdatePersonCommand person) => await _mediator.Send(person);

        /// <summary>Eliminar una persona por Id</summary>
        /// <param name="id">Id del regisro a eliminar</param>
        /// <returns></returns>
        [HttpDelete("DeletePeople")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task DeletePerson(int id) => await _mediator.Send(new DeletePersonCommand(id));

        /// <summary>Obtener una lista paginada de personas</summary>
        /// <param name="pageIndex">Página Actual</param>
        /// <param name="pageSize">Cantidad de registros por página</param>
        /// <returns>Retorna la informaciónd de personas paginada</returns>
        [HttpGet("GetPaginatedPeople")]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 200)]
        public async Task<IPaginatedResult<PersonDto>> GetPaginatedAsync(int pageIndex = 0, int pageSize = 10)
        {
            return await _mediator.Send(new GetPaginatedPeopleQuery(pageIndex, pageSize));
        }
    }
}
