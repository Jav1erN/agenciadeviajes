using System;
using System.Collections.Generic;

namespace agenciadeviajes.Models;

public partial class Servicio
{
    public int Id { get; set; }

    public int? Proveedorid { get; set; }

    public string Nombreservicio { get; set; } = null!;

    public decimal Costo { get; set; }

    public bool? Disponibilidad { get; set; }

    public virtual Proveedor? Proveedor { get; set; }
}
