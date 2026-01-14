using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class AlmacenDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdSede { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int IdEstado { get; set; }

        // secondary
        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
        public string Estado { get; set; }
        public string Sede { get; set; }
    }


    public class AlmacenUbicacionDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdSede { get; set; }
        public int IdAlmacen { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int IdEstado { get; set; }

        // secondary
        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
        public string Estado { get; set; }
        public string Sede { get; set; }
        public string Almacen { get; set; }
    }

}
