using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class UnidadMedidaApp: IUnidadMedidaApp
    {
        private readonly IUnidadMedidaDom _IUnidadMedidaDom;
        public UnidadMedidaApp(IUnidadMedidaDom IUnidadMedidaDom)
        {
            this._IUnidadMedidaDom = IUnidadMedidaDom;
        }

        public async Task<List<UnidadMedidaDTO>> Listar()
        {
            return await _IUnidadMedidaDom.Listar();
        }

        public async Task<bool> Registrar(UnidadMedidaDTO model)
        {
            return await _IUnidadMedidaDom.Registrar(model);
        }
        public async Task<bool> Actualizar(int id, UnidadMedidaDTO model)
        {
            return await _IUnidadMedidaDom.Actualizar(id, model);
        }
    }
}
