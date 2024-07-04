using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Piloto_Buscarini.Models;

public partial class Sexo
{
    [Key]
    public int Id { get; set; }

    [Column("Sexo")]
    public string Sexo1 { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Piloto> Pilotos { get; set; } = new List<Piloto>();
}
