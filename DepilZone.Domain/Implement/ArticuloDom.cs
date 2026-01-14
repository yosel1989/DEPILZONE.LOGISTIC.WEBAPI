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
    public class ArticuloDom : IArticuloDom
    {
        private readonly IArticuloDat _IArticuloDat;
        public ArticuloDom(IArticuloDat IArticuloDat)
        {
            this._IArticuloDat = IArticuloDat;
        }
        

        public async Task<List<ArticuloDTO>> Listar()
        {
            return await _IArticuloDat.Listar();
        }

        public async Task<List<ArticuloDTO>> ListarPorParametros(string parametros)
        {
            return await _IArticuloDat.ListarPorParametros(parametros);
        }

        public async Task<bool> Registrar(ArticuloDTO model)
        {
            return await _IArticuloDat.Registrar(model);
        }

        public async Task<bool> Modificar(int id, ArticuloDTO model)
        {
            return await _IArticuloDat.Modificar(id, model);
        }

    }
}
