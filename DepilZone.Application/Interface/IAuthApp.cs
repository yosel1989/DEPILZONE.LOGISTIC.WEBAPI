using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface
{
    public interface IAuthApp
    {
        Task<UsuarioDTO> Login(CredencialesDTO model);

        Task<bool> ChangePassword(CambioClaveDTO model);

    }
}
