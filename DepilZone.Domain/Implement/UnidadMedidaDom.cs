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
    public class UnidadMedidaDom : IUnidadMedidaDom
    {
        private readonly IUnidadMedidaDat _IUnidadMedidaDat;
        public UnidadMedidaDom(IUnidadMedidaDat IUnidadMedidaDat)
        {
            this._IUnidadMedidaDat = IUnidadMedidaDat;
        }
        

        public async Task<List<UnidadMedidaDTO>> Listar()
        {
            return await _IUnidadMedidaDat.Listar();
        }

        public async Task<bool> Registrar(UnidadMedidaDTO model)
        {
            return await _IUnidadMedidaDat.Registrar(model);
        }

        public async Task<bool> Actualizar(int id, UnidadMedidaDTO model)
        {
            return await _IUnidadMedidaDat.Actualizar(id, model);
        }

    }
}
