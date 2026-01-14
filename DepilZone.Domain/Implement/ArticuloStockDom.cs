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
    public class ArticuloStockDom : IArticuloStockDom
    {
        private readonly IArticuloStockDat _IArticuloStockDat;
        public ArticuloStockDom(IArticuloStockDat IArticuloStockDat)
        {
            this._IArticuloStockDat = IArticuloStockDat;
        }
        

        public async Task<List<ArticuloStockDTO>> Listar()
        {
            return await _IArticuloStockDat.Listar();
        }

        public async Task<bool> Registrar(ArticuloStockDTO model)
        {
            return await _IArticuloStockDat.Registrar(model);
        }

        public async Task<bool> Actualizar(int id, ArticuloStockDTO model)
        {
            return await _IArticuloStockDat.Actualizar(id, model);
        }

        public async Task<List<ArticuloStockDTO>> ListarPorParametros(string parametros) {
            return await _IArticuloStockDat.ListarPorParametros(parametros);
        }

        public async Task<List<ArticuloStockDTO>> ListarPorSedeyParametros(int idSede, string parametros)
        {
            return await _IArticuloStockDat.ListarPorSedeyParametros(idSede, parametros);
        }

        public async Task<List<ArticuloStockTrackingHistory>> BuscarMovimientos(int idArticuloStock, DateTime fechaDesde, DateTime fechaHasta)
        {
            return await _IArticuloStockDat.BuscarMovimientos(idArticuloStock, fechaDesde, fechaHasta);
        }

        public async Task<List<ArticuloStockDTO>> ListarPorSedeyArticulo(int idSede, int idArticulo)
        {
            return await _IArticuloStockDat.ListarPorSedeyArticulo(idSede, idArticulo);
        }

        public async Task<List<ArticuloStockTrackingHistory>> ConsultarMovimientos(int bloque,  int idSede, int idArticuloStock, string fechaDesde, string fechaHasta)
        {
            return await _IArticuloStockDat.ConsultarMovimientos(bloque, idSede, idArticuloStock, fechaDesde, fechaHasta);
        }

    }
}
