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
    public class OrdenCompraController : ControllerBase
    {
        private readonly IOrdenCompraApp _OrdenCompra;

        public OrdenCompraController(IOrdenCompraApp OrdenCompraApp)
        {
            this._OrdenCompra = OrdenCompraApp;
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var OrdenCompraes = await _OrdenCompra.Listar();
                return Ok(new
                {
                    data = OrdenCompraes,
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
        public async Task<ActionResult> Registrar(OrdenCompraDTO model)
        {
            try
            {
                var output = await _OrdenCompra.Registrar(model);
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

        [HttpGet("{id}")]
        public async Task<ActionResult> Buscar(int id)
        {
            try
            {
                var ordenCompra = await _OrdenCompra.Buscar(id);
                return Ok(new
                {
                    data = ordenCompra,
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
