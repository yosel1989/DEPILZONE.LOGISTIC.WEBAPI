using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{

    public class OrdenCompraDTO
    {
        public int Id { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int IdEstado { get; set; }
        public List<OrdenCompraDetalleDTO> Detalle { get; set; }

        // secondary
        public int Items { get; set; }
        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
        public string Estado { get; set; }
    }


    public class OrdenCompraDetalleDTO
    {
        public int Id { get; set; }
        public int IdOrdenCompra { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public int? IdProveedor { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }

        // secondary

        public string Articulo { get; set; }
        public string UnidadMedida { get; set; }
        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
    }

}
