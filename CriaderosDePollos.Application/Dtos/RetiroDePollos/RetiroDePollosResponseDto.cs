using System;
using System.Collections.Generic;
using System.Text;

namespace CriaderosDePollos.Application.Dtos.RetiroDePollos
{
    public class RetiroDePollosResponseDto
    {
        public int Id { get; set; }
        public int controlID { get; set; }
        public DateTime fechaRetiro { get; set; }
        public int CantidadRetirada { get; set; }
        public decimal PesoTotalKG { get; set; }
        public string Destino { get; set; }
        public int mortalidadCarga { get; set; }

        public decimal UltimoPesoPromedioRegistradoGr { get; set; }
        public int EdadDiasEnRetiro { get; set; }
    }
}
