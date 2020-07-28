using System;
namespace GrocedyAPI.DataModels.Account
{
    public class Register
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string ReferalCode { get; set; }
    }
}
