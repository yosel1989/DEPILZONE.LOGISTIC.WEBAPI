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
    public class ArticuloProveedorController : ControllerBase
    {
        private readonly IArticuloProveedorApp _ArticuloProveedor;

        public ArticuloProveedorController(IArticuloProveedorApp ArticuloProveedorApp)
        {
            this._ArticuloProveedor = ArticuloProveedorApp;
        }

        [HttpPost]
        public async Task<ActionResult> Registrar(ArticuloDTO model)
        {
            try
            {
                var output = await _ArticuloProveedor.Registrar(model);
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

    }
}
