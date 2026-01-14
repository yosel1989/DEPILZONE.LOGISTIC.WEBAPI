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
    public class AlmacenDom : IAlmacenDom
    {
        private readonly IAlmacenDat _IAlmacenDat;
        public AlmacenDom(IAlmacenDat IAlmacenDat)
        {
            this._IAlmacenDat = IAlmacenDat;
        }
        

        public async Task<List<AlmacenDTO>> Listar()
        {
            return await _IAlmacenDat.Listar();
        }

        public async Task<bool> Registrar(AlmacenDTO model)
        {
            return await _IAlmacenDat.Registrar(model);
        }

        public async Task<bool> Actualizar(int id, AlmacenDTO model)
        {
            return await _IAlmacenDat.Actualizar(id, model);
        }

        public async Task<List<AlmacenDTO>> BuscarPorSede(int idSede)
        {
            return await _IAlmacenDat.BuscarPorSede(idSede);
        }
    }
}
