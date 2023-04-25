using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using NetCoreMVCFundemantals.DIServices;
using NetCoreMVCFundemantals.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddControllers();
//builder.Services.AddRazorPages();

// uygulamanýn merkezi olarak uygulama kullanýlan servislerin instancelarý yönetebiliriz. Net Core Dependency Injection kütüphanesi bunu yapar.
// her sýnýf çaðýrýsýnda yeni bir instance al demek.
builder.Services.AddTransient<IOrderService,InternalOrderService>();
// eðer uygulama içerisinde bir yerlerde email servis çaðýrýlýrsa turkcell servis instance döndürsün.
builder.Services.AddTransient<IEmailService, VodafoneEmailService>();
// not sadece servis çaðýrýsý yapacaðýmýz sýnýflarý burada otomatik instance aldýrýrýz. (ViewModel,InputModel,Entity) gibi sýnýflarýn instance yazýlýmcýý duruma göre kendisi alýr. Bu dýþýndaki tüm hizmetlere ait instancelarýn yönetimini ise net core devreder.

// net core da servislerin yaþamlarýný instancelarýný yöntebileceðimiz IoC container özelliði mevcuttur.


var app = builder.Build();
// uygulama aþaðýdaki middleware ara yazýlýmlarýn özellikleri kullanýyor. use ile uygulama bu özelliði kullanýsýn tarzýnda middleware ekliyoruz.

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  // bütün http istekleri kesilir. uygulama sadece https üzerinden hizmet verir.
  app.UseHsts();
}

// https sertifikasý varsa uygulama gelen istekler http kanalýndan dahi olsa https otomatik yönlendirme yapar. bu kontrol eden middleware
app.UseHttpsRedirection();
// uygýlama publish olduktan sonra www root dizinden hizmet verir.
// eðer bu middleware çalýþmaz ise uygulamadaki static içerikler yüklenemz
app.UseStaticFiles();

// authentication middleware uygulamadaki kimlik doðrulama süreci için geliþtirilmiþ bir middleware routing ile UseAuthorization arasýna yazalým.
app.UseRouting();

app.UseAuthorization();

//"sadsadsadsad".UpperCaseFormat();


//app.UseCustomLogging();

// kendi yazdýðýmýz middlewareleri rundan önce tanýmlayalým.
// gelen web isteklerini dosyaya yazan middleware // development ortamýnda istekleri loglamak için kullandýk.
app.UseCustomLogging();
//app.Use(async (context, next) =>
//{

//  if(context.Request.Method == HttpMethods.Post)
//  {
//    // interpolation
//    string content = $"Host => {context.Request.Host} Method: {context.Request.Method} Url {context.Request.Path} \n";

//    File.AppendAllText("log.txt", content);

//    // istek kaldýðý yerden devam etsin kýsmý.
//    await next();
//  }

  

//  // HttpContext bir web projesindeki bileþenleri yöneten sýnýf.
//  await next();
//});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
// not buradan sonra herhangi bir middleware yaparsak çalýþmaz kýsa devre middleware

//app.Use(async (context, next) =>
//{
//  await next();
//});
