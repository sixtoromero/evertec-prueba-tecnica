using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evertec.Application.DTO
{
    public class UsuariosDTO
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string? Usuario { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public string? Token { get; set; }

    }
}
