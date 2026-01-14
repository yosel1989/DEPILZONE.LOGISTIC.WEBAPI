
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface
{
    public interface IAlmacenApp
    {
        Task<List<AlmacenDTO>> Listar();
        Task<bool> Registrar(AlmacenDTO model);
        Task<bool> Actualizar(int id, AlmacenDTO model);

        Task<List<AlmacenDTO>> BuscarPorSede(int idSede);

    }
}
