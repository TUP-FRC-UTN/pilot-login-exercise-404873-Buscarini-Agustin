using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Piloto_Buscarini.Models;

public partial class Nacionalidad
{
    [Key]
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Piloto> Pilotos { get; set; } = new List<Piloto>();
}
