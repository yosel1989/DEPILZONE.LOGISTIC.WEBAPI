using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IAlmacenUbicacionDom
    {
        Task<List<AlmacenUbicacionDTO>> Listar();
        Task<List<AlmacenUbicacionDTO>> BuscarPorAlmacen(int idAlmacen);

        Task<bool> Registrar(AlmacenUbicacionDTO model);
        Task<bool> Actualizar(int id, AlmacenUbicacionDTO model);
    }
}
