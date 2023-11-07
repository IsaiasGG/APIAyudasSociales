using APIAyudasSociales.Models;
using APIAyudasSociales.Services.Autenticacion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using APIAyudasSociales.Services;
using Microsoft.AspNetCore.Cors;
using APIAyudasSociales.Models.Dto;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace APIAyudasSociales.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAutenticacionService _autenticacionService;
        private readonly DbAPIAYUDASSOCIALESContext _dbContext;
        private readonly string secretKey;


        public AutenticacionController(IConfiguration configuration, IAutenticacionService autenticacionService,DbAPIAYUDASSOCIALESContext dbContext)
        {
            _configuration = configuration;
            _autenticacionService = autenticacionService;
            _dbContext = dbContext;
            secretKey = configuration.GetSection("settings").GetSection("secretKey").ToString();
            
        }


        [HttpPost]
        [Route("Registrar")]
        public async Task<ActionResult<Usuario>> Registrar(UsuarioDto model)
        {
            try
            {             
                model.Password = Password.Encriptar(model.Password);

                var result = await _autenticacionService.RegistrarUsuario(model);

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = result });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = "" });
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<string>> Login(LoginDto model)
        {
            var usuario = _dbContext.Usuarios.Where(m => m.Email == model.Email).FirstOrDefault();

            usuario.Password = Password.DesEncriptar(usuario.Password);

            var Rol = _autenticacionService.ObtenerRol(model.Email);
            var UsuarioRol = Rol.FirstOrDefault();

            if (usuario.Email != model.Email)
            {
                return BadRequest("Usuario no encontrado.");
            }

            if (usuario.Password != model.Password)
            {
                return BadRequest("Contraseña incorrecta.");
            }

            try 
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);


                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.Role, UsuarioRol.Role));
                claims.AddClaim(new Claim(ClaimTypes.Name, usuario.Email));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string tokencreado = tokenHandler.WriteToken(tokenConfig);




                return StatusCode(StatusCodes.Status200OK, new { token = tokencreado });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { mensaje = error.Message ,token = "" });
            }
        }

        [HttpGet]
        [Route("ListarUsuario")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> ListarUsuario()
        {
            List<Usuario> usuario = new List<Usuario>();
            try
            {
                usuario = await _autenticacionService.ListarUsuario();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = usuario });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = "" });
            }
        }
    }
}
