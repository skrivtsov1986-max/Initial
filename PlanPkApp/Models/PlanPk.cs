using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanPkApp.Models;

public class PlanPk
{
    [Key]
    [MaxLength(64)]
    public string Id { get; set; } = default!;

    [MaxLength(64)]
    public string? ParentId { get; set; }

    [MaxLength(50)]
    public string Number { get; set; } = string.Empty;

    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [Column(TypeName = "float")]
    public double PlanHour { get; set; }

    [Column(TypeName = "float")]
    public double FactHour { get; set; }

    [DataType(DataType.Date)]
    public DateTime TermDate { get; set; }
}
