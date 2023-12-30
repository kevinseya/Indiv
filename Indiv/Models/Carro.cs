using System;
using System.Collections.Generic;

namespace Indiv.Models;

public partial class Carro
{
    public int Idcarro { get; set; }

    public string? Modelo { get; set; }

    public int? Aniofabricacion { get; set; }

    public int? Colorid { get; set; }

    public virtual Colore? Color { get; set; }
}
