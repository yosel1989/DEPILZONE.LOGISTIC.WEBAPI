
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IAuthDat
    {
        Task<UsuarioDTO> Login(CredencialesDTO model);

        Task<bool> ChangePassword(CambioClaveDTO model);

    }
}
