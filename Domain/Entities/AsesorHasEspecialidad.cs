using System;
using System.Collections.Generic;

#nullable disable

namespace ApiHelpDents.Domain.Entities
{
    public partial class AsesorHasEspecialidad
    {
        public int Id { get; set; }
        public int AsesorIdAsesor { get; set; }
        public int EspecialidadIdEspecialidad { get; set; }

        public virtual Asesor AsesorIdAsesorNavigation { get; set; }
        public virtual Especialidad EspecialidadIdEspecialidadNavigation { get; set; }
    }
}
