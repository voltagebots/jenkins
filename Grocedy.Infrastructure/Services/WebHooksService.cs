using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grocedy.Core.Core;
using Grocedy.Domain.Models;
using Grocedy.Infrastructure.Infrastructure;
using GrocedyAPI.DataModels.WebHooks;
using GrocedyAPI.DataModels.Zoho.Subscriptions;
using GrocedyAPI.DataModels.Zoho.Subscriptions.Payments;
using Newtonsoft.Json;

namespace Grocedy.Infrastructure.Services
{
    public class WebHooksService : IWebHooksService
    {
        private IUnitOfWork unitOfWork;
        private IHttpClientFactory httpClientFactory;

        public WebHooksService(IUnitOfWork unitOfWork, IHttpClientFactory httpClientFactory)
        {
            this.unitOfWork = unitOfWork;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<object> UpdatePaymentStatus(object data)
        {

            try
            {

                await unitOfWork.LogsRepository.Add(new WpLogs() { Data = data.ToString() });




                var token = this.httpClientFactory.Token(HttpClientFactory.APIType.ZohoSubscription).Result.AccessToken;

                var request = JsonConvert.DeserializeObject<PaystackPaymentUpdateHookRequest>(data.ToString());

                if (request.Event == "charge.success")
                {
                    var subscriptionData = await unitOfWork.UserPaymentSubscriptionDetailsRepository.Single(w => w.SubscriptionId == request.Data.Reference.ToString());
                    var subscriptions = await this.httpClientFactory.GetAsync<GetSubscriptionResponse>($"https://subscriptions.zoho.com/api/v1/subscriptions/{request.Data.Reference}", HttpClientFactory.APIType.ZohoSubscription, token);
                    var isGift = subscriptions.result.Subscription.CustomFields.Where(s => s.Label == "IsGift").SingleOrDefault().Value == "true";

                    ConfirmZohoPaymentRequest paymentRequest = new ConfirmZohoPaymentRequest();
                    //if (User != null)
                    //  paymentRequest.CustomerId = userMapping.ZohoCustomerId;
                    //else
                    paymentRequest.CustomerId = isGift ? subscriptions.result.Subscription.Customer.CustomerId : subscriptionData.CustomerId;
                    paymentRequest.PaymentMode = "other";
                    paymentRequest.Amount = Convert.ToDecimal(subscriptions.result.Subscription.Amount);
                    // paymentRequest.Date = Convert.ToDateTime(request.InvoiceDate).ToShortDateString();
                    paymentRequest.ReferenceNumber = request.Data.Reference;
                    paymentRequest.Description = $"Payment has been added to Invoice and your Payment reference :  {paymentRequest.ReferenceNumber}";
                    paymentRequest.Invoices = new List<Invoice>() {
                        new Invoice()
                        {
                            InvoiceId=subscriptions.result.Subscription.ChildInvoiceID,
                            AmountApplied=subscriptions.result.Subscription.Amount
                        }
                    };

                    var paymentURL = "https://subscriptions.zoho.com/api/v1/payments";
                    var paymentResponse = await this.httpClientFactory.PostAsync<ConfirmZohoPaymentResponse, ConfirmZohoPaymentRequest>(paymentURL, paymentRequest
                        , HttpClientFactory.APIType.ZohoSubscription, token);
                    if (paymentResponse.result.Code == 0)
                    {
                        subscriptionData.AuthorizationCode = request.Data.Authorization.AuthorizationCode;
                        subscriptionData.PaymentReference = request.Data.Reference;
                        unitOfWork.UserPaymentSubscriptionDetailsRepository.Update(subscriptionData);
                        await unitOfWork.SaveChangesAsync();

                    }
                }
            }
            catch (Exception ex)
            {
                await unitOfWork.LogsRepository.Add(new WpLogs() { Data = ex.StackTrace.ToString() });
                await unitOfWork.SaveChangesAsync();
            }
            
            return new { };
        }

        public async Task<object> ChargeAmountForRenewal(object data)
        {
            try
            {
                await unitOfWork.LogsRepository.Add(new WpLogs() { Data = data.ToString() });


                var token = this.httpClientFactory.Token(HttpClientFactory.APIType.ZohoSubscription).Result.AccessToken;

                var request = JsonConvert.DeserializeObject<RenewalSubscriptionWebHookRequest>(data.ToString());

                if (request.EventType == "subscription_renewed")
                {
                    var subscriptionData = await unitOfWork.UserPaymentSubscriptionDetailsRepository.Single(w => w.SubscriptionId == request.Data.Subscription.SubscriptionId.ToString());

                    var chargePaymentURL = "https://api.paystack.co/transaction/charge_authorization";

                    var paymentResponse = await httpClientFactory.PostAsync<ChargePaymentResponse, ChargePaymentRequest>(chargePaymentURL, new ChargePaymentRequest()
                    {
                        Amount = Convert.ToString(request.Data.Subscription.Amount),
                        Email = request.Data.Subscription.Customer.Email,
                        ReferenceNumber = string.Empty
                    }, HttpClientFactory.APIType.Paystack, string.Empty);

                    if (paymentResponse.result.Status)
                    {
                        var subscriptions = await this.httpClientFactory.GetAsync<GetSubscriptionResponse>($"https://subscriptions.zoho.com/api/v1/subscriptions/{request.Data.Subscription.SubscriptionId}", HttpClientFactory.APIType.ZohoSubscription, token);
                        ConfirmZohoPaymentRequest paymentRequest = new ConfirmZohoPaymentRequest();
                        //if (User != null)
                        //  paymentRequest.CustomerId = userMapping.ZohoCustomerId;
                        //else
                        paymentRequest.CustomerId = subscriptionData.CustomerId;
                        paymentRequest.PaymentMode = "other";
                        paymentRequest.Amount = Convert.ToDecimal(subscriptions.result.Subscription.Amount);
                        // paymentRequest.Date = Convert.ToDateTime(request.InvoiceDate).ToShortDateString();
                        paymentRequest.ReferenceNumber = paymentResponse.result.Data.Reference;
                        paymentRequest.Description = $"Payment has been added to Invoice and your Payment reference :  {paymentResponse.result.Data.Reference}";
                        paymentRequest.Invoices = new List<Invoice>() {
                        new Invoice()
                        {
                            InvoiceId=subscriptions.result.Subscription.ChildInvoiceID,
                            AmountApplied=subscriptions.result.Subscription.Amount
                        }
                    };
                        var paymentURL = "https://subscriptions.zoho.com/api/v1/payments";
                        var paymentConfirmResponse = await this.httpClientFactory.PostAsync<ConfirmZohoPaymentResponse, ConfirmZohoPaymentRequest>(paymentURL, paymentRequest
                            , HttpClientFactory.APIType.ZohoSubscription, token);
                        if (paymentConfirmResponse.result.Code == 0)
                        {

                            subscriptionData.PaymentReference = paymentResponse.result.Data.Reference;
                            unitOfWork.UserPaymentSubscriptionDetailsRepository.Update(subscriptionData);
                            await unitOfWork.SaveChangesAsync();
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                await unitOfWork.LogsRepository.Add(new WpLogs() { Data = ex.StackTrace.ToString() });
                await unitOfWork.SaveChangesAsync();
            }
            
            return new { };
        }
    }
}
