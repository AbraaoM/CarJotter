namespace CarJotter.Application.Commands;
public class CarCreateCommand
{
    public string Brand { get; set; } = default!;
    public string Model { get; set; } = default!;
    public string LicensePlate { get; set; } = default!;
    public int Year { get; set; }
}
