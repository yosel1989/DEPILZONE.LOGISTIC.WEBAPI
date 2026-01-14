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
    public class ArticuloCategoriaDom : IArticuloCategoriaDom
    {
        private readonly IArticuloCategoriaDat _IArticuloCategoriaDat;
        public ArticuloCategoriaDom(IArticuloCategoriaDat IArticuloCategoriaDat)
        {
            this._IArticuloCategoriaDat = IArticuloCategoriaDat;
        }
        

        public async Task<List<ArticuloCategoriaDTO>> Listar()
        {
            return await _IArticuloCategoriaDat.Listar();
        }

        public async Task<bool> Registrar(ArticuloCategoriaDTO model)
        {
            return await _IArticuloCategoriaDat.Registrar(model);
        }

        public async Task<bool> Actualizar(int id, ArticuloCategoriaDTO model)
        {
            return await _IArticuloCategoriaDat.Actualizar(id, model);
        }

    }
}
