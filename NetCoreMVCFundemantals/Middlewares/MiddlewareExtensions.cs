using System.Runtime.CompilerServices;

namespace NetCoreMVCFundemantals.Middlewares
{
  // extension tanımı yapmak için static sınıflar ile çalışırız
  public static class MiddlewareExtensions
  {
    // this keyword ile extende edeceğimiz sınıf veya tip tanımı yapılır
    public static IApplicationBuilder UseCustomLogging(this IApplicationBuilder builder)
    {
      // uygulama middlewzare kullandın
      //builder.Use(async (context, next) =>
      //{

      //});

      builder.UseMiddleware<LoggingMiddleware>();

      return builder;
    }

    /// <summary>
    /// basit bir string extension tanımı
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string UpperCaseFormat(this string value)
    {
      return value.ToUpper();
    }
  }
}
