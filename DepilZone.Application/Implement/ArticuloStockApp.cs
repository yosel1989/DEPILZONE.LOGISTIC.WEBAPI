using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class ArticuloStockApp: IArticuloStockApp
    {
        private readonly IArticuloStockDom _IArticuloStockDom;
        public ArticuloStockApp(IArticuloStockDom IArticuloStockDom)
        {
            this._IArticuloStockDom = IArticuloStockDom;
        }

        public async Task<List<ArticuloStockDTO>> Listar()
        {
            return await _IArticuloStockDom.Listar();
        }

        public async Task<bool> Registrar(ArticuloStockDTO model)
        {
            return await _IArticuloStockDom.Registrar(model);
        }
        public async Task<bool> Actualizar(int id, ArticuloStockDTO model)
        {
            return await _IArticuloStockDom.Actualizar(id, model);
        }
        public async Task<List<ArticuloStockDTO>> ListarPorParametros(string parametros)
        {
            return await _IArticuloStockDom.ListarPorParametros(parametros);
        }
        public async Task<List<ArticuloStockDTO>> ListarPorSedeyParametros(int idSede, string parametros)
        {
            return await _IArticuloStockDom.ListarPorSedeyParametros(idSede, parametros);
        }
        public async Task<List<ArticuloStockTrackingHistory>> BuscarMovimientos(int idArticuloStock, DateTime fechaDesde, DateTime fechaHasta)
        {
            return await _IArticuloStockDom.BuscarMovimientos(idArticuloStock, fechaDesde, fechaHasta);
        }

        public async Task<List<ArticuloStockDTO>> ListarPorSedeyArticulo(int idSede, int idArticulo)
        {
            return await _IArticuloStockDom.ListarPorSedeyArticulo(idSede, idArticulo);
        }

        public async Task<List<ArticuloStockTrackingHistory>> ConsultarMovimientos(int bloque, int idSede, int idArticuloStock, string fechaDesde, string fechaHasta)
        {
            return await _IArticuloStockDom.ConsultarMovimientos(bloque, idSede, idArticuloStock, fechaDesde, fechaHasta);
        }
    }
}
