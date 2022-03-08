using System;
using System.Collections.Generic;

#nullable disable

namespace ApiHelpDents.Domain.Entities
{
    public partial class AsesorHasComentario
    {
        public int Id { get; set; }
        public int AsesorIdAsesor { get; set; }
        public int ComentarioIdComentario { get; set; }

        public virtual Asesor AsesorIdAsesorNavigation { get; set; }
        public virtual Comentario ComentarioIdComentarioNavigation { get; set; }
    }
}
