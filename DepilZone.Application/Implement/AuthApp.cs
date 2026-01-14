using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class AuthApp: IAuthApp
    {
        private readonly IAuthDom _IAuthDom;
        public AuthApp(IAuthDom IAuthDom)
        {
            this._IAuthDom = IAuthDom;
        }

        public async Task<UsuarioDTO> Login(CredencialesDTO model)
        {
            return await _IAuthDom.Login(model);
        }

        public async Task<bool> ChangePassword(CambioClaveDTO model)
        {
            return await _IAuthDom.ChangePassword(model);
        }
    }
}
