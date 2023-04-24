using NetCoreMVCFundemantals.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NetCoreMVCFundemantals.Models
{
  // formdan gönderilecek olan veriler için Input Model tanımı yapıyoruz
  public class CategoryCreateInputModel
  {

    [Required(ErrorMessage = "Kategori Adı boş geçilemez")]
    [MinLength(20, ErrorMessage = "Minimum 20 karakter girilebilir")]
    //[StringLengthRange(ErrorMessage ="",Maximum = 10, Minimum = 5)]
    public string Name { get; set; } = string.Empty; // ""

    [Required(ErrorMessage = "Kategori Açıklaması boş geçilemez")]
    public string? Description { get; set; } // optional demek oluyor, null

  }
}
