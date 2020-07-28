using System.Threading.Tasks;
using Grocedy.Domain.Models;
using GrocedyAPI.DataModels.Account;

namespace Grocedy.Infrastructure.Services.Account
{
    public interface IAccountService
    {
        Task<object> ChangeDeliveryAddressAsync(ChangeDeliveryRequest request);
        Task<object> ChangePasswordAsync(ChangePasswordRequest request);
        Task<object> CheckLoginAsync(Login request);
        Task<object> RegisterAsync(Register register);
        Task<object> ResendActivationLink(string userID, string email,string template);
        Task<object> ForgotPasswordLink(string email);
    }
}