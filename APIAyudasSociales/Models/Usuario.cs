using System;
using System.Collections.Generic;

namespace APIAyudasSociales.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Asignaciones> Asignaciones { get; set; } = new List<Asignaciones>();

    public virtual ICollection<Rol> Roles { get; set; } = new List<Rol>();
}
