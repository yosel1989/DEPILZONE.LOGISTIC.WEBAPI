using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IProveedorDom
    {
        Task<List<ProveedorDTO>> Listar();

        Task<List<ProveedorDTO>> ListarPorParametros(string parametros);

        Task<bool> Registrar(ProveedorDTO model);

        Task<bool> Modificar(int id, ProveedorDTO model);

        // RELATION SHIP

        Task<List<ProveedorDTO>> ListarPorArticulo(int idArticulo);
    }
}
