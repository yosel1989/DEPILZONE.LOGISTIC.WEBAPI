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
    public class AuthDom : IAuthDom
    {
        private readonly IAuthDat _IAuthDat;
        public AuthDom(IAuthDat IAuthDat)
        {
            this._IAuthDat = IAuthDat;
        }


        public async Task<UsuarioDTO> Login(CredencialesDTO model)
        {
            return await _IAuthDat.Login(model);
        }


        public async Task<bool> ChangePassword(CambioClaveDTO model)
        {
            return await _IAuthDat.ChangePassword(model);
        }

    }
}
