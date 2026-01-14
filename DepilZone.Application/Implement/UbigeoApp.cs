using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class UbigeoApp: IUbigeoApp
    {
        private readonly IUbigeoDom _IUbigeoDom;
        public UbigeoApp(IUbigeoDom IUbigeoDom)
        {
            this._IUbigeoDom = IUbigeoDom;
        }

        public async Task<List<UDepartamentoDTO>> Departamentos()
        {
            return await _IUbigeoDom.Departamentos();
        }

        public async Task<List<UCiudadDTO>> Ciudades(string idDepartamento)
        {
            return await _IUbigeoDom.Ciudades(idDepartamento);
        }

        public async Task<List<UDistritoDTO>> Distritos(string idDepartamento, string idCiudad)
        {
            return await _IUbigeoDom.Distritos(idDepartamento, idCiudad);
        }
    }
}
