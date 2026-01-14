using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface
{
    public interface IProveedorApp
    {
        Task<List<ProveedorDTO>> Listar();
        Task<List<ProveedorDTO>> ListarPorParametros(string parametros);
        Task<bool> Registrar(ProveedorDTO model);
        Task<bool> Modificar(int id, ProveedorDTO model);

        // RELATIONSHIP
        Task<List<ProveedorDTO>> ListarPorArticulo(int idArticulo);
    }
}
