using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CriaderosDePollos.Application.Dtos.Galpones
{
    public class GalponesRequestDto
    {
        [StringLength(30)]
        public string Nombre { get; set; }
        public string Tamaño { get; set; }
        public int CantidadAlmacenado { get; set; }
    }
}
