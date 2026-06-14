using System;
using System.Collections.Generic;
using System.Text;

namespace CriaderosDePollos.Application.Dtos.Pollos
{
    public class PollosRequestDto
    {
        public string Nombre { get; set; }
        public string tipoPollo { get; set; }
        public string tipoAlimento { get; set; }
    }
}
