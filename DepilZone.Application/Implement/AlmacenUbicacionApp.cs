using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class AlmacenUbicacionApp: IAlmacenUbicacionApp
    {
        private readonly IAlmacenUbicacionDom _IAlmacenUbicacionDom;
        public AlmacenUbicacionApp(IAlmacenUbicacionDom IAlmacenUbicacionDom)
        {
            this._IAlmacenUbicacionDom = IAlmacenUbicacionDom;
        }

        public async Task<List<AlmacenUbicacionDTO>> Listar()
        {
            return await _IAlmacenUbicacionDom.Listar();
        }

        public async Task<bool> Registrar(AlmacenUbicacionDTO model)
        {
            return await _IAlmacenUbicacionDom.Registrar(model);
        }
        public async Task<bool> Actualizar(int id, AlmacenUbicacionDTO model)
        {
            return await _IAlmacenUbicacionDom.Actualizar(id, model);
        }

        public async Task<List<AlmacenUbicacionDTO>> BuscarPorAlmacen(int idAlmacen)
        {
            return await _IAlmacenUbicacionDom.BuscarPorAlmacen(idAlmacen);
        }
    }
}
