using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IOrdenCompraDom
    {
        Task<List<OrdenCompraDTO>> Listar();

        Task<bool> Registrar(OrdenCompraDTO model);

        Task<OrdenCompraDTO> Buscar(int id);
    }
}
