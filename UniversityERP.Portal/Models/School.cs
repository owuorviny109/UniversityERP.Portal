using System.ComponentModel.DataAnnotations;

namespace UniversityERP.Portal.Models;

public class School
{
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Code { get; set; } = string.Empty;

    [Required, MaxLength(150)]
    public string Name { get; set; } = string.Empty;
}
