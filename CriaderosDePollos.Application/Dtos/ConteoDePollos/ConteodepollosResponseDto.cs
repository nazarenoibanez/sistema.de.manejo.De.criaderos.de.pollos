using System;
using System.Collections.Generic;
using System.Text;

namespace CriaderosDePollos.Application.Dtos.ConteoDePollos
{
    public class ConteodepollosResponseDto
    {
        public int Id { get; set; }
        public int GalponesID { get; set; }
        public int PollosID { get; set; }
        public int CantidadPollos { get; set; }

        public string NombreGalpon { get; set; }
        public string NombrePollo { get; set; }
    }
}
