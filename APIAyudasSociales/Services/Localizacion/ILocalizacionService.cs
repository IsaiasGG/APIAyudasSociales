using APIAyudasSociales.Models;
using APIAyudasSociales.Models.Dto;

namespace APIAyudasSociales.Services.Localizacion
{
    public interface ILocalizacionService
    {
        /// <summary>
        /// Pais, Region y Comuna Lista
        /// </summary>
        /// <returns></returns>
        Task<List<Pais>> GetPaisList();
        Task<List<Region>> GetRegionList();
        Task<List<Comuna>> GetComunaList();

        /// <summary>
        /// Pais Metodos CRUD
        /// </summary>
        /// <param name="modelPais"></param>
        /// <returns></returns>
        Task<int> GuardarPais(PaisDto modelPais);
        Task<int> ActualizarPais(PaisDto modelPais);
        Task<int> BorrarPais(int PaisId);

        /// <summary>
        /// Region Metodos CRUD
        /// </summary>
        /// <param name="modelRegion"></param>
        /// <returns></returns>
        Task<int> GuardarRegion(RegionDto modelRegion);
        Task<int> ActualizarRegion(RegionDto modelRegion);
        Task<int> BorrarRegion(int RegionId);

        /// <summary>
        /// Comuna Metodos CRUD
        /// </summary>
        /// <param name="modelComuna"></param>
        /// <returns></returns>
        Task<int> GuardarComuna(ComunaDto modelComuna);
        Task<int> ActualizarComuna(ComunaDto modelComuna);
        Task<int> BorrarComuna(int ComunaId);
    }
}
