using System;

namespace ApiHelpDents.Domain.Dtos.Requests
{
    public class AdminResponse
    {
        public int Id {get; set;}
        public string Nombres{get; set;}
        public string Apellidos {get; set;}
        public string Correo {get; set;}
        public string Contraseña {get; set;}
    }
}