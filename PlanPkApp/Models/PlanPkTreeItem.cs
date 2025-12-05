namespace PlanPkApp.Models;

public class PlanPkTreeItem
{
    public required PlanPk Item { get; set; }

    public List<PlanPkTreeItem> Children { get; set; } = new();
}
