using AutoMapper;
using MediatR;
using PruebaTecnicaRenting.Application.Empleados.Shared;
using PruebaTecnicaRenting.Domain.Entities;
using PruebaTecnicaRenting.Domain.Repositories;

namespace PruebaTecnicaRenting.Application.Empleados.GetEmpleado
{
    public class GetEmpleadoHandler:  IRequestHandler<GetEmpleadoQuery, IEnumerable<EmpleadoDto>>
    {
        private readonly IRepository<Empleado> _repository;
        private readonly IMapper _mapper;

        public GetEmpleadoHandler(IRepository<Empleado> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmpleadoDto>> Handle(GetEmpleadoQuery request, CancellationToken cancellationToken)
        {
            var empleado = await _repository.GetAsync();

            return _mapper.Map<IEnumerable<EmpleadoDto>>(empleado);
        }

    }
}
