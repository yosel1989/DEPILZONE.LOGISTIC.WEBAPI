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
    public class SedeDom : ISedeDom
    {
        private readonly ISedeDat _ISedeDat;
        public SedeDom(ISedeDat ISedeDat)
        {
            this._ISedeDat = ISedeDat;
        }
        

        public async Task<List<SedeDTO>> Listar()
        {
            return await _ISedeDat.Listar();
        }

    }
}
