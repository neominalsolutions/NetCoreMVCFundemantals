using Microsoft.AspNetCore.Mvc;
using NetCoreMVCFundemantals.Models;

namespace NetCoreMVCFundemantals.Controllers
{
  public class CategoryController : Controller
  {

    [HttpGet("kategoriler")]
    public async Task<IActionResult> Index()
    
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

    // Sayfanın ekran çıktısı vermemsi için HTTPGET yöntemini kullanıyoruz

    [HttpGet("kategori-ekle",Name ="kategoriEkle")]
    //[Route("kategori-ekle",Name ="kategoriEkle")]
    public IActionResult CreateCategory()
    {
      return View();
    }

    // formdan veri gönderme işlemleri için HTTPPOST, Silme,Güncelleme,Kayıt,Ekleme
    // attribute routing
    // yönlendirme linki
    // route yönlendirme (kebap-case) tercih ederiz
    // 
    [HttpPost("kategori-ekle", Name = "kategoriEkle")]
    public IActionResult CreateCategory(CategoryCreateInputModel model)
    {

      //var orderService = new OrderService(new TurkcelEmailService());
      //orderService.SubmitOrder(model);

      if (ModelState.IsValid)
      {
        
        bool isExist = true;
        if(isExist)
        {
          ModelState.AddModelError("Name", "Aynı");
        }
        else
        {
          // db işlemleri yapılır.

          // dbden aynı isimde kategori var mı yokmuş kontrolü yapılır. aynı isimde kategori varsa burada hata verebilir.
        }

      }
      

      return View();
    }




  }
}
