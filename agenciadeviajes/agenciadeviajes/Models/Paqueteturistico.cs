using System;
using System.Collections.Generic;

namespace agenciadeviajes.Models;

public partial class Paqueteturistico
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Preciobase { get; set; }

    public int Capacidadmaxima { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Itinerario> Itinerarios { get; set; } = new List<Itinerario>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
