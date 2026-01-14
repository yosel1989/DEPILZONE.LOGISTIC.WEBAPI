using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class TransaccionTipoApp: ITransaccionTipoApp
    {
        private readonly ITransaccionTipoDom _ITransaccionTipoDom;
        public TransaccionTipoApp(ITransaccionTipoDom ITransaccionTipoDom)
        {
            this._ITransaccionTipoDom = ITransaccionTipoDom;
        }

        public async Task<List<TransaccionTipoDTO>> Listar()
        {
            return await _ITransaccionTipoDom.Listar();
        }

        public async Task<bool> Registrar(TransaccionTipoDTO model)
        {
            return await _ITransaccionTipoDom.Registrar(model);
        }
        public async Task<bool> Actualizar(int id, TransaccionTipoDTO model)
        {
            return await _ITransaccionTipoDom.Actualizar(id, model);
        }
    }
}
