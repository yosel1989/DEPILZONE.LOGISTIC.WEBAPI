using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IOrdenCompraDat
    {
        Task<List<OrdenCompraDTO>> Listar();
        Task<OrdenCompraDTO> Buscar(int id);
        Task<bool> Registrar(OrdenCompraDTO model);
    }
}
