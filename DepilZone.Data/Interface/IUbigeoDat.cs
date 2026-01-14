using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IUbigeoDat
    {
        Task<List<UDepartamentoDTO>> Departamentos();

        Task<List<UCiudadDTO>> Ciudades(string idDepartamento);

        Task<List<UDistritoDTO>> Distritos(string idDepartamento, string idCiudad);
    }
}
