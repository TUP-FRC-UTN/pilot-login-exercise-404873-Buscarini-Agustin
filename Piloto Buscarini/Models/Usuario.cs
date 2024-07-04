using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piloto_Buscarini.Models;

public partial class Usuario
{
    [Key]
    public int Id { get; set; }

    [Column("usuario")]
    public string Usuario1 { get; set; } = null!;

    public string Contraseña { get; set; } = null!;
}
