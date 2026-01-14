using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class SedeApp: ISedeApp
    {
        private readonly ISedeDom _ISedeDom;
        public SedeApp(ISedeDom ISedeDom)
        {
            this._ISedeDom = ISedeDom;
        }

        public async Task<List<SedeDTO>> Listar()
        {
            return await _ISedeDom.Listar();
        }
    }
}
