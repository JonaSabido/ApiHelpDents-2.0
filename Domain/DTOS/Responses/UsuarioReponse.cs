using System;

namespace ApiHelpDents.Domain.Dtos.Requests
{
    public class UsuarioResponse
    {
        public int Id { get; set; }
        public string Nombres {get; set;}
        public string Apellidos{get; set;}
        public string Correo {get; set;}
        public string Contraseña{get; set;}
        public int RolIdRol{get; set;}
    }
}