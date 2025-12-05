using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanPkApp.Data;
using PlanPkApp.Models;

namespace PlanPkApp.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var allPlans = await _context.PlanPks
            .AsNoTracking()
            .OrderBy(p => p.Number)
            .ToListAsync();

        var lookup = allPlans.ToLookup(p => string.IsNullOrWhiteSpace(p.ParentId) ? null : p.ParentId);
        var tree = BuildTree(lookup, null);

        return View(tree);
    }

    private static List<PlanPkTreeItem> BuildTree(ILookup<string?, PlanPk> lookup, string? parentId)
    {
        return lookup[parentId]
            .Select(plan => new PlanPkTreeItem
            {
                Item = plan,
                Children = BuildTree(lookup, plan.Id)
            })
            .ToList();
    }
}
