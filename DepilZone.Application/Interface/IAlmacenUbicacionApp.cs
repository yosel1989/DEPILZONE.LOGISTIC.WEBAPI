
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface
{
    public interface IAlmacenUbicacionApp
    {
        Task<List<AlmacenUbicacionDTO>> Listar();
        Task<bool> Registrar(AlmacenUbicacionDTO model);
        Task<bool> Actualizar(int id, AlmacenUbicacionDTO model);

        Task<List<AlmacenUbicacionDTO>> BuscarPorAlmacen(int idAlmacen);

    }
}
