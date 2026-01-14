using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class RespuestaDTO<T>
    {
        public Boolean Exito { get; set; }
        public string Mensaje { get; set; }
        public int ErrorNumero { get; set; }
        public string ErrorDetalle { get; set; }
        public T Response { get; set; }
    }

    public class MensajeSignalR
    {
        public Boolean Exito { get; set; }
        public string Mensaje { get; set; }
        public string DatosJSON { get; set; }
        public int IdPerfil { get; set; }
        public TipoAlerta Tipo { get; set; }
    }

    public class ChatEnt
    {
        public Guid Id { get; set; }
        public int IdDeUsuario { get; set; }
        public int IdParaUsuario { get; set; }
        public DateTime FechaHora { get; set; }
        public string Texto { get; set; }
        public int EstadoTexto { get; set; }
    }

    public class ChatUsuarioListaDTO
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public int MensajeSinLeer { get; set; }
        public string Foto { get; set; }
        public string UltimaConexion { get; set; }
        public int Estado { get; set; }
    }

    public class IdentificacionUsuarioChatDTO
    {
        public int IdUsuario { get; set; }
        public DateTime FechaHoraConeccion { get; set; }
        public string ConnectionId { get; set; }
    }

    public enum TipoAlerta
    {
        Actividad = 1,
        RespuestaActividad = 2,
        PreferenteAsignado = 3,
        RetornoPreferente = 4,
        ConnectionId = 5,
        ConexionNueva = 6,
        ConexionRechazada = 7,
        ConexionListaUsuario = 8,
        DesconexionUsuario = 9,
        NuevoMensaje = 10,
        CitaReservada = 11,
        ReservaEliminada = 12,
        AvisoGeneral = 13,
        MenuActualizado = 14,

        TransaccionConfirmada = 15,
        TransaccionEntradaCreada = 16
    }
}
