using System.Threading.Tasks;
using GrocedyAPI.DataModels.Zoho.Subscriptions.CreateSubscriptions;
using GrocedyAPI.DataModels.Zoho.Subscriptions.Payments;

namespace Grocedy.Infrastructure.Services.Zoho
{
    public interface IZohoService
    {
        Task<object> ConfirmPaymentAsync(ConfirmPaymentRequest request);
        Task<object> CreateSubscriptionAsync(CreateSubscriptionRequest request);
        Task<object> GetAddonsAsync(string planCode, string token);
        Task<object> GetBasketsAsync(string token);
        Task<object> GetDeliveries(string userID, string token, string inventoryToken);
        Task<object> GetHomeScreenDataAsync(string userid, string token);
        Task<object> GetGiftsHistoryAsync(string userid, string token);
        Task<object> GetSubscriptionHistoryAsync(string userID, string token);
        Task<object> GetZohoCustomerIDAsync(string userID);
        Task<object> TrackOrder(string userID, string subscriptionID, string month, string zohoToken, string inventoryToken,string customerID);
        Task<object> GetAllGiftsHistory(string userID, string token);
        Task<object> GetSubscription(string userID, string subscriptionID, string token);
    }
}