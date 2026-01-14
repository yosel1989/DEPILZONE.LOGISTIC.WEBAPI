using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class ArticuloDTO
    {
        // Primary
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Codigo { get; set; }
        public int? IdUnidadMedida { get; set; }
        public int? IdCategoria { get; set; }
        public int Stock { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int IdEstado { get; set; }
        public DateTime? FechaCaducidad { get; set; }
        public string? Lote { get; set; }

        public List<ProveedorDTO> Proveedores { get; set; }

        // Secondary
        public int NumeroProveedores { get; set; }
        public string UsuarioRegistro { get; set; }
        public string UsuarioModifico { get; set; }
        public string UnidadMedida { get; set; }
        public string Categoria { set; get; }
        public string Estado { get; set; }

    }

    public class UnidadMedidaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? NombreCorto { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int IdEstado { get; set; }

        // secondary
        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
        public string Estado { get; set; }
    }

    public class ArticuloCategoriaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int IdEstado { get; set; }

        // secondary
        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
        public string Estado { get; set; }
    }


    public class ArticuloStockDTO
    {
        public int Id { get; set; }
        public int IdArticulo { get; set; }
        public int IdSede { get; set; }
        public int IdAlmacen { get; set; }
        public int? IdAlmacenUbicacion { get; set; }
        public int? IdTransaccion { get; set; }
        public int Stock { get; set; }
        public int StockInicial { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int IdEstado { get; set; }

        // secondary
        public string Articulo { get; set; }
        public string Sede { get; set; }
        public string Almacen { get; set; }
        public string? AlmacenUbicacion { get; set; }
        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
        public string Estado { get; set; }
    }


    public class ArticuloStockTrackingHistory
    {
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public int IdTransaccion { get; set; }
        public bool Confirmado { get; set; }

        public int IdClaseTransaccion { get; set; }
        public string TipoTransaccion { get; set; }
        public string Articulo { get; set; }
        public string Sede { get; set; }
        public string MotivoTransaccion { get; set; }
    }

}
