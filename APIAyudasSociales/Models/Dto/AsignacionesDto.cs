using System;
using System.Collections.Generic;
using APIAyudasSociales.Models.Dto;

namespace APIAyudasSociales.Models.Dto;

public partial class AsignacionesDto
{
    public int Id { get; set; }

    public int AyudaSocialId { get; set; }

    public int UsuarioId { get; set; }

    public int Anio { get; set; }

    public bool? Activo { get; set; }
}
