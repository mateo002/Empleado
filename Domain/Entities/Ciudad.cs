using PruebaTecnicaRenting.Domain.Entities.Base;

namespace PruebaTecnicaRenting.Domain.Entities
{
    public class Ciudad : BaseEntity<int>
    {
        public string Descripcion { get; set; }
    }
}
