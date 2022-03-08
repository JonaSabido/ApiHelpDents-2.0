using System;

namespace ApiHelpDents.Domain.Dtos.Requests
{
    public class UsuarioCreateRequest
    {
        public string Nombres {get; set;}
        public string Apellidos{get; set;}
        public string Correo {get; set;}
        public string Contraseña{get; set;}
    }
}