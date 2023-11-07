using APIAyudasSociales.Models;
using APIAyudasSociales.Models.Dto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace APIAyudasSociales.Services.AyudasSociales
{
    public class AyudasSocialesService : IAyudasSocialesService
    {
        private readonly DbAPIAYUDASSOCIALESContext _dbContext;
        public AyudasSocialesService(DbAPIAYUDASSOCIALESContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> ActualizarAsignaciones(AsignacionesDto modelAsignaciones)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@Id", modelAsignaciones.Id),
                new SqlParameter("@AyudaSocialId", modelAsignaciones.AyudaSocialId),
                new SqlParameter("@UsuarioId", modelAsignaciones.UsuarioId),
                new SqlParameter("@Anio", modelAsignaciones.Anio),
                new SqlParameter("@Activo", modelAsignaciones.Activo),
                new SqlParameter("@Accion", "Actualizar")
            };
            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec SP_Asignaciones @Id, @AyudaSocialId, @UsuarioId, @Anio, @Activo, @Accion ", parameter.ToArray()));

            return result;
        }

        public async Task<int> BorrarAsignaciones(int AsignacionesId)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@Id", AsignacionesId),
                new SqlParameter("@AyudaSocialId", ""),
                new SqlParameter("@UsuarioId", ""),
                new SqlParameter("@Anio", ""),
                new SqlParameter("@Activo", ""),
                new SqlParameter("@Accion", "Eliminar")
            };
            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec SP_Asignaciones @Id, @AyudaSocialId, @UsuarioId, @Anio, @Activo, @Accion", parameter.ToArray()));

            return result;
        }

        public async Task<List<AyudasSocialesDto>> GetAyudaSocialesList()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GuardarAsignaciones(AsignacionesDto modelAsignaciones)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@Id", ""),
                new SqlParameter("@AyudaSocialId", modelAsignaciones.AyudaSocialId),
                new SqlParameter("@UsuarioId", modelAsignaciones.UsuarioId),
                new SqlParameter("@Anio", modelAsignaciones.Anio),
                new SqlParameter("@Activo", modelAsignaciones.Activo),
                new SqlParameter("@Accion", "Guardar")
            };
            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec SP_Asignaciones @Id,@AyudaSocialId, @UsuarioId, @Anio, @Activo, @Accion", parameter.ToArray()));

            return result;
        }

        public async Task<int> GuardarAyudaSocial(AyudasSocialesDto modelAyudaSocial)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@Id", modelAyudaSocial.Id),
                new SqlParameter("@Nombre", modelAyudaSocial.Nombre),
                new SqlParameter("@RegionId", modelAyudaSocial.RegionId),
                new SqlParameter("@ComunaId", modelAyudaSocial.ComunaId),
                new SqlParameter("@Accion", "Guardar")
            };
            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec SP_AyudasSociales @Id, @Nombre, @RegionId, @ComunaId, @Accion", parameter.ToArray()));

            return result;
        }

        public async Task<List<Asignaciones>> ObtenerAyudasPorUsuario(int UsuarioId)
        {
            return await _dbContext.Asignaciones.Where(a => a.UsuarioId == UsuarioId).ToListAsync();
        }
    }
}
