using System;
using System.Collections.Generic;
using APIAyudasSociales.Models.Dto;

namespace APIAyudasSociales.Models;

public partial class Asignaciones
{
    public int Id { get; set; }

    public int AyudaSocialId { get; set; }

    public int UsuarioId { get; set; }

    public int Anio { get; set; }

    public bool? Activo { get; set; }

    public virtual AyudasSocialesDto AyudaSocial { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
