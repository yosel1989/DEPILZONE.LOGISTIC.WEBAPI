using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface ITransaccionClaseDom
    {
        Task<List<TransaccionClaseDTO>> Listar();

        Task<bool> Registrar(TransaccionClaseDTO model);
        Task<bool> Actualizar(int id, TransaccionClaseDTO model);
    }
}
