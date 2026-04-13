using System;
using System.Collections.Generic;

namespace agenciadeviajes.Models;

public partial class Itinerario
{
    public int Id { get; set; }

    public int? Paqueteid { get; set; }

    public int Dia { get; set; }

    public string Actividad { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual Paqueteturistico? Paquete { get; set; }
}
