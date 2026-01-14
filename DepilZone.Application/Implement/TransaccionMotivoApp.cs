using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class TransaccionMotivoApp: ITransaccionMotivoApp
    {
        private readonly ITransaccionMotivoDom _ITransaccionMotivoDom;
        public TransaccionMotivoApp(ITransaccionMotivoDom ITransaccionMotivoDom)
        {
            this._ITransaccionMotivoDom = ITransaccionMotivoDom;
        }

        public async Task<List<TransaccionMotivoDTO>> Listar()
        {
            return await _ITransaccionMotivoDom.Listar();
        }
    }
}
