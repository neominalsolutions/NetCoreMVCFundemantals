namespace NetCoreMVCFundemantals.Middlewares
{
  /// <summary>
  /// 
  /// </summary>
  public class LoggingMiddleware
  {
    private RequestDelegate next;

    // contructor injection
    /// <summary>
    /// 
    /// </summary>
    /// <param name="next"></param>
    public LoggingMiddleware(RequestDelegate next)
    {
      this.next = next;
    }

    // eğer privacy sayfasına bir istek atıldıysa response'a gizlik sayfasına istek attınız diye yazdıran bir middleware

    // method injection
    // useLoggion middleware çağrıldığında çalışacak olan kod
    /// <summary>
    /// HttpContext ile request yakalanıp işlenir.
    /// </summary>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    public async Task InvokeAsync(HttpContext httpContext)
    {

      if (httpContext.Request.Method == HttpMethods.Post)
      {
        // interpolation
        string content = $"Host => {httpContext.Request.Host} Method: {httpContext.Request.Method} Url {httpContext.Request.Path} \n";

        File.AppendAllText("log.txt", content);

        // istek kaldığı yerden devam etsin kısmı.
     
      }
   
      await next(httpContext);


    }
  }
}
