namespace APIAyudasSociales.Models
{
    public class UserActionLog
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }
    }
}
