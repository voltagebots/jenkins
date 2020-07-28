using System;
namespace GrocedyAPI.DataModels.Account
{
    public class ChangePasswordRequest
    {
        public string UserID { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
