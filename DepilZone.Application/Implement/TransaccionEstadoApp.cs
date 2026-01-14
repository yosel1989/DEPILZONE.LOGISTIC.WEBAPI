using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class TransaccionEstadoApp: ITransaccionEstadoApp
    {
        private readonly ITransaccionEstadoDom _ITransaccionEstadoDom;
        public TransaccionEstadoApp(ITransaccionEstadoDom ITransaccionEstadoDom)
        {
            this._ITransaccionEstadoDom = ITransaccionEstadoDom;
        }

        public async Task<List<TransaccionEstadoDTO>> Listar()
        {
            return await _ITransaccionEstadoDom.Listar();
        }
    }
}
