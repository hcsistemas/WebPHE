using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPHE.Models.ViewModels
{
    public class UsuariosViewModel
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNac { get; set; }
        public string LugarNac { get; set; }
        public string LugarRes { get; set; }
        public int IdGenero { get; set; }
        public string Genero { get; set; }
        public string Hoobies { get; set; }
    }
}