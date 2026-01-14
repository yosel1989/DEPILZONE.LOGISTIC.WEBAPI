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
    public class TransaccionMotivoDom : ITransaccionMotivoDom
    {
        private readonly ITransaccionMotivoDat _ITransaccionMotivoDat;
        public TransaccionMotivoDom(ITransaccionMotivoDat ITransaccionMotivoDat)
        {
            this._ITransaccionMotivoDat = ITransaccionMotivoDat;
        }
        
        public async Task<List<TransaccionMotivoDTO>> Listar()
        {
            return await _ITransaccionMotivoDat.Listar();
        }
        

    }
}
