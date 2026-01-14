using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloStockController : ControllerBase
    {
        private readonly IArticuloStockApp _ArticuloStock;

        public ArticuloStockController(IArticuloStockApp ArticuloStockApp)
        {
            this._ArticuloStock = ArticuloStockApp;
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var ArticuloStockes = await _ArticuloStock.Listar();
                return Ok(new
                {
                    data = ArticuloStockes,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Registrar(ArticuloStockDTO model)
        {
            try
            {
                var output = await _ArticuloStock.Registrar(model);
                return Ok(new
                {
                    data = output,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(int id,ArticuloStockDTO model)
        {
            try
            {
                var output = await _ArticuloStock.Actualizar(id, model);
                return Ok(new
                {
                    data = output,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }

        [HttpGet("buscar/{parametros}")]
        public async Task<ActionResult> ListarPorParametros(string parametros)
        {
            try
            {
                var Articulos = await _ArticuloStock.ListarPorParametros(parametros);
                return Ok(new
                {
                    data = Articulos,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }

        [HttpGet("buscar-por-sede/{idSede}/{parametros}")]
        public async Task<ActionResult> ListarPorSedeyParametros(int idSede, string parametros)
        {
            try
            {
                var Articulos = await _ArticuloStock.ListarPorSedeyParametros(idSede, parametros);
                return Ok(new
                {
                    data = Articulos,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }


        [HttpGet("buscar-movimientos/{idArticuloStock}/{fechaDesde}/{fechaHasta}")]
        public async Task<ActionResult> BuscarMovimientos(int idArticuloStock, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                var movimientos = await _ArticuloStock.BuscarMovimientos(idArticuloStock, fechaDesde, fechaHasta);
                return Ok(new
                {
                    data = movimientos,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }

        [HttpGet("consultar-movimientos/{bloque}/{idSede}/{idArticulo}/{fechaDesde}/{fechaHasta}")]
        public async Task<ActionResult> ConsultarMovimientos(int bloque, int idSede, int idArticulo, string fechaDesde, string fechaHasta)
        {
            try
            {
                var movimientos = await _ArticuloStock.ConsultarMovimientos(bloque, idSede, idArticulo, fechaDesde, fechaHasta);
                return Ok(new
                {
                    data = movimientos,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }

        [HttpGet("buscar-por-articulo/{idSede}/{idArticulo}")]
        public async Task<ActionResult> ListarPorArticuloySede(int idSede, int idArticulo)
        {
            try
            {
                var Articulos = await _ArticuloStock.ListarPorSedeyArticulo(idSede, idArticulo);
                return Ok(new
                {
                    data = Articulos,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }

    }
}
