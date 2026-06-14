using CriaderosDePollos.Abstactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CriaderosDePollos.Entities
{
    public class Galpones : IEntidad
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; }
        public string Tamaño { get; set; }
        public int CantidadAlmacenado { get; set; }

    }
}
