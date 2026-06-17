using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CriaderosDePollos.Application.Dtos.ConteoDePollos
{
    public class ConteodepollosRequestDto
    {
        public int GalponesID { get; set; }

        public int PollosID { get; set; }

        public int CantidadPollos { get; set; }
    }
}
