using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sigapsWeb.Models;

public partial class IsSegAlertas
{
    public string? Id { get; set; }
    public string? IdIntegrante { get; set; }

    public string? IdMunicipio { get; set; }

    public int? IdUserSistem { get; set; }
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Required]
    public DateOnly FechaSeguimiento { get; set; }
    [Required]
    public string Alerta { get; set; }
    [Required]
    public string Plan { get; set; }
    [Required]
    public string Estado { get; set; }
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Required]
    public DateOnly FechaIntervencion { get; set; }
    public string? DesIntervencion { get; set; }

    public virtual Integrante? IdIntegranteNavigation { get; set; }
}
