using System;

namespace ApiHelpDents.Domain.Dtos.Requests
{
    public class AsesorFilterRequest
    {
        public string Nombres{get; set;}
        public string Especialidad{get; set;}
        public string Turno{get; set;}
        public double? Costo {get; set;}

    }
}