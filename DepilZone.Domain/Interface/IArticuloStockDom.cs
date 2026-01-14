using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IArticuloStockDom
    {
        Task<List<ArticuloStockDTO>> Listar();

        Task<bool> Registrar(ArticuloStockDTO model);
        Task<bool> Actualizar(int id, ArticuloStockDTO model);
        Task<List<ArticuloStockDTO>> ListarPorParametros(string parametros);
        Task<List<ArticuloStockDTO>> ListarPorSedeyParametros(int idSede, string parametros);
        Task<List<ArticuloStockTrackingHistory>> BuscarMovimientos(int idArticuloStock, DateTime fechaDesde, DateTime fechaHasta);
        Task<List<ArticuloStockDTO>> ListarPorSedeyArticulo(int idSede, int idArticulo);
        Task<List<ArticuloStockTrackingHistory>> ConsultarMovimientos(int bloque, int idSede, int idArticuloStock, string fechaDesde, string fechaHasta);
    }
}
