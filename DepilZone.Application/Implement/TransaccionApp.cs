using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class TransaccionApp: ITransaccionApp
    {
        private readonly ITransaccionDom _ITransaccionDom;
        public TransaccionApp(ITransaccionDom ITransaccionDom)
        {
            this._ITransaccionDom = ITransaccionDom;
        }

        public async Task<List<TransaccionDTO>> Listar()
        {
            return await _ITransaccionDom.Listar();
        }

        public async Task<bool> Registrar(TransaccionDTO model)
        {
            return await _ITransaccionDom.Registrar(model);
        }

        public async Task<bool> Confirmar(int id, TransaccionDTO model)
        {
            return await _ITransaccionDom.Confirmar(id, model);
        }

        public async Task<TransaccionDTO> Buscar(int id)
        {
            return await _ITransaccionDom.Buscar(id);
        }

        public async Task<List<TransaccionDetalleDTO>> BuscarDetalle(int id)
        {
            return await _ITransaccionDom.BuscarDetalle(id);
        }

        public async Task<bool> Cancelar(int id, TransaccionDTO model)
        {
            return await _ITransaccionDom.Cancelar(id, model);
        }

        public async Task<List<TransaccionDTO>> BuscarPorParametros(string fechaDesde, string fechaHasta, int idTransaccion,  int idTipoTransaccion, int idEstadoTransaccion, int bloque)
        {
            return await _ITransaccionDom.BuscarPorParametros(fechaDesde, fechaHasta, idTransaccion, idTipoTransaccion, idEstadoTransaccion, bloque);
        }
    }
}
