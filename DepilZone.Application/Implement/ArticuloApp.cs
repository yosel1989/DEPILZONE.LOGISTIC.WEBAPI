using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class ArticuloApp: IArticuloApp
    {
        private readonly IArticuloDom _IArticuloDom;
        public ArticuloApp(IArticuloDom IArticuloDom)
        {
            this._IArticuloDom = IArticuloDom;
        }

        public async Task<List<ArticuloDTO>> Listar()
        {
            return await _IArticuloDom.Listar();
        }

        public async Task<List<ArticuloDTO>> ListarPorParametros(string parametros)
        {
            return await _IArticuloDom.ListarPorParametros(parametros);
        }

        public async Task<bool> Registrar(ArticuloDTO model)
        {
            return await _IArticuloDom.Registrar(model);
        }

        public async Task<bool> Modificar(int id, ArticuloDTO model)
        {
            return await _IArticuloDom.Modificar(id, model);
        }
    }
}
