using System;
using System.Collections.Generic;

namespace ProyectoCrud.DAL.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? Edad { get; set; }

    public string? Email { get; set; }

    public decimal? Salario { get; set; }

    public DateTime? Fecha { get; set; }
}
