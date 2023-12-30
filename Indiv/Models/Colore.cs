using System;
using System.Collections.Generic;

namespace Indiv.Models;

public partial class Colore
{
    public int Idcolor { get; set; }

    public string? Color { get; set; }

    public virtual ICollection<Carro> Carros { get; set; } = new List<Carro>();
}
