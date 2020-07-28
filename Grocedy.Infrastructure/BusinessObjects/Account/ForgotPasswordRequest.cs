using System;
namespace GrocedyAPI.DataModels.Account
{
    public class ForgotPasswordRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
