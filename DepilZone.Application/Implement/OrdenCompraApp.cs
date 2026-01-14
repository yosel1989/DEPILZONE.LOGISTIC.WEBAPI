using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class OrdenCompraApp: IOrdenCompraApp
    {
        private readonly IOrdenCompraDom _IOrdenCompraDom;
        public OrdenCompraApp(IOrdenCompraDom IOrdenCompraDom)
        {
            this._IOrdenCompraDom = IOrdenCompraDom;
        }

        public async Task<List<OrdenCompraDTO>> Listar()
        {
            return await _IOrdenCompraDom.Listar();
        }

        public async Task<bool> Registrar(OrdenCompraDTO model)
        {
            return await _IOrdenCompraDom.Registrar(model);
        }

        public async Task<OrdenCompraDTO> Buscar(int id)
        {
            return await _IOrdenCompraDom.Buscar(id);
        }
    }
}
