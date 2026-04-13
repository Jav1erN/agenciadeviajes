using System;
using System.Collections.Generic;

namespace agenciadeviajes.Models;

public partial class Proveedor
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string? Contacto { get; set; }

    public decimal? Calificacionpromedio { get; set; }

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
