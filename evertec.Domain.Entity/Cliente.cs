using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evertec.Domain.Entity
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public DateTime Fecha_Nacimiento { get; set; }
        public byte Foto { get; set; }
        public bool Estado_Civil { get; set; }
        public bool Tiene_Hermanos { get; set; }
    }
}
