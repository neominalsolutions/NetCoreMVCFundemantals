using Microsoft.AspNetCore.Mvc;
using NetCoreMVCFundemantals.Models;

namespace NetCoreMVCFundemantals.Controllers
{
  public class CategoryController : Controller
  {

    [HttpGet("kategoriler")]
    public IActionResult Index()
    
    {
      // model oluşturduk
      var clist = new List<CategoryViewModel>();
      clist.Add(new CategoryViewModel() { Name = "Kategori1", Description = "Açıklama1" });
      clist.Add(new CategoryViewModel { Name = "Kategori1", Description = "Açıklama2" });


      // view model gönderdik.
      // view'e sadece 1 model gönderibilir. 
      // bu durumda view başka model nasıl taşayacağız ?

      return View(clist);
    }
  }
}
