using System;
using System.Collections.Generic;

namespace tarea1progra2.Models;

public partial class Puesto
{
    public int IdPuestos { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
