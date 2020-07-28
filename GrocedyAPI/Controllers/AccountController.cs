using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptSharp;
using Grocedy.Core.Core;
using Grocedy.Domain.Models;
using Grocedy.Infrastructure.Services.Account;
using GrocedyAPI.DataModels.Account;
using GrocedyAPI.DataModels.Zoho;
using GrocedyAPI.DataModels.Zoho.Subscriptions.CreateSubscriptions;
using GrocedyAPI.Helpers;
using GrocedyAPI.Infrastructure;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrocedyAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {

        #region #       Private Variables       #
        private readonly GrocedyContext context;
        private readonly IUnitOfWork unitOfWork;
        private readonly IAccountService accountService;
        private readonly IConfiguration configuration;
        private readonly IRazorViewToStringRenderer _renderer;

        #endregion


        public AccountController(IAccountService accountService,GrocedyContext context, IConfiguration configuration, IUnitOfWork unitOfWork, IRazorViewToStringRenderer renderer)
        {
            this.context = context;
            this.configuration = configuration;
            _renderer = renderer;
            this.unitOfWork = unitOfWork;
            this.accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([FromBody] Login request) => Ok(await accountService.CheckLoginAsync(request));

        [HttpPost("changedeliveryaddress")]
        public async Task<ActionResult> ChangeDeliveryAddressAsync([FromBody] ChangeDeliveryRequest request) => Ok(await accountService.ChangeDeliveryAddressAsync(request));

        [HttpPost("changepassword")]
        public async Task<ActionResult> ChangePasswordAsync([FromBody] ChangePasswordRequest request) => Ok(await accountService.ChangePasswordAsync(request));


        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] Register register) => Ok(await accountService.RegisterAsync(register));

        [HttpGet("resendactivationlink")]
        public async Task<IActionResult> ResendActivationLink(string userID, string email)
        {
            const string view = "/Views/ActivateAccount/Index.cshtml";
            var ActivationLink = WordPressPasswordUtil.GetActivationLink(Convert.ToString(userID), email);
            var template =await _renderer.RenderViewToStringAsync<Models.ActivateAccountViewModel>(view,new Models.ActivateAccountViewModel() { URL= ActivationLink});;
            return Ok(await accountService.ResendActivationLink(userID, email,template)); }


        [HttpGet("forgotpasswordlink")] 
        public async Task<IActionResult> ForgotPasswordLink(string email) => Ok(await accountService.ForgotPasswordLink(email));

        ///
        /// TODO :: Registration,Forgot Password, Reset Password
        ///

        //   [HttpGet("env")]
        //public async Task<string> Env()
        //{
        //    try
        //    {
        //        return this.configuration.GetSection("Environment").Value.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.StackTrace.ToString();
        //    }
        //}
        }
}

