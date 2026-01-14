using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IAlmacenDom
    {
        Task<List<AlmacenDTO>> Listar();
        Task<List<AlmacenDTO>> BuscarPorSede(int idSede);

        Task<bool> Registrar(AlmacenDTO model);
        Task<bool> Actualizar(int id, AlmacenDTO model);
    }
}
