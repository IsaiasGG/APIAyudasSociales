using System;
using System.Collections.Generic;
using APIAyudasSociales.Models.Dto;

namespace APIAyudasSociales.Models.Dto;

public partial class RegionDto
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public int PaisId { get; set; }
}
