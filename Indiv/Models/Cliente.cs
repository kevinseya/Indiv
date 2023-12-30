using System;
using System.Collections.Generic;

namespace Indiv.Models;

public partial class Cliente
{
    public int Idcliente { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? Identificacion { get; set; }

    public virtual Domicilio? Domicilio { get; set; }
}
