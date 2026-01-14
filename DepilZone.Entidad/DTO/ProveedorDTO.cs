using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class ProveedorDTO
    {
        // Primary
        public int Id { get; set; }
        public string? Ruc { get; set; }
        public string? RazonSocial { get; set; }
        public string? ContactoNombre { get; set; }
        public string? ContactoApellido { get; set; }
        public string? ContactoTelefono { get; set; }
        public string? ContactoCorreo { get; set; }
        public string? IdUbicacion { get; set; }
        public string? Direccion { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public int IdEstado { get; set; }


        // secondary
        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public string Estado { get; set; }
        public string? Ubigeo { get; set; }
        public string? Ciudad { get; set; }
        public string? Distrito { get; set; }

    }


}
