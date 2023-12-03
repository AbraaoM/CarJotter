namespace CarJotter.Application.DTOs;
public class CarDTO
{
    public int Id { get; set; }
    public string Brand { get; set; } = default!;
    public string Model { get; set; } = default!;
    public string LicensePlate { get; set; } = default!;
    public int Year { get; set; }
}

