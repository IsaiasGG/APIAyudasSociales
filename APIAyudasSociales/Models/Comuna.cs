using System;
using System.Collections.Generic;
using APIAyudasSociales.Models.Dto;

namespace APIAyudasSociales.Models;

public partial class Comuna
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int RegionId { get; set; }

    public virtual ICollection<AyudasSocialesDto> AyudasSociales { get; set; } = new List<AyudasSocialesDto>();

    public virtual Region Region { get; set; } = null!;
}
