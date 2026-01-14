using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class CredencialesDTO
    {
        // Primary
        public string Usuario { get; set; }
        public string Clave { get; set; }

    }

    public class CambioClaveDTO
    {
        public int idUsuario { get; set; }
        public string actualClave { get; set; }
        public string nuevaClave { get; set; }
    }

}
