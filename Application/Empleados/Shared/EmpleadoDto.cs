namespace PruebaTecnicaRenting.Application.Empleados.Shared
{
    public class EmpleadoDto
    {
        public int Id { get; set; }
        public string EmpleadoName { get; set; }
        public int Documento { get; set; }
        public int CiudadId { get; set; }
        public int DepartamentoId { get; set; }

    }
}
