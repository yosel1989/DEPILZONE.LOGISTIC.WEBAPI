using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IArticuloDom
    {
        Task<List<ArticuloDTO>> Listar();
        Task<List<ArticuloDTO>> ListarPorParametros(string parametros);

        Task<bool> Registrar(ArticuloDTO model);

        Task<bool> Modificar(int id, ArticuloDTO model);
    }
}
