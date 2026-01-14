using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class AlmacenApp: IAlmacenApp
    {
        private readonly IAlmacenDom _IAlmacenDom;
        public AlmacenApp(IAlmacenDom IAlmacenDom)
        {
            this._IAlmacenDom = IAlmacenDom;
        }

        public async Task<List<AlmacenDTO>> Listar()
        {
            return await _IAlmacenDom.Listar();
        }

        public async Task<bool> Registrar(AlmacenDTO model)
        {
            return await _IAlmacenDom.Registrar(model);
        }
        public async Task<bool> Actualizar(int id, AlmacenDTO model)
        {
            return await _IAlmacenDom.Actualizar(id, model);
        }

        public async Task<List<AlmacenDTO>> BuscarPorSede(int idSede)
        {
            return await _IAlmacenDom.BuscarPorSede(idSede);
        }
    }
}
