using System;
using System.Collections.Generic;

#nullable disable

namespace ApiHelpDents.Domain.Entities
{
    public partial class Asesor
    {
        public Asesor()
        {
            AsesorHasComentarios = new HashSet<AsesorHasComentario>();
            AsesorHasEspecialidads = new HashSet<AsesorHasEspecialidad>();
            AsesorHasTurnos = new HashSet<AsesorHasTurno>();
        }

        public int IdAsesor { get; set; }
        public int UsuarioIdUsuario { get; set; }
        public double Costo { get; set; }
        public string Telefono { get; set; }
        public string Descripcion { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Linkendin { get; set; }
        public string YouTube { get; set; }

        public virtual Usuario UsuarioIdUsuarioNavigation { get; set; }
        public virtual ICollection<AsesorHasComentario> AsesorHasComentarios { get; set; }
        public virtual ICollection<AsesorHasEspecialidad> AsesorHasEspecialidads { get; set; }
        public virtual ICollection<AsesorHasTurno> AsesorHasTurnos { get; set; }
    }
}
