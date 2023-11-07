using APIAyudasSociales.Models;
using APIAyudasSociales.Models.Dto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace APIAyudasSociales.Services.Localizacion
{
    public  class LocalizacionService : ILocalizacionService
    {
        private readonly DbAPIAYUDASSOCIALESContext _dbContext;
        public LocalizacionService(DbAPIAYUDASSOCIALESContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async  Task<int> ActualizarComuna(ComunaDto modelComuna)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@Id", modelComuna.Id),
                new SqlParameter("@Nombre", modelComuna.Nombre),
                new SqlParameter("@RegionId", modelComuna.RegionId),
                new SqlParameter("@Accion", "Actualizar")
            };
            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec SP_Comuna @Id, @Nombre, @RegionId, @Accion", parameter.ToArray()));

            return result;
        }

        public async Task<int> ActualizarPais(PaisDto modelPais)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@Id", modelPais.Id),
                new SqlParameter("@Nombre", modelPais.Nombre),
                new SqlParameter("@Accion", "Actualizar")
            };
            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec SP_Pais @Id, @Nombre, @Accion", parameter.ToArray()));

            return result;
        }

        public async Task<int> ActualizarRegion(RegionDto modelRegion)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@Id", modelRegion.Id),
                new SqlParameter("@Nombre", modelRegion.Nombre),
                new SqlParameter("@PaisId", modelRegion.PaisId),
                new SqlParameter("@Accion", "Actualizar")
            };
            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec SP_Region @Id, @Nombre, @PaisId, @Accion", parameter.ToArray()));

            return result;
        }

        public async Task<int> BorrarComuna(int ComunaId)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@Id", ComunaId),
                new SqlParameter("@Nombre", ""),
                new SqlParameter("@RegionId", ""),
                new SqlParameter("@Accion", "Eliminar")
            };
            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec SP_Comuna @Id, @Nombre, @RegionId, @Accion", parameter.ToArray()));

            return result;
        }

        public async Task<int> BorrarPais(int PaisId)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@Id", PaisId),
                new SqlParameter("@Nombre", ""),
                new SqlParameter("@Accion", "Eliminar")
            };
            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec SP_Pais @Id, @Nombre, @Accion", parameter.ToArray()));

            return result;
        }

        public async Task<int> BorrarRegion(int RegionId)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@Id", RegionId),
                new SqlParameter("@Nombre", ""),
                new SqlParameter("@PaisId", ""),
                new SqlParameter("@Accion", "Eliminar")
            };
            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec SP_Region @Id, @Nombre, @PaisId, @Accion", parameter.ToArray()));

            return result;
        }

        public async Task<List<Comuna>> GetComunaList()
        {
            return await _dbContext.Comunas.ToListAsync();
        }

        public async Task<List<Pais>> GetPaisList()
        {
            return await _dbContext.Paises.ToListAsync();
        }

        public async Task<List<Region>> GetRegionList()
        {
            return await _dbContext.Regiones.ToListAsync();
        }

        public async Task<int> GuardarComuna(ComunaDto modelComuna)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@Id", modelComuna.Id),
                new SqlParameter("@Nombre", modelComuna.Nombre),
                new SqlParameter("@RegionId", modelComuna.RegionId),
                new SqlParameter("@Accion", "Guardar")
            };
            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec SP_Comuna @Id, @Nombre, @RegionId, @Accion", parameter.ToArray()));

            return result;
        }

        public async Task<int> GuardarPais(PaisDto modelPais)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@Id", modelPais.Id),
                new SqlParameter("@Nombre", modelPais.Nombre),
                new SqlParameter("@Accion", "Guardar")
            };
            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec SP_Pais @Id, @Nombre, @Accion", parameter.ToArray()));

            return result;
        }

        public async Task<int> GuardarRegion(RegionDto modelRegion)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@Id", modelRegion.Id),
                new SqlParameter("@Nombre", modelRegion.Nombre),
                new SqlParameter("@PaisId", modelRegion.PaisId),
                new SqlParameter("@Accion", "Guardar")
            };
            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec SP_Region @Id, @Nombre, @PaisId, @Accion", parameter.ToArray()));

            return result;
        }
    }
}
