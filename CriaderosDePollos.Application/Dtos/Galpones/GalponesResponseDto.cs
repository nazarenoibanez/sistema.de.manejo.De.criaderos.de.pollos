using System;
using System.Collections.Generic;
using System.Text;

namespace CriaderosDePollos.Application.Dtos.Galpones
{
    public class GalponesResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tamaño { get; set; }
        public int CantidadAlmacenado { get; set; }
    }
}
