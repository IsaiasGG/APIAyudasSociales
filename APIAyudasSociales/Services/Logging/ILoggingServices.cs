namespace APIAyudasSociales.Services.Logging
{
    public interface ILoggingServices
    {
        Task<int> GuardarLog(string Accion, string Email);
    }
}
