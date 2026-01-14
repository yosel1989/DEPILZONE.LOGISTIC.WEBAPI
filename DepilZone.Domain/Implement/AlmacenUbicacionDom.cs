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
    public class AlmacenUbicacionDom : IAlmacenUbicacionDom
    {
        private readonly IAlmacenUbicacionDat _IAlmacenUbicacionDat;
        public AlmacenUbicacionDom(IAlmacenUbicacionDat IAlmacenUbicacionDat)
        {
            this._IAlmacenUbicacionDat = IAlmacenUbicacionDat;
        }
        

        public async Task<List<AlmacenUbicacionDTO>> Listar()
        {
            return await _IAlmacenUbicacionDat.Listar();
        }

        public async Task<bool> Registrar(AlmacenUbicacionDTO model)
        {
            return await _IAlmacenUbicacionDat.Registrar(model);
        }

        public async Task<bool> Actualizar(int id, AlmacenUbicacionDTO model)
        {
            return await _IAlmacenUbicacionDat.Actualizar(id, model);
        }

        public async Task<List<AlmacenUbicacionDTO>> BuscarPorAlmacen(int idAlmacen)
        {
            return await _IAlmacenUbicacionDat.BuscarPorAlmacen(idAlmacen);
        }
    }
}
