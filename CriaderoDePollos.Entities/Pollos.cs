using CriaderoDePollos.Entities;
using CriaderosDePollos.Abstactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CriaderosDePollos.Entities
{
    public class Pollos : IEntidad
    {
        public Pollos()
        {
            Conteodepollos = new HashSet<Conteodepollos>();
        }

        public int Id { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; }
        public TipoDePollo TipoPollo { get; set; }
        public TiposDeAlimento TipoAlimento { get; set; }

        public virtual ICollection<Conteodepollos> Conteodepollos { get; set; }
    }
}
