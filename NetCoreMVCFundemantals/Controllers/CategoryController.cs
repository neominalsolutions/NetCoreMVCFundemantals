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
    [HttpPost("kategori-ekle", Name = "kategoriEkle")]
    public IActionResult CreateCategory(CategoryCreateInputModel model)
    {
      // db işlemleri yapılır.
      return View();
    }




  }
}
