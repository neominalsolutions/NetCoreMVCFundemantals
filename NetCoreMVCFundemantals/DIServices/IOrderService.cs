using NetCoreMVCFundemantals.Models;

namespace NetCoreMVCFundemantals.DIServices
{
  public interface IOrderService
  {
    void SubmitOrder(SubmitOrderInputModel model);
  }
}
