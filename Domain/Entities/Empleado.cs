using PruebaTecnicaRenting.Domain.Entities.Base;

namespace PruebaTecnicaRenting.Domain.Entities
{
    public class Empleado: BaseEntity<int>
    {
        public string EmpleadoName { get; set; }
        public int Documento { get; set; }
        public int CiudadId { get; set; }
        public int DepartamentoId { get; set; }

        public Empleado(string empleadoName, int documento, int ciudadId, int departamentoId) 
        {
            EmpleadoName = empleadoName;
            Documento = documento;
            CiudadId = ciudadId;
            DepartamentoId = departamentoId;
        }


    }
}
