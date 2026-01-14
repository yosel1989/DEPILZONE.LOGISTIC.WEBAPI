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
    public class OrdenCompraDom : IOrdenCompraDom
    {
        private readonly IOrdenCompraDat _IOrdenCompraDat;
        public OrdenCompraDom(IOrdenCompraDat IOrdenCompraDat)
        {
            this._IOrdenCompraDat = IOrdenCompraDat;
        }
        

        public async Task<List<OrdenCompraDTO>> Listar()
        {
            return await _IOrdenCompraDat.Listar();
        }

        public async Task<bool> Registrar(OrdenCompraDTO model)
        {
            return await _IOrdenCompraDat.Registrar(model);
        }

        public async Task<OrdenCompraDTO> Buscar(int id)
        {
            return await _IOrdenCompraDat.Buscar(id);
        }
    }
}
