using CriaderosDePollos.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CriaderosDePollos.Application.Dtos.Trabajador
{
    public class TrabajadorResponseDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public RolEmpleado Rol { get; set; }
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
    }
}
