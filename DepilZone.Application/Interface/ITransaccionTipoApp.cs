using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface
{
    public interface ITransaccionTipoApp
    {
        Task<List<TransaccionTipoDTO>> Listar();
        Task<bool> Registrar(TransaccionTipoDTO model);
        Task<bool> Actualizar(int id, TransaccionTipoDTO model);

    }
}
