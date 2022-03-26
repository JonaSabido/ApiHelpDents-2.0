namespace ApiHelpDents.Domain.Dtos.Requests{

    public class SolicitudCreateRequest{

        public int UsuarioIdUsuario { get; set; }
        public string Especialidad1 { get; set; }
        public string Especialidad2 { get; set; }
        public string Especialidad3 { get; set; }
        public string Turno1 { get; set; }
        public string Turno2 { get; set; }
        public string Turno3 { get; set; }
        public double Costo { get; set; }
        public string Telefono { get; set; }
        public string Descripcion { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Linkendin { get; set; }
        public string YouTube { get; set; }
        public string Tipo { get; set; }
        
    }
}