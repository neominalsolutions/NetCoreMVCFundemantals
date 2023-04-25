using Microsoft.AspNetCore.Mvc;
using NetCoreMVCFundemantals.DIServices;
using NetCoreMVCFundemantals.Models;

namespace NetCoreMVCFundemantals.Controllers
{
  // order işlemlerini yeni arayüzler üzerinden yöneteceğimiz bir controller açtık. tüm sipariş arayüzlerinden burası sorumlu, sipariş ile ilgili bir revize olduğundan sadece bu sınıfta bir operasyon yapıcaz. Single Responsibilty
  public class OrderController : Controller
  {
    private IOrderService orderService;

    public OrderController(IOrderService orderService)
    {
      this.orderService = orderService;
    }

    [HttpGet("siparis-yap", Name = "SubmitOrder")]
    public IActionResult SubmitOrder()
    {
      //var orderService = new OrderService(new TurkcelEmailService());
      //orderService.SubmitOrder(model);

      return View();
    }

    [HttpPost("siparis-yap",Name ="SubmitOrder")]
    public IActionResult SubmitOrder(SubmitOrderInputModel model)
    {

      orderService.SubmitOrder(model);

      //var orderService = new OrderService(new TurkcelEmailService());
      //orderService.SubmitOrder(model);

      return View();
    }
  }
}
