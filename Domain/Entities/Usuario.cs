using System;
using System.Collections.Generic;

#nullable disable

namespace ApiHelpDents.Domain.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Asesors = new HashSet<Asesor>();
            Comentarios = new HashSet<Comentario>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public int RolIdRol { get; set; }

        public virtual Rol RolIdRolNavigation { get; set; }
        public virtual ICollection<Asesor> Asesors { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
