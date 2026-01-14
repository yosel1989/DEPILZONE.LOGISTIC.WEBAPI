using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class TransaccionClaseApp: ITransaccionClaseApp
    {
        private readonly ITransaccionClaseDom _ITransaccionClaseDom;
        public TransaccionClaseApp(ITransaccionClaseDom ITransaccionTipoDom)
        {
            this._ITransaccionClaseDom = ITransaccionTipoDom;
        }

        public async Task<List<TransaccionClaseDTO>> Listar()
        {
            return await _ITransaccionClaseDom.Listar();
        }

        public async Task<bool> Registrar(TransaccionClaseDTO model)
        {
            return await _ITransaccionClaseDom.Registrar(model);
        }
        public async Task<bool> Actualizar(int id, TransaccionClaseDTO model)
        {
            return await _ITransaccionClaseDom.Actualizar(id, model);
        }
    }
}
