using System;

namespace ApiHelpDents.Domain.Dtos.Requests
{
    public class UsuarioUpdateRequest
    {
        public string Nombres {get; set;}
        public string Apellidos{get; set;}
        public string Contraseña{get; set;}
    }
}