using System.Threading.Tasks;

namespace Grocedy.Infrastructure.Services
{
    public interface IWebHooksService
    {
        Task<object> ChargeAmountForRenewal(object data);
        Task<object> UpdatePaymentStatus(object data);
    }
}