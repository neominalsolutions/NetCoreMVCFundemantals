using NetCoreMVCFundemantals.Models;

namespace NetCoreMVCFundemantals.DIServices
{
  public class InternalOrderService:IOrderService
  {
    private IEmailService emailService;

    // Dependecy Injection ile emailService'e OrderService içerisinde email servisi çağırdık.
    public InternalOrderService(IEmailService emailService)
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
