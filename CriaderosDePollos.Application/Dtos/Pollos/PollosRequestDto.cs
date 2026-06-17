using CriaderoDePollos.Enums;
using CriaderosDePollos.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CriaderosDePollos.Application.Dtos.Pollos
{
    public class PollosRequestDto
    {
        
            [Required]
            [StringLength(30)]
            public string Nombre { get; set; }

            public TipoDePollo TipoPollo { get; set; }
            public TiposDeAlimento TipoAlimento { get; set; }
        
    }
}
