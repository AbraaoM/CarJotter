using CarJotter.Core.Entities;

namespace CarJotter.Application.DTOs;
public class ProcedureDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public virtual required CarEntity Car { get; set; }
}

