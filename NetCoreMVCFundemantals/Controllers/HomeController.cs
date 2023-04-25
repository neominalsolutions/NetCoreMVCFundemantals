using Microsoft.AspNetCore.Mvc;
using NetCoreMVCFundemantals.Models;
using System.Diagnostics;

namespace NetCoreMVCFundemantals.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      //var orderService = new OrderService(new TurkcelEmailService());
      //orderService.SubmitOrder(model);
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}