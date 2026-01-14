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
    public class TransaccionTipoController : ControllerBase
    {
        private readonly ITransaccionTipoApp _TransaccionTipo;

        public TransaccionTipoController(ITransaccionTipoApp TransaccionTipoApp)
        {
            this._TransaccionTipo = TransaccionTipoApp;
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var TransaccionTipoes = await _TransaccionTipo.Listar();
                return Ok(new
                {
                    data = TransaccionTipoes,
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
        public async Task<ActionResult> Registrar(TransaccionTipoDTO model)
        {
            try
            {
                var output = await _TransaccionTipo.Registrar(model);
                return Ok(new
                {
                    data = output,
                    message = "",
                    status = StatusCodes.Status201Created
                });
            }
            catch (AlertException ex)
            {
                return Ok(new
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
        public async Task<ActionResult> Actualizar(int id, TransaccionTipoDTO model)
        {
            try
            {
                var output = await _TransaccionTipo.Actualizar(id, model);
                return Ok(new
                {
                    data = output,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
            {
                return Ok(new
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
