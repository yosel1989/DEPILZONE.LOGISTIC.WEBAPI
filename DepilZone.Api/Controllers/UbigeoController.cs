using System;
using System.Threading.Tasks;
using DepilZone.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbigeoController : ControllerBase
    {
        private readonly IUbigeoApp _Ubigeo;

        public UbigeoController(IUbigeoApp UbigeoApp)
        {
            this._Ubigeo = UbigeoApp;
        }

        [HttpGet("departamento")]
        public async Task<ActionResult> ListarDepartamentos()
        {
            try
            {
                var Ubigeoes = await _Ubigeo.Departamentos();
                return Ok(new
                {
                    data = Ubigeoes,
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

        [HttpGet("departamento/{idDepartamento}/ciudades")]
        public async Task<ActionResult> ListarCiudades(string idDepartamento)
        {
            try
            {
                var ciudades = await _Ubigeo.Ciudades(idDepartamento);
                return Ok(new
                {
                    data = ciudades,
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

        [HttpGet("departamento/{idDepartamento}/{idCiudad}/distritos")]
        public async Task<ActionResult> ListarDistritos(string idDepartamento, string idCiudad)
        {
            try
            {
                var ciudades = await _Ubigeo.Distritos(idDepartamento, idCiudad);
                return Ok(new
                {
                    data = ciudades,
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
