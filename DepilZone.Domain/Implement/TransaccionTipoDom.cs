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
    public class TransaccionTipoDom : ITransaccionTipoDom
    {
        private readonly ITransaccionTipoDat _ITransaccionTipoDat;
        public TransaccionTipoDom(ITransaccionTipoDat ITransaccionTipoDat)
        {
            this._ITransaccionTipoDat = ITransaccionTipoDat;
        }
        
        public async Task<List<TransaccionTipoDTO>> Listar()
        {
            return await _ITransaccionTipoDat.Listar();
        }

        public async Task<bool> Registrar(TransaccionTipoDTO model)
        {
            return await _ITransaccionTipoDat.Registrar(model);
        }

        public async Task<bool> Actualizar(int id, TransaccionTipoDTO model)
        {
            return await _ITransaccionTipoDat.Actualizar(id, model);
        }

    }
}
