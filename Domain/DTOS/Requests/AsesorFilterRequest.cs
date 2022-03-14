using System;

namespace ApiHelpDents.Domain.Dtos.Requests
{
    public class AsesorFilterRequest
    {
        public int? idEspecialidad{get; set;}
        public int? idTurno{get;set;}
        public double? Costo{get; set;}
        

    }
}