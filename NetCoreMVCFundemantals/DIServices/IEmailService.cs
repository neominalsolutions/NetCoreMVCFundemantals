namespace NetCoreMVCFundemantals.DIServices
{


  public interface IEmailService
  {
    /// <summary>
    /// Email gönderen servis
    /// </summary>
    /// <param name="to">kime</param>
    /// <param name="from">kimden</param>
    /// <param name="message">mesaj</param>
    void SendEmail(string to, string from, string message);
  }
}
