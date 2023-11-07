using System;
using System.Collections.Generic;

namespace APIAyudasSociales.Models.Dto;

public partial class AyudasSocialesDto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int RegionId { get; set; }

    public int ComunaId { get; set; }

    public virtual ICollection<Asignaciones> Asignaciones { get; set; } = new List<Asignaciones>();

    public virtual Comuna Comuna { get; set; } = null!;
    public virtual Region Region { get; set; } = null!;
}
