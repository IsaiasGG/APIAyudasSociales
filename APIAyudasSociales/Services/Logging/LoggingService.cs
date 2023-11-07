using APIAyudasSociales.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace APIAyudasSociales.Services.Logging
{
    public class LoggingService : ILoggingServices
    {
        private readonly DbAPIAYUDASSOCIALESContext _dbContext;
        private readonly string Con;
        public LoggingService(DbAPIAYUDASSOCIALESContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            Con = config.GetConnectionString("DbApiAyudasSocialesCon");
        }

        public Task<int> GuardarLog(string Accion, string Email)
        {
            // Registra la acción del usuario en la base de datos
            var userActionLog = new UserActionLog
            {
                Email = Email,
                Accion = Accion,
                Fecha = DateTime.Now
            };

            _dbContext.UserActionLogs.Add(userActionLog);
            _dbContext.SaveChanges();

            return Task.FromResult(0);
        }
    }
}
