using System;
using System.Collections.Generic;

#nullable disable

namespace ApiHelpDents.Domain.Entities
{
    public partial class Turno
    {
        public Turno()
        {
            AsesorHasTurnos = new HashSet<AsesorHasTurno>();
        }

        public int IdTurno { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<AsesorHasTurno> AsesorHasTurnos { get; set; }
    }
}
