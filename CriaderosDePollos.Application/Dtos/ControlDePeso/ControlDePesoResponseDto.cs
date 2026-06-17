using System;
using System.Collections.Generic;
using System.Text;

namespace CriaderosDePollos.Application.Dtos.ControlDePeso
{
    public class ControlDePesoResponseDto
    {
        public int Id { get; set; }
        public int controlID { get; set; }
        public DateTime FechaPasaje { get; set; }
        public int EdadDias { get; set; }
        public decimal PesoPromedioGr { get; set; }

        public int CantidadPollosEnConteo { get; set; }
        public string NombreDelPollo { get; set; }
        public string NombreDelGalpon { get; set; }
    }
}
