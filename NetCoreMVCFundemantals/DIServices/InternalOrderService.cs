using NetCoreMVCFundemantals.Models;

namespace NetCoreMVCFundemantals.DIServices
{
  public class OrderService
  {
    private IEmailService emailService;

    // Dependecy Injection ile emailService'e OrderService içerisinde email servisi çağırdık.
    public OrderService(IEmailService emailService)
    {
      this.emailService = emailService;
    }

    public void SubmitOrder(SubmitOrderInputModel model)
    {
      // siparişten sonra email at
      this.emailService.SendEmail("ali", "ahmet", "sipariş tamam");
    }
  }
}
