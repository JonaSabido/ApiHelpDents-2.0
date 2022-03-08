using System;

namespace ApiHelpDents.Domain.Dtos.Requests
{
    public class AsesorUpdateRequest
    {
        public int ClaveEsp {get; set;}
        public int ClaveTurno {get; set;}
        public double Costo {get; set;}
        public string Telefono {get; set;}
        public string Facebook {get; set;}
        public string Instagram{get; set;}
        public string Youtube {get; set;}
        public string Linkendin {get; set;}
        public string Descripcion {get; set;}
    }
}