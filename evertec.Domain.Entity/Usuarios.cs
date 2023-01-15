namespace evertec.Domain.Entity
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        //public string Usuario { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;


    }
}
