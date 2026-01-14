using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class UsuarioDTO
    {
        // Primary
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdPerfil { get; set; }
        public int IdSede { get; set; }
        public int IdGenero { get; set; }

        // secondary
        public string Perfil { get; set; }
        public string Sede { get; set; }
        public string Hash { get; set; }
    }
}
