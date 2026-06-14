using CriaderosDePollos.Abstactions;
using System.ComponentModel.DataAnnotations.Schema;

namespace CriaderoDePollos.Entities
{
    public class Conteodepollos : IEntidad
    {
        public int Id { get; set; }
        [ForeignKey(nameof(GalponesID))]
        public int GalponesID { get; set; }

        public virtual Galpones Galpones { get; set; }
        [ForeignKey(nameof(PollosID))]
        public int PollosID { get; set; }

        public virtual Pollos Pollos { get; set; }
        public int CantidadPollos { get; set; }
    }
}
