namespace APIAyudasSociales.Models.Dto
{
    public class AyudaSocialDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public int RegionId { get; set; }

        public int ComunaId { get; set; }
    }
}
