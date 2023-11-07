using System;
using System.Collections.Generic;

namespace APIAyudasSociales.Models.Dto;

public partial class UsuarioDto
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int RolId { get; set; }

}
