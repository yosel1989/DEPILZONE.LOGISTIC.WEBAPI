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
    public class TransaccionEstadoDom : ITransaccionEstadoDom
    {
        private readonly ITransaccionEstadoDat _ITransaccionEstadoDat;
        public TransaccionEstadoDom(ITransaccionEstadoDat ITransaccionEstadoDat)
        {
            this._ITransaccionEstadoDat = ITransaccionEstadoDat;
        }
        
        public async Task<List<TransaccionEstadoDTO>> Listar()
        {
            return await _ITransaccionEstadoDat.Listar();
        }
        

    }
}
