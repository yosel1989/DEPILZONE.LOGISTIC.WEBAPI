using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface
{
    public interface ITransaccionClaseApp
    {
        Task<List<TransaccionClaseDTO>> Listar();
        Task<bool> Registrar(TransaccionClaseDTO model);
        Task<bool> Actualizar(int id, TransaccionClaseDTO model);

    }
}
