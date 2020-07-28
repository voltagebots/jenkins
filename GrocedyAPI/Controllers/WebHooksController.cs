using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grocedy.Core.Core;
using Grocedy.Domain.Models;
using Grocedy.Infrastructure.Services;
using GrocedyAPI.DataModels.WebHooks;
using GrocedyAPI.DataModels.Zoho.Subscriptions;
using GrocedyAPI.DataModels.Zoho.Subscriptions.Payments;
using GrocedyAPI.Helpers;
using GrocedyAPI.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrocedyAPI.Controllers
{
    [Route("api/[controller]")]
    public class WebHooksController : Controller
    {
        #region #Private Fields#
        private readonly GrocedyContext context;
        private readonly IConfiguration configuration;
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHooksService webHooksService;
        #endregion

        #region #Constructor#
        public WebHooksController(IWebHooksService webHooksService,GrocedyContext context, IConfiguration configuration,IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.configuration = configuration;
            this.unitOfWork = unitOfWork;
            this.webHooksService = webHooksService;
        }
        #endregion

        [HttpPost("confirmpayment")]
        public async Task<IActionResult> UpdatePaymentStatus([FromBody] object data)
        {
            await webHooksService.UpdatePaymentStatus(data);
            return Ok();
        }

        [HttpPost("renewsubscription")]
        public async Task<IActionResult> ChargeAmountForRenewal([FromBody]object data)
        {
            await webHooksService.ChargeAmountForRenewal(data);
            return Ok();
        }

        [HttpPost("webhooks")]
        public IActionResult InitiatePayment([FromBody]object data)
        {
            try
            {
                context.WpLogs.Add(new WpLogs() { Data = data.ToString() });
                context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

    }
}
