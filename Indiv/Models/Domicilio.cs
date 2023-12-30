using System;
using System.Collections.Generic;

namespace Indiv.Models;

public partial class Domicilio
{
    public int Iddomicilio { get; set; }

    public string? Calle { get; set; }

    public string? Numerocasa { get; set; }

    public int? Clientesid { get; set; }

    public virtual Cliente? Clientes { get; set; }
}
