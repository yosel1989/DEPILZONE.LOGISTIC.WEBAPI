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
    public class ProveedorDom : IProveedorDom
    {
        private readonly IProveedorDat _IProveedorDat;
        public ProveedorDom(IProveedorDat IProveedorDat)
        {
            this._IProveedorDat = IProveedorDat;
        }
        

        public async Task<List<ProveedorDTO>> Listar()
        {
            return await _IProveedorDat.Listar();
        }

        public async Task<List<ProveedorDTO>> ListarPorParametros(string parametros)
        {
            return await _IProveedorDat.ListarPorParametros(parametros);
        }

        public async Task<bool> Registrar(ProveedorDTO model)
        {
            return await _IProveedorDat.Registrar(model);
        }

        public async Task<bool> Modificar(int id, ProveedorDTO model)
        {
            return await _IProveedorDat.Modificar(id, model);
        }

        // RELATION SHIP
        public async Task<List<ProveedorDTO>> ListarPorArticulo(int idArticulo)
        {
            return await _IProveedorDat.ListarPorArticulo(idArticulo);
        }

    }
}
