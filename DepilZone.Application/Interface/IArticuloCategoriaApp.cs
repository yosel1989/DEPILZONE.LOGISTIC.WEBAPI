using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface
{
    public interface IArticuloCategoriaApp
    {
        Task<List<ArticuloCategoriaDTO>> Listar();
        Task<bool> Registrar(ArticuloCategoriaDTO model);
        Task<bool> Actualizar(int id, ArticuloCategoriaDTO model);

    }
}
