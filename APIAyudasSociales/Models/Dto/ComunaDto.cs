using System;
using System.Collections.Generic;
using APIAyudasSociales.Models.Dto;

namespace APIAyudasSociales.Models.Dto;

public partial class ComunaDto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int RegionId { get; set; }
}
