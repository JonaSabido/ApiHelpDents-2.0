using System;
using ApiHelpDents.Domain.Entities;

namespace ApiHelpDents.Domain.Dtos.Responses{

    public class AsesorResponse
    {
        public int Id {get; set;}
        public int UsuarioIdUsuario {get; set;}
        public string Nombres{get; set;}
        public string Apellidos{get; set;}
        public double Costo{get; set;}
        public string Telefono{get; set;}
        public string Facebook{get; set;}
        public string Instagram{get; set;}
        public string Youtube{get; set;}
        public string Linkendin{get; set;}
        public string Descripcion{get; set;}

    }

}