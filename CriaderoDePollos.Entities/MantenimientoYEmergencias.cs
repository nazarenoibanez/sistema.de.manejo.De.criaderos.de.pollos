using CriaderosDePollos.Abstactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CriaderosDePollos.Entities
{
    public class MantenimientoYEmergencias : IEntidad
    {
        public int Id { get; set; }
        [ForeignKey(nameof(GalponesID))]
        public int GalponesID { get; set; }

        public virtual Galpones Galpones { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public DateTime fechaRepote { get; set; }
        public DateTime fechaResolucion { get; set; }
        public string estado { get; set; }
    }
}
