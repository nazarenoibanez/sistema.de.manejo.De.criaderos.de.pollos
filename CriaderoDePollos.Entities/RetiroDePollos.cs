using CriaderosDePollos.Abstactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CriaderosDePollos.Entities
{
    public class RetiroDePollos : IEntidad
    {
        public int Id { get; set; } 

        [ForeignKey(nameof(ControlDePesoId))]
        public int ControlDePesoId { get; set; } 

        public virtual ControlDePeso control { get; set; } 
        public DateTime fechaRetiro { get; set; } 
        public int CantidadRetirada { get; set; } 
        public decimal PesoTotalKG { get; set; }
        public string Destino { get; set; }
        public int mortalidadCarga { get; set; }
    }
}
