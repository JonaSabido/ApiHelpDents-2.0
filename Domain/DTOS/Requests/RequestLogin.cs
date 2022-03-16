using System;

namespace ApiHelpDents.Domain.Dtos.Requests{

    public class RequestLogin{

        public string Correo{get; set;}
        public string Contraseña{get; set;}
    }
}