using System;
using System.Collections.Generic;

#nullable disable

namespace ApiHelpDents.Domain.Entities
{
    public partial class Solicitud
    {
        public int IdSolicitud { get; set; }
        public int UsuarioIdUsuario { get; set; }
        public string Especialidad1 { get; set; }
        public string Especialidad2 { get; set; }
        public string Especialidad3 { get; set; }
        public string Turno1 { get; set; }
        public string Turno2 { get; set; }
        public string Turno3 { get; set; }
        public double Costo { get; set; }
        public string Telefono { get; set; }
        public string Descripcion { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Linkendin { get; set; }
        public string YouTube { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }

        public virtual Usuario UsuarioIdUsuarioNavigation { get; set; }
    }
}
