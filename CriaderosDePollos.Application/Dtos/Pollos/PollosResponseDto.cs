using System;
using System.Collections.Generic;
using System.Text;

namespace CriaderosDePollos.Application.Dtos.Pollos
{
    public class PollosResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string tipoPollo { get; set; }
        public string tipoAlimento { get; set; }
    }
}
