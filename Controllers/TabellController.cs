using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using allsvenskanMVC.Models;
using Allsvenskan;

namespace allsvenskanMVC.Controllers;
public class TabellController : Controller
{
    private readonly ILogger<TabellController> _logger;

    public TabellController(ILogger<TabellController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        Serie allsvenskan = new Serie();
        allsvenskan.averageOpponent(3);
        allsvenskan.GuessTheFinish(4);
        return View(allsvenskan);
    }

}
