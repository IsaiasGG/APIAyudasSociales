using System;
using System.Collections.Generic;
using APIAyudasSociales.Models.Dto;

namespace APIAyudasSociales.Models;

public partial class Region
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int PaisId { get; set; }

    public virtual ICollection<Comuna> Comunas { get; set; } = new List<Comuna>();
    public virtual ICollection<AyudasSocialesDto> AyudasSociales { get; set; } = new List<AyudasSocialesDto>();

    public virtual Pais Pais { get; set; } = null!;
}
