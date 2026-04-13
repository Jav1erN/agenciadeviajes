using System;
using System.Collections.Generic;

namespace agenciadeviajes.Models;

public partial class Reserva
{
    public int Id { get; set; }

    public int? Clienteid { get; set; }

    public int? Paqueteid { get; set; }

    public DateTime? Fechareserva { get; set; }

    public string? Estadopago { get; set; }

    public decimal Montototal { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Paqueteturistico? Paquete { get; set; }
}
