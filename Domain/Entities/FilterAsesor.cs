using System;
using System.Collections.Generic;

#nullable disable

namespace ApiHelpDents.Domain.Entities
{
    public partial class FilterAsesor
    {
        public int? idTurno { get; set; }
        public int? idEspecialidad { get; set; }
        public double? Costo { get; set; }

    }
}