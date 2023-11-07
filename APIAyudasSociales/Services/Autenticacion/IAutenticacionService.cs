using APIAyudasSociales.Models;
using APIAyudasSociales.Models.Dto;

namespace APIAyudasSociales.Services.Autenticacion
{
    public interface IAutenticacionService
    {
        Task<int> RegistrarUsuario(UsuarioDto modelUsuario);
        List<UsuarioRolDto> ObtenerRol(string Email);
        Task<List<Usuario>> ListarUsuario();
    }
}
