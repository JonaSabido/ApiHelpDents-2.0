using System;

namespace ApiHelpDents.Domain.Dtos.Requests
{
    public class AsesorTurnoCreateRequest
    {
        public int Asesor_idAsesor {get; set;}
        public int Turno_idTurno{get; set;}
    }
}