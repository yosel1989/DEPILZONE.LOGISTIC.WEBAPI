using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DepilZone.Data;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;

namespace DepilZone.Domain
{
    public class TransaccionDom : ITransaccionDom
    {
        private readonly ITransaccionDat _ITransaccionDat;
        public TransaccionDom(ITransaccionDat ITransaccionDat)
        {
            this._ITransaccionDat = ITransaccionDat;
        }
        

        public async Task<List<TransaccionDTO>> Listar()
        {
            return await _ITransaccionDat.Listar();
        }

        public async Task<bool> Registrar(TransaccionDTO model)
        {
            return await _ITransaccionDat.Registrar(model);
        }

        public async Task<bool> Confirmar(int id, TransaccionDTO model)
        {
            return await _ITransaccionDat.Confirmar(id, model);
        }

        public async Task<TransaccionDTO> Buscar(int id)
        { 

            return await _ITransaccionDat.Buscar(id);
        }

        public async Task<List<TransaccionDetalleDTO>> BuscarDetalle(int id)
        {
            return await _ITransaccionDat.BuscarDetalle(id);
        }

        public async Task<bool> Cancelar(int id, TransaccionDTO model)
        {
            return await _ITransaccionDat.Cancelar(id, model);
        }

        public async Task<List<TransaccionDTO>> BuscarPorParametros(string fechaDesde, string fechaHasta, int idTransaccion, int idTipoTransaccion, int idEstadoTransaccion, int bloque)
        {
            return await _ITransaccionDat.BuscarPorParametros(fechaDesde, fechaHasta, idTransaccion, idTipoTransaccion, idEstadoTransaccion, bloque);
        }


    }
}
