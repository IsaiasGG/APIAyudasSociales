using APIAyudasSociales.Models;
using APIAyudasSociales.Models.Dto;

namespace APIAyudasSociales.Services.AyudasSociales
{
    public interface IAyudasSocialesService
    {
        Task<List<AyudasSocialesDto>> GetAyudaSocialesList();
        Task<List<Asignaciones>> ObtenerAyudasPorUsuario(int UsuarioId);
        Task<int> GuardarAyudaSocial(AyudasSocialesDto modelAyudaSocial);
        Task<int> GuardarAsignaciones(AsignacionesDto modelAsignaciones);
        Task<int> ActualizarAsignaciones(AsignacionesDto modelAsignaciones);
        Task<int> BorrarAsignaciones(int AsignacionesId);
    }
}
