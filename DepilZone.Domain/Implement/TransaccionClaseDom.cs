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
    public class TransaccionClaseDom : ITransaccionClaseDom
    {
        private readonly ITransaccionClaseDat _ITransaccionClaseDat;
        public TransaccionClaseDom(ITransaccionClaseDat ITransaccionTipoDat)
        {
            this._ITransaccionClaseDat = ITransaccionTipoDat;
        }
        
        public async Task<List<TransaccionClaseDTO>> Listar()
        {
            return await _ITransaccionClaseDat.Listar();
        }

        public async Task<bool> Registrar(TransaccionClaseDTO model)
        {
            return await _ITransaccionClaseDat.Registrar(model);
        }

        public async Task<bool> Actualizar(int id, TransaccionClaseDTO model)
        {
            return await _ITransaccionClaseDat.Actualizar(id, model);
        }

    }
}
