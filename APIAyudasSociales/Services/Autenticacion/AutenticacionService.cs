using APIAyudasSociales.Models;
using APIAyudasSociales.Models.Dto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace APIAyudasSociales.Services.Autenticacion
{
    public class AutenticacionService : IAutenticacionService
    {
        private readonly DbAPIAYUDASSOCIALESContext _dbContext;
        private readonly string Con;
        public AutenticacionService(DbAPIAYUDASSOCIALESContext dbContext,IConfiguration config)
        {
            _dbContext = dbContext;
            Con = config.GetConnectionString("DbApiAyudasSocialesCon");
        }

        public async Task<List<Usuario>> ListarUsuario()
        {
           return await _dbContext.Usuarios.ToListAsync();
        }

        public List<UsuarioRolDto> ObtenerRol(string Email)
        {
            List<UsuarioRolDto> usuarioRolLista = new List<UsuarioRolDto>();

            using (var conexion = new SqlConnection(Con))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_UsuarioLista", conexion);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Email", Email));
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        usuarioRolLista.Add(new UsuarioRolDto
                        {
                            Role = rd["Role"].ToString()
                        });
                    }

                }
            }


            return usuarioRolLista;

        }

        public async Task<int> RegistrarUsuario(UsuarioDto modelUsuario)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@Id", modelUsuario.Id),
                new SqlParameter("@Email", modelUsuario.Email),
                new SqlParameter("@Password", modelUsuario.Password),
                new SqlParameter("@RolId", modelUsuario.RolId),
                new SqlParameter("@Accion", "Guardar")
            };
            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec SP_Usuario @Id, @Email, @Password, @RolId, @Accion", parameter.ToArray()));

            return result;
        }


    }
}
