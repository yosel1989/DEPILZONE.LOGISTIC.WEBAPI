using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IArticuloCategoriaDat
    {
        Task<List<ArticuloCategoriaDTO>> Listar();
        Task<bool> Registrar(ArticuloCategoriaDTO model);
        Task<bool> Actualizar(int id, ArticuloCategoriaDTO model);
    }
}
