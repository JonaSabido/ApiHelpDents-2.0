using System;

namespace ApiHelpDents.Domain.Dtos.Requests
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string Correo {get; set;}
        public int RolIdRol{get; set;}
        public string Token{get; set;}
    }
}