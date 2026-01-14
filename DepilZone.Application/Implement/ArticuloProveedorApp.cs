using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class ArticuloProveedorApp: IArticuloProveedorApp
    {
        private readonly IArticuloProveedorDom _IArticuloProveedorDom;
        public ArticuloProveedorApp(IArticuloProveedorDom IArticuloProveedorDom)
        {
            this._IArticuloProveedorDom = IArticuloProveedorDom;
        }

        public async Task<bool> Registrar(ArticuloDTO model)
        {
            return await _IArticuloProveedorDom.Registrar(model);
        }
    }
}
