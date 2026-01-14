using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface ITransaccionDom
    {
        Task<List<TransaccionDTO>> Listar();

        Task<bool> Registrar(TransaccionDTO model);

        Task<bool> Confirmar(int id, TransaccionDTO model);
        Task<TransaccionDTO> Buscar(int id);
        Task<List<TransaccionDetalleDTO>> BuscarDetalle(int id);
        Task<bool> Cancelar(int id, TransaccionDTO model);
        Task<List<TransaccionDTO>> BuscarPorParametros(string fechaDesde, string fechaHasta, int idTransaccion, int idTipoTransaccion, int idEstadoTransaccion, int bloque);
    }
}
