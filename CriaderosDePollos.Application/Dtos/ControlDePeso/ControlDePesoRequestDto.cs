using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CriaderosDePollos.Application.Dtos.ControlDePeso
{
    public class ControlDePesoRequestDto
    {
        public int controlID { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaPasaje { get; set; }

        public int EdadDias { get; set; }

        public decimal PesoPromedioGr { get; set; }
    }
}
