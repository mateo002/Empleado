using PruebaTecnicaRenting.Domain.Entities.Base;

namespace PruebaTecnicaRenting.Domain.Entities
{
    public class Departamento: BaseEntity<int>
    {
        public string Descripcion { get; set; }
    }
}
