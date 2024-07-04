using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piloto_Buscarini.Models;

public partial class Piloto
{
    [Key]
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public int? HorasVuelo { get; set; }

    public int? IdSexo { get; set; }

    public int? IdNacionalidad { get; set; }

    [ForeignKey("IdNacionalidad")]
    public virtual Nacionalidad? IdNacionalidadNavigation { get; set; }

    [ForeignKey("IdSexo")]
    public virtual Sexo? IdSexoNavigation { get; set; }
}
