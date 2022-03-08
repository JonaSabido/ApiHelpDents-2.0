using System;
using System.Collections.Generic;

#nullable disable

namespace ApiHelpDents.Domain.Entities
{
    public partial class AsesorHasTurno
    {
        public int Id { get; set; }
        public int AsesorIdAsesor { get; set; }
        public int TurnoIdTurno { get; set; }

        public virtual Asesor AsesorIdAsesorNavigation { get; set; }
        public virtual Turno TurnoIdTurnoNavigation { get; set; }
    }
}
