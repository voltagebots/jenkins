using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grocedy.Core.Core;
using Grocedy.Domain.Models;
using Grocedy.Infrastructure.Infrastructure;
using GrocedyAPI.DataModels;
using GrocedyAPI.DataModels.Zoho;
using GrocedyAPI.DataModels.Zoho.Inventory.InventoryResponse;
using GrocedyAPI.DataModels.Zoho.Subscriptions;
using GrocedyAPI.DataModels.Zoho.Subscriptions.CreateSubscriptions;
using GrocedyAPI.DataModels.Zoho.Subscriptions.Deliveries;
using GrocedyAPI.DataModels.Zoho.Subscriptions.Payments;
using GrocedyAPI.Helpers;
using GrocedyAPI.Infrastructure.Zoho.Subscription;

namespace Grocedy.Infrastructure.Services.Zoho
{
    public class ZohoService : IZohoService  
    {

        private readonly IHttpClientFactory httpClientFactory;
        private readonly IUnitOfWork unitOfWork;
        public ZohoService(IUnitOfWork unitOfWork, IHttpClientFactory httpClientFactory)
        {
            this.unitOfWork = unitOfWork;
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<object> GetZohoCustomerIDAsync(string userID)
        {
            var users = await unitOfWork.UserRepository.Find(u => u.Id == long.Parse(userID));
            if (users.Count() > 0)
            {
                var userMappings = await unitOfWork.ZohoCustomerMappingRepository.All();
                if (userMappings.Where(u => u.UserId == long.Parse(userID)).Count() > 0)
                {
                    return (new
                    {
                        Status = true,
                        Message = "Incorrect UserID",
                        CustomerID = userMappings.Where(u => u.UserId == long.Parse(userID)).First().ZohoCustomerId

                    });
                }
                else
                {
                    return (new
                    {
                        Status = true,
                        Message = "No CustomerID found",
                        CustomerID = 0

                    });
                }
            }
            else
            {
                return (new
                {
                    Status = false,
                    Message = "Incorrect UserID"

                });
            }
        }

        public async Task<object> GetBasketsAsync(string token)
        {
            // var token = this.httpClientFactory.Token().Result.AccessToken;
            var productsURl = "https://subscriptions.zoho.com/api/v1/plans";
            var plans = await this.httpClientFactory
                                  .GetAsync<PlansResponse>(productsURl,
                                                           HttpClientFactory.APIType.ZohoSubscription,
                                                           token);

            var addonsURI = "https://subscriptions.zoho.com/api/v1/addons";
            var addonsResponse = await this.httpClientFactory
                                           .GetAsync<AddonsResponse>(addonsURI,
                                                                     HttpClientFactory.APIType.ZohoSubscription,
                                                                     token);
            var addons = addonsResponse.result.Addons.ToList();

            var response = plans.result.Plans
                                       .Where(p => p.Status == "active")
                                       .Select(s => new
                                       {
                                           PlanCode = s.PlanCode,
                                           Name = s.Name,
                                           Price = $"₦ {s.RecurringPrice:#,##0.00}",
                                           DeliveryCharge = (from addon in addons
                                                             from p in addon.Plans
                                                             where p.PlanCode == s.PlanCode && addon.PriceBrackets.Count > 0 //&& addon.Name.StartsWith("Delivery")
                                                             select addon).Select(s =>
                                                             new { s.PriceBrackets.Single().Price }),
                                           Description = $"Up to {s.StoreMarkupDescription.Split('|').ToList().Count} items in your basket",
                                           Items = s.StoreMarkupDescription.Replace(System.Environment.NewLine, " ").Split('|').ToList()
                                       });

            return (new
            {
                Status = true,
                ZohoSubscriptionToken = string.IsNullOrWhiteSpace(plans.token) ? string.Empty : plans.token,
                ZohoInventoryToken = string.Empty,
                Data = response
            });

        }

        public async Task<object> GetHomeScreenDataAsync(string userid, string token)
        {
            List<ToDoItem> todo = new List<ToDoItem>();
            GrocedyAPI.DataModels.Zoho.Subscriptions.Subscription subscription = null;//= new DataModels.Zoho.Subscriptions.Subscription();
            List<GrocedyAPI.DataModels.Zoho.Subscriptions.Subscription> gifts = new List<GrocedyAPI.DataModels.Zoho.Subscriptions.Subscription>();

            var usermetas = await unitOfWork.UsersMetaRepository.Find(u => u.UserId == long.Parse(userid));

            var userMappings = await unitOfWork.ZohoCustomerMappingRepository.Find(u => u.UserId == long.Parse(userid));

            string CustomerID = string.Empty;
            if (userMappings.Count() == 0)
            {
                //Not customer yet OR No Subscriptions found
                CustomerID = string.Empty;
            }
            else
            {
                CustomerID = userMappings.First().ZohoCustomerId;
            }
            if (usermetas.Count() > 0)
            {
                if (usermetas.Where(u => u.MetaKey == "billing_address_1").Count() == 0 ||
                    usermetas.Where(u => u.MetaKey == "billing_address_2").Count() == 0)
                {
                    todo.Add(new ToDoItem() { Name = "Add your delivery details", Value = "1" });
                }
            }

            if (string.IsNullOrWhiteSpace(CustomerID))
            {
                var history = await this.httpClientFactory
                                        .GetAsync<GetSubscriptionsResponse>("https://subscriptions.zoho.com/api/v1/subscriptions?filter_by=SubscriptionStatus.ACTIVE",
                                                                             HttpClientFactory.APIType.ZohoSubscription,
                                                                             token);

                gifts = (from all in (from s in history.result.Subscriptions
                                      from c in s.CustomFields
                                      where (c.Label == "CreatedBy" && c.Value == userid)
                                      select s)
                         from p in all.CustomFields
                         where (p.Label == "IsGift" && p.Value == "true")
                         select all).ToList();

                if (gifts.Count > 0)
                {
                    gifts.ForEach(g =>
                    {

                        g.Date = $"{Convert.ToDateTime(g.CurrentTermStartsAt).ToString("MMMM")} {Convert.ToDateTime(g.CurrentTermStartsAt).ToString("yyyy")} - {Convert.ToDateTime(g.CurrentTermEndsAt).ToString("MMMM")}  {Convert.ToDateTime(g.CurrentTermEndsAt).ToString("yyyy")} ";
                        g.IsGift = true;
                    });
                }
                //if (gifts.Count == 0)
                //{
                todo.Add(new ToDoItem() { Name = "Send a Gift", Value = "2" });
                //}
                return (new
                {
                    Status = true,
                    ZohoSubscriptionToken = string.Empty,
                    ToDoList = todo,
                    Subscriptions = subscription,
                    Gifts = gifts

                });
            }
            else
            {
                var history = await this.httpClientFactory
                                        .GetAsync<GetSubscriptionsResponse>("https://subscriptions.zoho.com/api/v1/subscriptions?filter_by=SubscriptionStatus.ACTIVE",
                                                                             HttpClientFactory.APIType.ZohoSubscription,
                                                                             token);

                if (history.result.Code == 0)
                {
                    var allSubscriptions = history.result
                                                  .Subscriptions
                                                  .Where(s => s.CustomerId == CustomerID)
                                                  .ToList();



                    gifts = (from all in (from s in history.result.Subscriptions
                                          from c in s.CustomFields
                                          where (c.Label == "CreatedBy" && c.Value == userid)
                                          select s)
                             from p in all.CustomFields
                             where (p.Label == "IsGift" && p.Value == "true")
                             select all).ToList();

                    if (gifts.Count > 0)
                    {
                        gifts.ForEach(g =>
                        {

                            g.Date = $"{Convert.ToDateTime(g.CurrentTermStartsAt).ToString("MMMM")} {Convert.ToDateTime(g.CurrentTermStartsAt).ToString("yyyy")} - {Convert.ToDateTime(g.CurrentTermEndsAt).ToString("MMMM")}  {Convert.ToDateTime(g.CurrentTermEndsAt).ToString("yyyy")} ";

                        });
                    }
                    if (allSubscriptions.Count > 0)
                    {

                        subscription = (from s in allSubscriptions
                                        from c in s.CustomFields
                                        where (c.Label == "IsGift" && c.Value == "false")
                                        select s).OrderByDescending(s => Convert.ToDateTime(s.CreatedAt)).First();

                        subscription.Date = $"{Convert.ToDateTime(subscription.CurrentTermStartsAt).ToString("MMMM")} {Convert.ToDateTime(subscription.CurrentTermStartsAt).ToString("yyyy")} - {Convert.ToDateTime(subscription.CurrentTermEndsAt).ToString("MMMM")}  {Convert.ToDateTime(subscription.CurrentTermEndsAt).ToString("yyyy")} ";
                    }
                    else
                    {
                        //subscription = new DataModels.Zoho.Subscriptions.Subscription();
                    }
                    //  if (gifts.Count==0)
                    //{
                    todo.Add(new ToDoItem() { Name = "Send a Gift", Value = "2" });
                    //}
                    return (new
                    {
                        Status = true,
                        ZohoSubscriptionToken = string.IsNullOrWhiteSpace(history.token) ? string.Empty : history.token,
                        ToDoList = todo,
                        Subscriptions = subscription,
                        Gifts = gifts

                    });
                }
                else
                {

                    todo.Add(new ToDoItem() { Name = "Send a Gift", Value = "2" });
                    return (new
                    {
                        Status = true,
                        ZohoSubscriptionToken = history.token,
                        ToDoList = todo,
                        Subscriptions = subscription,
                        Gifts = gifts

                    });
                }
            }


        }

        public async Task<object> GetGiftsHistoryAsync(string userid, string token)
        {
            List<ToDoItem> todo = new List<ToDoItem>();
            GrocedyAPI.DataModels.Zoho.Subscriptions.Subscription subscription = null;//= new DataModels.Zoho.Subscriptions.Subscription();
            List<GrocedyAPI.DataModels.Zoho.Subscriptions.Subscription> gifts = new List<GrocedyAPI.DataModels.Zoho.Subscriptions.Subscription>();

            var usermetas = await unitOfWork.UsersMetaRepository.Find(u => u.UserId == long.Parse(userid));

            var userMappings = await unitOfWork.ZohoCustomerMappingRepository.Find(u => u.UserId == long.Parse(userid));

            string CustomerID = string.Empty;
            if (userMappings.Count() == 0)
            {
                //Not customer yet OR No Subscriptions found
                CustomerID = string.Empty;
            }
            else
            {
                CustomerID = userMappings.First().ZohoCustomerId;
            }

            var history = await this.httpClientFactory
                                           .GetAsync<GetSubscriptionsResponse>("https://subscriptions.zoho.com/api/v1/subscriptions?filter_by=SubscriptionStatus.ACTIVE",
                                                                                HttpClientFactory.APIType.ZohoSubscription,
                                                                                token);

            gifts = (from all in (from s in history.result.Subscriptions
                                  from c in s.CustomFields
                                  where (c.Label == "CreatedBy" && c.Value == userid)
                                  select s)
                     from p in all.CustomFields
                     where (p.Label == "IsGift" && p.Value == "true")
                     select all).ToList();

            if (gifts.Count > 0)
            {
                gifts.ForEach(g =>
                {

                    g.Date = $"{Convert.ToDateTime(g.CurrentTermStartsAt).ToString("MMMM")} {Convert.ToDateTime(g.CurrentTermStartsAt).ToString("yyyy")} - {Convert.ToDateTime(g.CurrentTermEndsAt).ToString("MMMM")}  {Convert.ToDateTime(g.CurrentTermEndsAt).ToString("yyyy")} ";

                });
            }
            return gifts.Where(g=>g.Status=="expired").ToList();

        }


        public async Task<object> GetAddonsAsync(string planCode, string token)
        {

            var data = await GetAddonFromPlanCodeAsync(planCode, token);
            return data;
        }

        private async Task<List<Addon>> GetAddonFromPlanCodeAsync(string planCode, string token)
        {
            var productsURl = "https://subscriptions.zoho.com/api/v1/addons";

            var plans = await this.httpClientFactory
                                  .GetAsync<AddonsResponse>(productsURl,
                                                            HttpClientFactory.APIType.ZohoSubscription,
                                                            token);

            var planAddons = plans.result.Addons.ToList();

            var data = (from addon in planAddons
                        from p in addon.Plans
                        where p.PlanCode == planCode
                        select addon).Select(s => new Addon()
                        {
                            AddonCode = s.AddonCode,
                            Price = s.PriceBrackets.Single().Price,
                            AddonDescription = s.Name
                        });

            return data.ToList();
        }

        public async Task<object> CreateSubscriptionAsync(CreateSubscriptionRequest request)
        {
            var token = this.httpClientFactory.Token(HttpClientFactory.APIType.ZohoSubscription).Result.AccessToken;
            var userMappings = await unitOfWork.ZohoCustomerMappingRepository.All();

            var productsURl = "https://subscriptions.zoho.com/api/v1/addons";
            var plans = await this.httpClientFactory
                                 .GetAsync<AddonsResponse>(productsURl,
                                                           HttpClientFactory.APIType.ZohoSubscription,
                                                           token);

            var planAddons = plans.result.Addons.ToList();

            var data = (from addon in planAddons
                        from p in addon.Plans
                        where p.PlanCode == request.PlanCode
                        select addon).Select(s => new Addon()
                        {
                            AddonCode = s.AddonCode,
                            Price = s.PriceBrackets.Single().Price,
                            AddonDescription = s.Name
                        });

            var user = await unitOfWork.UserRepository.Single(u => u.Id == long.Parse(request.UserID));

            var userMapping = userMappings.Where(u => u.UserId == long.Parse(request.UserID));
            if (!request.IsGift && userMapping.Count() > 0)
            {
                var subcriptionURL = "https://subscriptions.zoho.com/api/v1/subscriptions";
                var requestObject = ZohoCreateSubscriptionFactory.CreateCustomerSubscription(request, user, userMapping.Single().ZohoCustomerId, request.IsGift, data.ToList());
                    var updateCustomer = await this.httpClientFactory.PutAsync<CreateCustomerResponse, CreateCustomerRequest>(
                     $"https://subscriptions.zoho.com/api/v1/customers/{userMapping.Single().ZohoCustomerId}", new CreateCustomerRequest()
                     {

                         BillingAddress = new BillingAddress()
                         {
                             Attention = $"{request.FirstName} {request.LastName}",
                             Country = "NG",
                             State = request.BillingState,
                             City = request.BillingCity,
                             Street = $"{request.BillingAddress.Street}"
                         },
                         ShippingAddress = new ShippingAddress()
                         {
                             Attention = $"{request.ShippingFirstName} {request.ShippingLastName}",
                             Country = "NG",
                             State = request.ShippingState,
                             City = request.ShippingCity,
                             Street = request.ShippingStreet
                         }

                     }, HttpClientFactory.APIType.ZohoSubscription, token
                     );

                var zohoSubscription = await this.httpClientFactory.PostAsync<CreateZohoSubscriptionResponse, CreateZohoSubscriptionRequest>(
                  subcriptionURL, requestObject, HttpClientFactory.APIType.ZohoSubscription, token
                  );
                if (zohoSubscription.result.Code == 0)
                {
                    //if (string.IsNullOrWhiteSpace(request.CustomerID))
                    //{
                    //    context.WpZohocustomerMapping.Add(new WpZohocustomerMapping()
                    //    {
                    //        UserId = long.Parse(request.UserID),
                    //        ZohoCustomerId = zohoSubscription.Subscription.Customer.CustomerId
                    //    });
                    //    context.SaveChanges();
                    //}
                    await unitOfWork.UserPaymentSubscriptionDetailsRepository.Add(new WpUserpaymentsubcriptiondetails()
                    {
                        AuthorizationCode = string.Empty,
                        CreatedDate = DateTime.Now,
                        CustomerId = userMapping.Single().ZohoCustomerId,
                        UserId = request.UserID,
                        PaymentReference = zohoSubscription.result.Subscription.SubscriptionId,
                        SubscriptionId = zohoSubscription.result.Subscription.SubscriptionId
                    });
                    await unitOfWork.SaveChangesAsync();
                    if (request.IsRequestFromWebApp)
                    {


                        var paymentInitializeUrl = "https://api.paystack.co/transaction/initialize";
                        var paymentURLResponse = await httpClientFactory.PostAsync<PaystackInitializeResponse, PaystackInitializeRequest>(paymentInitializeUrl, new PaystackInitializeRequest()
                        {
                            Amount = zohoSubscription.result.Subscription.Amount,
                            Email = zohoSubscription.result.Subscription.Customer.Email,
                            Reference = zohoSubscription.result.Subscription.SubscriptionId
                        }, HttpClientFactory.APIType.Paystack, string.Empty);
                        if (paymentURLResponse.result.Status)
                        {

                            return (new
                            {
                                Status = true,
                                Message = "Subscription Created Successfully",
                                Data = paymentURLResponse.result.Data,
                                ZohoSubscriptionToken = zohoSubscription.token
                            });
                        }
                        else
                        {
                            return (new
                            {
                                Status = false,
                                Message = "Something went wrong",
                                ZohoSubscriptionToken = zohoSubscription.token
                            });
                        }
                    }
                    else
                    {

                        return (new
                        {
                            Status = true,
                            Message = "Subscription Created Successfully",
                            Data = zohoSubscription.result.Subscription,
                            ZohoSubscriptionToken = zohoSubscription.token
                        });
                    }
                }
                else
                {
                    return (new
                    {
                        Status = false,
                        Mesage = "Something went wrong"
                    });
                }
            }
            else
            {
                var subcriptionURL = "https://subscriptions.zoho.com/api/v1/subscriptions";
                (CreateZohoSubscriptionResponse result, string token) zohoSubscription;
                if (!string.IsNullOrWhiteSpace(request.CustomerID))
                {
                    CreateZohoSubscriptionRequest requestSubscriptionForOldCustomer = ZohoCreateSubscriptionFactory.CreateCustomerSubscription(request, user,request.CustomerID, request.IsGift, data.ToList());
                     zohoSubscription = await this.httpClientFactory.PostAsync<CreateZohoSubscriptionResponse, CreateZohoSubscriptionRequest>(
                  subcriptionURL, requestSubscriptionForOldCustomer, HttpClientFactory.APIType.ZohoSubscription, token
                  );
                }
                else
                {
                    CreateZohoSubscriptionForNewCustomerRequest requestSubscriptionForNewCustomer = ZohoCreateSubscriptionFactory.CreateNewCustomerSubscription(request, user, request.IsGift, data.ToList());
                     zohoSubscription = await this.httpClientFactory.PostAsync<CreateZohoSubscriptionResponse, CreateZohoSubscriptionForNewCustomerRequest>(
                subcriptionURL, requestSubscriptionForNewCustomer, HttpClientFactory.APIType.ZohoSubscription, token
                );
                }
                
             
                if (zohoSubscription.result.Code == 0)
                {
                    await unitOfWork.UserPaymentSubscriptionDetailsRepository.Add(new WpUserpaymentsubcriptiondetails()
                    {
                        AuthorizationCode = string.Empty,
                        CreatedDate = DateTime.Now,
                        CustomerId = userMapping.Single().ZohoCustomerId,
                        UserId = request.UserID,
                        PaymentReference = zohoSubscription.result.Subscription.SubscriptionId,
                        SubscriptionId = zohoSubscription.result.Subscription.SubscriptionId
                    });


                    if (!request.IsGift && string.IsNullOrWhiteSpace(request.CustomerID))
                    {
                        await unitOfWork.ZohoCustomerMappingRepository.Add(new WpZohocustomerMapping()
                        {
                            UserId = long.Parse(request.UserID),
                            ZohoCustomerId = zohoSubscription.result.Subscription.Customer.CustomerId
                        });

                    }
                    await unitOfWork.SaveChangesAsync();
                    if (request.IsRequestFromWebApp)
                    {
                        var paymentInitializeUrl = "https://api.paystack.co/transaction/initialize";
                        var paymentURLResponse = await httpClientFactory.PostAsync<PaystackInitializeResponse, PaystackInitializeRequest>(paymentInitializeUrl, new PaystackInitializeRequest()
                        {
                            Amount = zohoSubscription.result.Subscription.Amount,
                            Email = zohoSubscription.result.Subscription.Customer.Email,
                            Reference = zohoSubscription.result.Subscription.SubscriptionId
                        }, HttpClientFactory.APIType.Paystack, string.Empty);
                        if (paymentURLResponse.result.Status)
                        {

                            return (new
                            {
                                Status = true,
                                Message = "Subscription Created Successfully",
                                Data = paymentURLResponse.result.Data,
                                ZohoData = zohoSubscription.result.Subscription,
                                ZohoSubscriptionToken = zohoSubscription.token
                                //TODO : Add Invoice ID ,
                            });
                        }
                        else
                        {
                            return (new
                            {
                                Status = false,
                                Message = "Something went wrong"
                            });
                        }
                    }
                    else
                    {

                        return (new
                        {
                            Status = true,
                            Message = "Subscription Created Successfully",
                            Data = zohoSubscription.result.Subscription,
                            ZohoSubscriptionToken = zohoSubscription.token

                        });
                    }
                }
                else
                {
                    return (new
                    {
                        Status = false,
                        Mesage = zohoSubscription.result.Message

                    });
                }
            }




        }

        public async Task<object> ConfirmPaymentAsync(ConfirmPaymentRequest request)
        {
            var token = this.httpClientFactory.Token(HttpClientFactory.APIType.ZohoSubscription).Result.AccessToken;

            // var userMapping = context.WpZohocustomerMapping.Where(u => u.UserId == long.Parse(request.UserId)).FirstOrDefault();
            ConfirmZohoPaymentRequest paymentRequest = new ConfirmZohoPaymentRequest();
            //if (User != null)
            //  paymentRequest.CustomerId = userMapping.ZohoCustomerId;
            //else
            paymentRequest.CustomerId = request.CustomerID;
            paymentRequest.PaymentMode = "other";
            paymentRequest.Amount = Convert.ToDecimal(request.Amount);
            // paymentRequest.Date = Convert.ToDateTime(request.InvoiceDate).ToShortDateString();
            paymentRequest.ReferenceNumber = request.ReferenceNumber;
            paymentRequest.Description = $"Payment has been added to Invoice and your Payment reference :  {paymentRequest.ReferenceNumber}";
            paymentRequest.Invoices = new List<Invoice>() { new Invoice() {
                InvoiceId =request.InvoiceID,
                AmountApplied=Convert.ToDecimal(request.Amount)
            } };
            var paymentURL = "https://subscriptions.zoho.com/api/v1/payments";
            var paymentResponse = await this.httpClientFactory.PostAsync<ConfirmZohoPaymentResponse, ConfirmZohoPaymentRequest>(paymentURL, paymentRequest
                , HttpClientFactory.APIType.ZohoSubscription, token);
            if (paymentResponse.result.Code == 0)
            {
                var paymentReferenceURL = $"https://subscriptions.zoho.com/api/v1/subscriptions/{request.SubscriptionID}/customfields";
                var updatePaymentReferenceRequest = new UpdatePaymentReferenceRequest();
                updatePaymentReferenceRequest.CustomFields = new List<PaymentReferenceCustomField>(){new PaymentReferenceCustomField()
            {
                Label = "PaymentReferenceNo",
                Value = request.ReferenceNumber
            } };

                var updatePaymentReferenceResponse = await this.httpClientFactory.PostAsync<UpdatePaymentReferenceResponse, UpdatePaymentReferenceRequest>(
                  paymentReferenceURL, updatePaymentReferenceRequest, HttpClientFactory.APIType.ZohoSubscription, token
                    );



                return (new
                {
                    Status = true,
                    Message = "Success",
                    Data = paymentResponse.result.Payment
                });
            }
            else
            {
                return (new { Status = false, Message = paymentResponse.result.Message });
            }

        }

        public async Task<object> GetSubscriptionHistoryAsync(string userID, string token)
        {
            //var token = this.httpClientFactory.Token().Result.AccessToken;
            var userMappings = await unitOfWork.ZohoCustomerMappingRepository.All();
            if (userMappings.Where(u => u.UserId == long.Parse(userID)).Count() > 0)
            {
                var userMapping = userMappings.Where(u => u.UserId == long.Parse(userID)).Single();
                var history = await this.httpClientFactory.GetAsync<GetSubscriptionsResponse>("https://subscriptions.zoho.com/api/v1/subscriptions?filter_by=SubscriptionStatus.ACTIVE", HttpClientFactory.APIType.ZohoSubscription, token);

                return (new
                {
                    Status = true,
                    Message = "Success",
                    AccessToken = history.token,
                    Data = (from s in history.result.Subscriptions.Where(s => s.CustomerId == userMapping.ZohoCustomerId)
                            from c in s.CustomFields
                            where (c.Label == "IsGift" && c.Value == "false")
                            select s)
                    .Select(d => new
                    {
                        Name = d.PlanName,
                        SubscriptionID = d.SubscriptionId,
                        EndDate = d.ExpiresAt,
                        StartDate = d.CurrentTermStartsAt,
                        CanTrack = d.Status == "live" ? true : false

                    })
                });

            }
            else
            {
                return (new { Status = true, Message = "No records found" });
            }
        }

        public async Task<object> TrackOrder(string userID, string subscriptionID,
                                                   string month, string zohoToken, string inventoryToken,string customerID)
        {
            var history = await this.httpClientFactory
                                    .GetAsync<GetSubscriptionsResponse>("https://subscriptions.zoho.com/api/v1/subscriptions?filter_by=SubscriptionStatus.ACTIVE",
                                                                         HttpClientFactory.APIType.ZohoSubscription,
                                                                         zohoToken);

            var inventories = await this.httpClientFactory
                                        .GetAsync<InventoryResponse>("https://inventory.zoho.com/api/v1/salesorders",
                                                                      HttpClientFactory.APIType.ZohoInventory,
                                                                      inventoryToken);

            var subscription = history.result.Subscriptions.Where(s => s.SubscriptionId == subscriptionID)
                                                           .Single();

            var user = await unitOfWork.UserRepository.Single(u => u.Id == long.Parse(userID));

            var userMapping = await unitOfWork.ZohoCustomerMappingRepository.Single(u => u.UserId == long.Parse(userID));

            //var subscriptions = history.result.Subscriptions
            //                                  .Where(s => s.CustomerId == userMapping.ZohoCustomerId
            //                                              && Convert.ToDateTime(s.CurrentTermStartsAt).Month >= Convert.ToInt32(month)
            //                                              && Convert.ToDateTime(s.CurrentTermEndsAt).Month <= Convert.ToInt32(month))
            //                                  .Where(s => !string.IsNullOrWhiteSpace(s.LastShipmentOrder)).ToList()
            //                                  .Select(s => s.LastShipmentOrder) ;
            // var inventory = inventories.result.Salesorders.Where(s => subscriptions.Any(a => s.SalesorderId.ToString() == a)).ToList();
            var data = inventories.result.Salesorders
                                  .Where(i => i.CustomerId == customerID
                                              && Convert.ToDateTime(i.Date).Year == DateTime.Now.Year
                                              && Convert.ToDateTime(i.Date).Month == Convert.ToInt32(month)
                                              && i.SalesorderId.ToString() == subscription.LastShipmentOrderID)
                                  .OrderByDescending(o => o.Date)
                                  .FirstOrDefault();
            if (data != null)
            {
                if (!string.IsNullOrWhiteSpace(inventories.token))
                    inventoryToken = inventories.token;
                var inventoryDetails = await this.httpClientFactory.GetAsync<SalesOrderDetailsResponse>($"https://inventory.zoho.com/api/v1/salesorders/{data.SalesorderId}", HttpClientFactory.APIType.ZohoInventory, inventoryToken);

                if (inventoryDetails.result.Code == 0)
                {
                    string Dispatched = "NA", Packaged = "NA", Delivered = "NA";
                    if (inventoryDetails.result.Salesorder.Packages.Count > 0)
                    {
                        if (inventoryDetails.result.Salesorder.Packages.First().Status == "not_shipped")
                        {
                            Packaged = inventoryDetails.result.Salesorder.Packages.First().Date.GetMonthNameYearDate();
                            Dispatched = "Not Yet";
                            Delivered = "Not Yet";
                        }
                        if (inventoryDetails.result.Salesorder.Packages.First().Status == "shipped")
                        {
                            Packaged = inventoryDetails.result.Salesorder.Packages.First().Date.GetMonthNameYearDate();
                            Dispatched = inventoryDetails.result.Salesorder.Packages.First().ShipmentDate.GetMonthNameYearDate();
                            Delivered = "Not Yet";
                        }
                        if (inventoryDetails.result.Salesorder.Packages.First().Status == "delivered")
                        {
                            Packaged = inventoryDetails.result.Salesorder.Packages.First().Date.GetMonthNameYearDate();
                            Dispatched = inventoryDetails.result.Salesorder.Packages.First().ShipmentDate.GetMonthNameYearDate();
                            Delivered = inventoryDetails.result.Salesorder.Packages.First().ShipmentDate.GetMonthNameYearDate();
                        }
                        return (new
                        {
                            Status = true,
                            Dispatched = Dispatched,
                            Packaged = Packaged,
                            Delivered = Delivered,
                            ZohoSubscriptionToken = history.token,
                            ZohoInventoryToken = inventories.token
                        });
                    }
                    else
                    {
                        return (new
                        {
                            Status = false,
                            Message = "There was no subscription or shipment is not yet created for the selected month",
                            Dispatched = "NA",
                            Packaged = "NA",
                            Delivered = "NA",
                            ZohoSubscriptionToken = history.token,
                            ZohoInventoryToken = inventories.token
                        });
                    }
                }
                else
                {
                    return (new
                    {
                        Status = false,
                        Message = "There was no subscription or shipment is not there for this month",
                        Dispatched = "NA",
                        Packaged = "NA",
                        Delivered = "NA",
                        ZohoSubscriptionToken = history.token,
                        ZohoInventoryToken = inventories.token
                    });
                }
            }
            else
            {
                return (new
                {
                    Status = false,
                    Message = "There was no subscription or shipment is not there for this month",
                    Dispatched = "NA",
                    Packaged = "NA",
                    Delivered = "NA",
                    ZohoSubscriptionToken = history.token,
                    ZohoInventoryToken = inventories.token
                });
            }
        }

        public async Task<object> GetDeliveries(string userID, string token, string inventoryToken)
        {
            List<DeliveriesModel> currentDeliveries = new List<DeliveriesModel>();
            List<DeliveriesModel> pastDeliveries = new List<DeliveriesModel>();

            var user = await unitOfWork.UserRepository.Single(u => u.Id == long.Parse(userID));


            var userMapping = await unitOfWork.ZohoCustomerMappingRepository.Single(u => u.UserId == long.Parse(userID));
            var customerID = userMapping.ZohoCustomerId;


            var history = await this.httpClientFactory
                                    .GetAsync<GetSubscriptionsResponse>("https://subscriptions.zoho.com/api/v1/subscriptions",
                                                                         HttpClientFactory.APIType.ZohoSubscription,
                                                                         token);

            var inventories = await this.httpClientFactory
                                     .GetAsync<InventoryResponse>("https://inventory.zoho.com/api/v1/salesorders",
                                                                   HttpClientFactory.APIType.ZohoInventory,
                                                                   inventoryToken);

            if (history.result.Code == 0)
            {
                var allSubscriptions = history.result.Subscriptions.Where(s => s.CustomerId == customerID).ToList();

                var allInventories = inventories.result.Salesorders.Where(s => s.CustomerId == customerID).ToList();

                var gifts = (from all in (from s in history.result.Subscriptions
                                          from c in s.CustomFields
                                          where (c.Label == "CreatedBy" && c.Value == userID)
                                          select s)
                             from p in all.CustomFields
                             where (p.Label == "IsGift" && p.Value == "true")
                             select all).ToList();

                if (gifts.Count > 0)
                {
                    gifts.ForEach(g =>
                    {
                        g.StartMonth = $"{Convert.ToDateTime(g.CurrentTermStartsAt).ToString("MMMM")}";
                        g.Date = $"{Convert.ToDateTime(g.CurrentTermStartsAt).ToString("MMMM")} {Convert.ToDateTime(g.CurrentTermStartsAt).ToString("yyyy")} - {Convert.ToDateTime(g.CurrentTermEndsAt).ToString("MMMM")}  {Convert.ToDateTime(g.CurrentTermEndsAt).ToString("yyyy")} ";

                    });
                }

                if (allSubscriptions.Count > 0)
                {
                    var subscriptions = (from s in allSubscriptions
                                         from c in s.CustomFields
                                         where (c.Label == "IsGift" && c.Value == "false")
                                         select s).OrderByDescending(s => Convert.ToDateTime(s.ActivatedAt)).ToList();

                    try
                    {
                        subscriptions.ForEach(s =>
                        {
                            s.StartMonth = $"{Convert.ToDateTime(s.CurrentTermStartsAt).ToString("MMMM")}";
                            s.Date = $"{Convert.ToDateTime(s.CurrentTermStartsAt).ToString("MMMM")} {Convert.ToDateTime(s.CurrentTermStartsAt).ToString("yyyy")} - {Convert.ToDateTime(s.CurrentTermEndsAt).ToString("MMMM")}  {Convert.ToDateTime(s.CurrentTermEndsAt).ToString("yyyy")} ";
                        });
                    }
                    catch (Exception ex)
                    {

                    }
                    var deliveredGiftsData = (from gift in gifts.ToList()
                                              join inventory in inventories.result.Salesorders on gift.LastShipmentOrderID equals inventory.SalesorderId.ToString()
                                              // where inventory.Status.Equals("delivered")
                                              where gift.Status.Equals("expired")
                                              select gift).ToList();
                    var shippedAndNotShippedGiftsData = (from gift in gifts.ToList()
                                                         join inventory in inventories.result.Salesorders on gift.LastShipmentOrderID equals inventory.SalesorderId.ToString()
                                                        // where inventory.Status.Equals("not_shipped") || inventory.Status.Equals("shipped") || inventory.Status.Equals("confirmed")
                                                         where gift.Status.Equals("live")
                                                         select gift).ToList();

                    var deliveredSubscriptionssData = (from subscription in subscriptions.ToList()
                                                       join inventory in inventories.result.Salesorders on subscription.LastShipmentOrderID equals inventory.SalesorderId.ToString()
                                                       //where inventory.Status.Equals("delivered")
                                                       where subscription.Status.Equals("expired")
                                                       select subscription).ToList();
                    var shippedAndNotShippedSubscriptionsData = (from subscription in subscriptions.ToList()
                                                                 join inventory in inventories.result.Salesorders on subscription.LastShipmentOrderID equals inventory.SalesorderId.ToString()
                                                                 //where inventory.Status.Equals("not_shipped") & inventory.Status.Equals("shipped") || inventory.Status.Equals("confirmed")
                                                                 where subscription.Status.Equals("live")
                                                                 select subscription).ToList();



                    currentDeliveries.AddRange(shippedAndNotShippedGiftsData.Where(s => s.Status == "live").Select(s => new DeliveriesModel() { Title = "Basket Gifts", Basket = s.PlanName, Date = s.Date, CustomerID = s.CustomerId, Name = s.CustomerName, SubscriptionID = s.SubscriptionId, StartMonth = s.StartMonth }));
                    currentDeliveries.AddRange(shippedAndNotShippedSubscriptionsData.Where(s => s.Status == "live").Select(s => new DeliveriesModel() { Title = "My Basket", Basket = s.PlanName, Date = s.Date, CustomerID = s.CustomerId, Name = s.CustomerName, SubscriptionID = s.SubscriptionId, StartMonth = s.StartMonth }));

                    pastDeliveries.AddRange(deliveredGiftsData.Where(s => s.Status == "expired").Select(s => new DeliveriesModel() { Title = "Basket Gifts", Basket = s.PlanName, Date = s.Date, CustomerID = s.CustomerId, Name = s.CustomerName, SubscriptionID = s.SubscriptionId, StartMonth = s.StartMonth }));
                    pastDeliveries.AddRange(deliveredSubscriptionssData.Where(s => s.Status == "expired").Select(s => new DeliveriesModel() { Title = "My Basket", Basket = s.PlanName, Date = s.Date, CustomerID = s.CustomerId, Name = s.CustomerName, SubscriptionID = s.SubscriptionId, StartMonth = s.StartMonth }));
                }

                return (new
                {
                    Deliveries = currentDeliveries,
                    PastDeliveries = pastDeliveries,
                });
            }
            else
            {
                return (new
                {
                    Deliveries = currentDeliveries,
                    PastDeliveries = pastDeliveries,
                });
            }



        }

        public async Task<object> GetAllGiftsHistory(string userID, string token)
        {
            //var token = this.httpClientFactory.Token().Result.AccessToken;
            var userMappings = await unitOfWork.ZohoCustomerMappingRepository.All();
            if (userMappings.Where(u => u.UserId == long.Parse(userID)).Count() > 0)
            {
                var userMapping = userMappings.Where(u => u.UserId == long.Parse(userID)).Single();
                var history = await this.httpClientFactory.GetAsync<GetSubscriptionsResponse>("https://subscriptions.zoho.com/api/v1/subscriptions?filter_by=SubscriptionStatus.ACTIVE", HttpClientFactory.APIType.ZohoSubscription, token);


                var    gifts = (from all in (from s in history.result.Subscriptions
                                      from c in s.CustomFields
                                      where (c.Label == "CreatedBy" && c.Value == userID)
                                      select s)
                         from p in all.CustomFields
                         where (p.Label == "IsGift" && p.Value == "true")
                         select all).ToList();

                if (gifts.Count > 0)
                {
                    gifts.ForEach(g =>
                    {

                        g.Date = $"{Convert.ToDateTime(g.CurrentTermStartsAt).ToString("MMMM")} {Convert.ToDateTime(g.CurrentTermStartsAt).ToString("yyyy")} - {Convert.ToDateTime(g.CurrentTermEndsAt).ToString("MMMM")}  {Convert.ToDateTime(g.CurrentTermEndsAt).ToString("yyyy")} ";

                    });
                }

                return (new
                {
                    Status = true,
                    Message = "Success",
                    AccessToken = history.token,
                    Data = gifts
                });

            }
            else
            {
                return (new { Status = true, Message = "No records found" });
            }
        }

        public async Task<object> GetSubscription(string userID,string subscriptionID,string token)
        {
            var history = await this.httpClientFactory.GetAsync<GetSubscriptionResponse>($"https://subscriptions.zoho.com/api/v1/subscriptions/{subscriptionID}", HttpClientFactory.APIType.ZohoSubscription, token);
            if (history.result.Code==0)
            {
                return (new
                {
                    Status = true,
                    Message = "Success",
                    AccessToken = history.token,
                    Data = history.result.Subscription
                });
            }
            else
            {
                return (new
                {
                    Status = false,
                    Message = "Something went wrong",
                    AccessToken = history.token
                });
            }
        }
    }
}
