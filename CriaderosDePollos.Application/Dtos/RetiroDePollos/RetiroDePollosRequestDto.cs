using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CriaderosDePollos.Application.Dtos.RetiroDePollos
{
        public class RetiroDePollosRequestDto
        {
            public int ControlDePesoId { get; set; }
            [DataType(DataType.Date)]
             public DateTime fechaRetiro { get; set; } 
            public int CantidadRetirada { get; set; } 
            public decimal PesoTotalKG { get; set; } 
            public string Destino { get; set; } 
            public int mortalidadCarga { get; set; } 
        }
    
}
