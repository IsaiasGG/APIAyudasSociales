using APIAyudasSociales.Models;
using APIAyudasSociales.Models.Dto;
using APIAyudasSociales.Services.Autenticacion;
using APIAyudasSociales.Services.Localizacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace APIAyudasSociales.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizacionController : ControllerBase
    {
        private readonly ILocalizacionService _localizacionService;

        public LocalizacionController(ILocalizacionService localizacionService)
        {
            _localizacionService = localizacionService;
        }

        /// <summary>
        /// Pais
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerPaisLista")]
        public async Task<IActionResult> ObtenerPaisList()
        {
            List<Pais> Pais = new List<Pais>();
            try
            {
                var usuario = HttpContext.Session.GetString("Email");

                Pais = await _localizacionService.GetPaisList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = Pais });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = "" });
            }
        }

        [HttpPost]
        [Route("GuardarPais")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GuardarPais(PaisDto pais)
        {
            if (pais == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _localizacionService.GuardarPais(pais);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Guardado"});
            }
            catch(Exception error)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { mensaje = error.Message});
            }
        }

        [HttpPut]
        [Route("ActualizarPais")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> ActualizarPais(PaisDto pais)
        {
            if (pais == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _localizacionService.ActualizarPais(pais);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Actualizado" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { mensaje = error.Message });
            }
        }

        [HttpDelete]
        [Route("EliminarPais")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> EliminarPais(int PaisId)
        {
            try
            {
                var result = await _localizacionService.BorrarPais(PaisId);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Eliminado" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { mensaje = error.Message });
            }
        }


        /// <summary>
        /// Region
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerRegionLista")]
        public async Task<IActionResult> ObtenerRegionList()
        {
            List<Region> region = new List<Region>();
            try
            {
                region = await _localizacionService.GetRegionList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = region });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = "" });
            }
        }

        [HttpPost]
        [Route("GuardarRegion")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GuardarRegion(RegionDto region)
        {
            if (region == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _localizacionService.GuardarRegion(region);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Guardado" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { mensaje = error.Message });
            }
        }

        [HttpPut]
        [Route("ActualizarRegion")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> ActualizarRegion(RegionDto region)
        {
            if (region == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _localizacionService.ActualizarRegion(region);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Actualizado" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { mensaje = error.Message });
            }
        }

        [HttpDelete]
        [Route("EliminarRegion")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> EliminarRegion(int RegionId)
        {
            try
            {
                var result = await _localizacionService.BorrarRegion(RegionId);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Eliminado" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { mensaje = error.Message });
            }
        }

        /// <summary>
        /// Comuna
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerComunaLista")]
        public async Task<IActionResult> ObtenerComunaList()
        {
            List<Comuna> comuna = new List<Comuna>();
            try
            {
                comuna = await _localizacionService.GetComunaList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = comuna });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = "" });
            }
        }

        [HttpPost]
        [Route("GuardarComuna")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GuardarComuna(ComunaDto comuna)
        {
            if (comuna == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _localizacionService.GuardarComuna(comuna);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Guardado" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { mensaje = error.Message });
            }
        }

        [HttpPut]
        [Route("ActualizarComuna")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> ActualizarComuna(ComunaDto comuna)
        {
            if (comuna == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _localizacionService.ActualizarComuna(comuna);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Actualizado" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { mensaje = error.Message });
            }
        }

        [HttpDelete]
        [Route("EliminarComuna")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> EliminarComuna(int ComunaId)
        {
            try
            {
                var result = await _localizacionService.BorrarComuna(ComunaId);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Eliminado" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { mensaje = error.Message });
            }
        }


    }
}
