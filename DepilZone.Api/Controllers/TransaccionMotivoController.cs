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
    public class TransaccionMotivoController : ControllerBase
    {
        private readonly ITransaccionMotivoApp _TransaccionMotivo;

        public TransaccionMotivoController(ITransaccionMotivoApp TransaccionMotivoApp)
        {
            this._TransaccionMotivo = TransaccionMotivoApp;
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var TransaccionMotivos = await _TransaccionMotivo.Listar();
                return Ok(new
                {
                    data = TransaccionMotivos,
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
