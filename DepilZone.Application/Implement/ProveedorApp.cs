using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class ProveedorApp: IProveedorApp
    {
        private readonly IProveedorDom _IProveedorDom;
        public ProveedorApp(IProveedorDom IProveedorDom)
        {
            this._IProveedorDom = IProveedorDom;
        }

        public async Task<List<ProveedorDTO>> Listar()
        {
            return await _IProveedorDom.Listar();
        }

        public async Task<List<ProveedorDTO>> ListarPorParametros(string parametros)
        {
            return await _IProveedorDom.ListarPorParametros(parametros);
        }

        public async Task<bool> Registrar(ProveedorDTO model)
        {
            return await _IProveedorDom.Registrar(model);
        }

        public async Task<bool> Modificar(int id, ProveedorDTO model)
        {
            return await _IProveedorDom.Modificar(id, model);
        }

        // RELATION SHIP

        public async Task<List<ProveedorDTO>> ListarPorArticulo(int idArticulo)
        {
            return await _IProveedorDom.ListarPorArticulo(idArticulo);
        }
    }
}
