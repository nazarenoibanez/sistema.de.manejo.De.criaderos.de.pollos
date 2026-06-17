using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CriaderosDePollos.Application.Dtos.MantenimientoYEmergencias
{
    public class MantenimientoYEmergenciasRequestDto
    {
        public int GalponesID { get; set; }

        public string Descripcion { get; set; }

        public decimal Costo { get; set; }

        public DateTime fechaRepote { get; set; }

        public DateTime? fechaResolucion { get; set; }
        public string estado { get; set; }
    }
}
