using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using NetCoreMVCFundemantals.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddControllers();
//builder.Services.AddRazorPages();


var app = builder.Build();
// uygulama a�a��daki middleware ara yaz�l�mlar�n �zellikleri kullan�yor. use ile uygulama bu �zelli�i kullan�s�n tarz�nda middleware ekliyoruz.

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  // b�t�n http istekleri kesilir. uygulama sadece https �zerinden hizmet verir.
  app.UseHsts();
}

// https sertifikas� varsa uygulama gelen istekler http kanal�ndan dahi olsa https otomatik y�nlendirme yapar. bu kontrol eden middleware
app.UseHttpsRedirection();
// uyg�lama publish olduktan sonra www root dizinden hizmet verir.
// e�er bu middleware �al��maz ise uygulamadaki static i�erikler y�klenemz
app.UseStaticFiles();

// authentication middleware uygulamadaki kimlik do�rulama s�reci i�in geli�tirilmi� bir middleware routing ile UseAuthorization aras�na yazal�m.
app.UseRouting();

app.UseAuthorization();

"sadsadsadsad".UpperCaseFormat();


//app.UseCustomLogging();

// kendi yazd���m�z middlewareleri rundan �nce tan�mlayal�m.
// gelen web isteklerini dosyaya yazan middleware // development ortam�nda istekleri loglamak i�in kulland�k.
app.UseCustomLogging();
//app.Use(async (context, next) =>
//{

//  if(context.Request.Method == HttpMethods.Post)
//  {
//    // interpolation
//    string content = $"Host => {context.Request.Host} Method: {context.Request.Method} Url {context.Request.Path} \n";

//    File.AppendAllText("log.txt", content);

//    // istek kald��� yerden devam etsin k�sm�.
//    await next();
//  }

  

//  // HttpContext bir web projesindeki bile�enleri y�neten s�n�f.
//  await next();
//});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
// not buradan sonra herhangi bir middleware yaparsak �al��maz k�sa devre middleware

//app.Use(async (context, next) =>
//{
//  await next();
//});
