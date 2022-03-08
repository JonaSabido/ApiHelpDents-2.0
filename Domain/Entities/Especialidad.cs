using System;
using System.Collections.Generic;

#nullable disable

namespace ApiHelpDents.Domain.Entities
{
    public partial class Especialidad
    {
        public Especialidad()
        {
            AsesorHasEspecialidads = new HashSet<AsesorHasEspecialidad>();
        }

        public int IdEspecialidad { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<AsesorHasEspecialidad> AsesorHasEspecialidads { get; set; }
    }
}
