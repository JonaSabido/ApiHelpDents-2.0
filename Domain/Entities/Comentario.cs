using System;
using System.Collections.Generic;

#nullable disable

namespace ApiHelpDents.Domain.Entities
{
    public partial class Comentario
    {
        public Comentario()
        {
            AsesorHasComentarios = new HashSet<AsesorHasComentario>();
        }

        public int IdComentario { get; set; }
        public int UsuarioIdUsuario { get; set; }
        public string Descripcion { get; set; }

        public virtual Usuario UsuarioIdUsuarioNavigation { get; set; }
        public virtual ICollection<AsesorHasComentario> AsesorHasComentarios { get; set; }
    }
}
