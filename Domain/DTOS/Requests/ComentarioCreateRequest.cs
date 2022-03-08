using System;

namespace ApiHelpDents.Domain.Dtos.Requests
{
    public class ComentarioCreateRequest
    {
        public int ClaveUsuario{get; set;}
        public int ClaveAsesor {get; set;}
        public string Descripcion {get; set;}
    }
}