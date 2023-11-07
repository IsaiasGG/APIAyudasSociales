using APIAyudasSociales.Models;
using APIAyudasSociales.Models.Dto;
using APIAyudasSociales.Services.AyudasSociales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace APIAyudasSociales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AyudasSocialesController : ControllerBase
    {
        private readonly IAyudasSocialesService _ayudasSociales;

        public AyudasSocialesController(IAyudasSocialesService ayudasSociales)
        {
            _ayudasSociales = ayudasSociales;
        }

        [HttpGet]
        [Route("ObtenerAyudasPorUsuario")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> ObtenerAyudasPorUsuario(int UsuarioId)
        {
            List<Asignaciones> asignaciones = new List<Asignaciones>();
            try
            {
                asignaciones = await _ayudasSociales.ObtenerAyudasPorUsuario(UsuarioId);

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = asignaciones });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = "" });
            }
        }

        [HttpPost]
        [Route("GuardarAyudaSocial")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GuardarAyudaSocial(AyudasSocialesDto ayudasSocial)
        {
            if (ayudasSocial == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _ayudasSociales.GuardarAyudaSocial(ayudasSocial);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Guardado" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { mensaje = error.Message });
            }
        }

        [HttpPost]
        [Route("GuardarAsignaciones")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GuardarAsignaciones(AsignacionesDto asignaciones)
        {
            if (asignaciones == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _ayudasSociales.GuardarAsignaciones(asignaciones);
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Guardado" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { mensaje = error.Message });
            }
        }


    }
}
