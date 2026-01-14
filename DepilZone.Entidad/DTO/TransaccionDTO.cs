using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class TransaccionClaseDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string? Descripcion { get; set; }
        public int IdEstado { get; set; }

        // secondary
        public string Estado { get; set; }
    }

    public class TransaccionMotivoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Codigo { get; set; }
        public int IdTipoTransaccion { get; set; }
    }

    public class TransaccionEstadoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Codigo { get; set; }
    }

    public class TransaccionTipoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string? Descripcion { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public int IdEstado { get; set; }
        public string Codigo { get; set; }
        public int IdTransaccionClase { get; set; }

        // secondary
        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
        public string Estado { get; set; }
        public string Clase { get; set; }
        public string ClaseCorto { get; set; }
    }

    public class TransaccionDTO
    {
        public int Id { get; set; }
        public int? IdTransaccionPadre { get; set; }
        public int IdTipoTransaccion { get; set; }

        public int IdMotivoTransaccion { get; set; }
        public int? IdSedeOrigen { get; set; }
        public int? IdSedeDestino { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public DateTime? FechaConfirmo { get; set; }
        public int IdEstado { get; set; }
        public List<TransaccionDetalleDTO> Detalle { get; set; }

        // secondary

        public string TipoTransaccion { get; set; }
        public string TipoTransaccionCorto { get; set; }

        public string? SedeOrigen { get; set; }
        public string? SedeDestino { get; set; }
        public bool GenerarGuia { get; set; }
        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
        public string Estado { get; set; }

        public string ImagenCabeceraDocumento { get; set; }
        public string ImagenPieDocumento { get; set; }
    }


    public class TransaccionDetalleDTO
    {
        public int Id { get; set; }
        public int IdTransaccion { get; set; }
        public int IdArticuloStock { get; set; }
        public int Cantidad { get; set; }
        public int CantidadConfirmada { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }

        // secondary

        public string Articulo { get; set; }
        public string UnidadMedidaCorto { get; set; }
        public string Almacen { get; set; }
        public string AlmacenUbicacion { get; set; }
        public string UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }
    }

}
