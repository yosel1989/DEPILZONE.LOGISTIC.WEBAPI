using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface
{
    public interface IUnidadMedidaApp
    {
        Task<List<UnidadMedidaDTO>> Listar();
        Task<bool> Registrar(UnidadMedidaDTO model);
        Task<bool> Actualizar(int id, UnidadMedidaDTO model);

    }
}
