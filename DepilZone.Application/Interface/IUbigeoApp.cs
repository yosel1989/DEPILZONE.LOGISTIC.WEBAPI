using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface
{
    public interface IUbigeoApp
    {
        Task<List<UDepartamentoDTO>> Departamentos();

        Task<List<UCiudadDTO>> Ciudades(string idDepartamento);

        Task<List<UDistritoDTO>> Distritos(string idDepartamento, string idCiudad);

    }
}
