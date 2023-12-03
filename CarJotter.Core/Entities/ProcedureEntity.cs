using System.ComponentModel.DataAnnotations;

namespace CarJotter.Core.Entities;

public class ProcedureEntity
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;
    [MaxLength(400)]
    public string Description { get; set; } = string.Empty;
    [Required]
    public CarEntity Car { get; set; }
}

