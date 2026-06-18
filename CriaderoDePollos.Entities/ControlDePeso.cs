using CriaderoDePollos.Entities;
using CriaderosDePollos.Abstactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CriaderosDePollos.Entities
{
    public class ControlDePeso : IEntidad
    {
        public int Id { get; set; }

        public int ConteodepollosId { get; set; }
        [ForeignKey(nameof(ConteodepollosId))]

        public virtual Conteodepollos Conteodepollos { get; set; }
        public DateTime FechaPasaje { get; set; }
        public int EdadDias { get; set; }
        public decimal PesoPromedioGr { get; set; }
    }
}
