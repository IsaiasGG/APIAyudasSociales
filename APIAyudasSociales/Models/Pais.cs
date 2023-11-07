using System;
using System.Collections.Generic;

namespace APIAyudasSociales.Models;

public partial class Pais
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Region> Regiones { get; set; } = new List<Region>();
}
