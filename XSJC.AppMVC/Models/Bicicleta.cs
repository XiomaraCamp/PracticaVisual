using System;
using System.Collections.Generic;

namespace XSJC.AppMVC.Models;

public partial class Bicicleta
{
    public int Id { get; set; }

    public string Modelo { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string DescripcionDelProblema { get; set; } = null!;
}
