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
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorApp _Proveedor;

        public ProveedorController(IProveedorApp ProveedorApp)
        {
            this._Proveedor = ProveedorApp;
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var proveedores = await _Proveedor.Listar();
                return Ok(new
                {
                    data = proveedores,
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
        public async Task<ActionResult> Registrar(ProveedorDTO model)
        {
            try
            {
                var proveedores = await _Proveedor.Registrar(model);
                return Ok(new
                {
                    data = proveedores,
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
        public async Task<ActionResult> Modificar(int id, ProveedorDTO model)
        {
            try
            {
                var proveedores = await _Proveedor.Modificar(id, model);
                return Ok(new
                {
                    data = proveedores,
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
                var Proveedores = await _Proveedor.ListarPorParametros(parametros);
                return Ok(new
                {
                    data = Proveedores,
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


        // RELATIONSHIP
        [HttpGet("articulo/{idArticulo}")]
        public async Task<ActionResult> ListarPorArticulo(int idArticulo)
        {
            try
            {
                var proveedores = await _Proveedor.ListarPorArticulo(idArticulo);
                return Ok(new
                {
                    data = proveedores,
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
