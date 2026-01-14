using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DepilZone.Data;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;

namespace DepilZone.Domain
{
    public class UbigeoDom : IUbigeoDom
    {
        private readonly IUbigeoDat _IUbigeoDat;
        public UbigeoDom(IUbigeoDat IUbigeoDat)
        {
            this._IUbigeoDat = IUbigeoDat;
        }


        public async Task<List<UDepartamentoDTO>> Departamentos()
        {
            return await _IUbigeoDat.Departamentos();
        }

        public async Task<List<UCiudadDTO>> Ciudades(string idDepartamento)
        {
            return await _IUbigeoDat.Ciudades(idDepartamento);
        }

        public async Task<List<UDistritoDTO>> Distritos(string idDepartamento, string idCiudad)
        {
            return await _IUbigeoDat.Distritos(idDepartamento, idCiudad);
        }

    }
}
