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
    public class ArticuloProveedorDom : IArticuloProveedorDom
    {
        private readonly IArticuloProveedorDat _IArticuloProveedorDat;
        public ArticuloProveedorDom(IArticuloProveedorDat IArticuloProveedorDat)
        {
            this._IArticuloProveedorDat = IArticuloProveedorDat;
        }

        public async Task<bool> Registrar(ArticuloDTO model)
        {
            return await _IArticuloProveedorDat.Registrar(model);
        }


    }
}
