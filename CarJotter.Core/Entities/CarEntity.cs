using System.ComponentModel.DataAnnotations;

namespace CarJotter.Core.Entities;

public class CarEntity
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Brand { get; set; } = string.Empty;
    [MaxLength(50)]
    public string Model { get; set; } = string.Empty;
    [Required]
    [MaxLength(50)]
    public string LicensePlate { get; set; } = string.Empty;
    public int Year { get; set; }
}

