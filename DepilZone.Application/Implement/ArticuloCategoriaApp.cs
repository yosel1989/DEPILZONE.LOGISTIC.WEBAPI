using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class ArticuloCategoriaApp: IArticuloCategoriaApp
    {
        private readonly IArticuloCategoriaDom _IArticuloCategoriaDom;
        public ArticuloCategoriaApp(IArticuloCategoriaDom IArticuloCategoriaDom)
        {
            this._IArticuloCategoriaDom = IArticuloCategoriaDom;
        }

        public async Task<List<ArticuloCategoriaDTO>> Listar()
        {
            return await _IArticuloCategoriaDom.Listar();
        }

        public async Task<bool> Registrar(ArticuloCategoriaDTO model)
        {
            return await _IArticuloCategoriaDom.Registrar(model);
        }
        public async Task<bool> Actualizar(int id, ArticuloCategoriaDTO model)
        {
            return await _IArticuloCategoriaDom.Actualizar(id, model);
        }
    }
}
