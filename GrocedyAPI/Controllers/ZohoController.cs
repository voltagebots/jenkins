using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Grocedy.Core.Core;
using Grocedy.Domain.Models;
using Grocedy.Infrastructure.Services.Zoho;
using GrocedyAPI.DataModels;
using GrocedyAPI.DataModels.Zoho;
using GrocedyAPI.DataModels.Zoho.Inventory.InventoryResponse;
using GrocedyAPI.DataModels.Zoho.Subscriptions;
using GrocedyAPI.DataModels.Zoho.Subscriptions.CreateSubscriptions;
using GrocedyAPI.DataModels.Zoho.Subscriptions.Deliveries;
using GrocedyAPI.DataModels.Zoho.Subscriptions.Payments;
using GrocedyAPI.Helpers;
using GrocedyAPI.Infrastructure;
using GrocedyAPI.Infrastructure.Zoho.Subscription;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrocedyAPI.Controllers
{
    [Route("api/[controller]")]
    // [EnableCors("AllowMyOrigin")]
    public class ZohoController : Controller
    {
        #region **** Private Fields                                             ****

        private readonly IConfiguration configuration;
        private readonly IUnitOfWork unitOfWork;
        private readonly IZohoService zohoService;
        #endregion

        #region **** Constructor                                                ****
        public ZohoController(IZohoService zohoService, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            this.configuration = configuration;
            this.unitOfWork = unitOfWork;
            this.zohoService = zohoService;
        }
        #endregion

        [HttpGet("customerid")]
        public async Task<ActionResult> GetZohoCustomerID(string userID) => Ok(await zohoService.GetZohoCustomerIDAsync(userID));

        [HttpGet("getbaskets")]
        public async Task<ActionResult> GetBasketsAsync(string token) => Ok(await zohoService.GetBasketsAsync(token));

        [HttpGet("gethomescreendata")]
        public async Task<ActionResult> GetHomeScreenDataAsync(string userid, string token) => Ok(await zohoService.GetHomeScreenDataAsync(userid, token));

        [HttpGet("giftshistory")]
        public async Task<ActionResult> GetGiftsHistoryAsync(string userid, string token) => Ok(await zohoService.GetGiftsHistoryAsync(userid, token));


        [HttpGet("addons")]
        public async Task<IActionResult> GetAddons(string planCode, string token) => Ok(await zohoService.GetAddonsAsync(planCode, token));


        [HttpPost("createsubscription")]
        public async Task<ActionResult> CreateSubscriptionAsync([FromBody] CreateSubscriptionRequest request)
        {
            try
            {
                  //  EmailHelper.Send("sylendra92@gmail.com", "sylendra92@gmail.com", "Request Body", JsonConvert
                  //.SerializeObject(request));
            }
            catch (Exception ex)
            {

            }

            return Ok(await zohoService.CreateSubscriptionAsync(request));
        }

        [HttpPost("confirmpayment")]
        public async Task<ActionResult> ConfirmPaymentAsync([FromBody] ConfirmPaymentRequest request) => Ok(await zohoService.ConfirmPaymentAsync(request));

        [HttpGet("history")]
        public async Task<ActionResult> GetSubscriptionHistoryAsync(string userID, string token) => Ok(await zohoService.GetSubscriptionHistoryAsync(userID, token));

        [HttpGet("getstatus")]
        public async Task<ActionResult> TrackOrder(string userID, string subscriptionID,
                                                   string month, string zohoToken, string inventoryToken,string customerID) => Ok(await zohoService.TrackOrder(userID, subscriptionID, month, zohoToken, inventoryToken,customerID));

        [HttpGet("getdeliveries")]
        public async Task<ActionResult> GetDeliveries(string userID, string token, string inventoryToken) => Ok(await zohoService.GetDeliveries(userID, token, inventoryToken));

        [HttpGet("getallgiftsforuser")]
        public async Task<ActionResult> GetAllGiftsHistoryAsync(string userID, string token) => Ok(await zohoService.GetAllGiftsHistory(userID,token));

        [HttpGet("getsubscription")]
        public async Task<ActionResult> GetSubscription(string subscriptionID, string userID,string token) => Ok(await zohoService.GetSubscription(userID,subscriptionID,token));

        #region    # UnUsed Code or Commented Code #
        //[HttpGet("getproducts")]
        //public async Task<ActionResult<string>> GetProducts()
        //{
        //    var token = this.httpClientFactory.Token().Result.AccessToken;
        //    var productsURl = "https://subscriptions.zoho.com/api/v1/customers";
        //    //await this.httpClientFactory.GetAsync<dynamic>();
        //    //HttpClient httpClient = new HttpClient();
        //    //httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Zoho-oauthtoken", token.AccessToken);
        //    //httpClient.DefaultRequestHeaders.Add("X-com-zoho-subscriptions-organizationid", "52132602");
        //    //var results = await httpClient.GetAsync(productsURl);
        //    //var products = await results.Content.ReadAsStringAsync();
        //    //return products;

        //    GrocedyAPI.Models.GrocedyContext context = new Models.GrocedyContext();
        //    var data = context.WpUsers.ToList();

        //    return "Hello";

        //}
        #endregion
    }
}
