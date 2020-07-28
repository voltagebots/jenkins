using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Grocedy.Domain.Models;
using GrocedyAPI.DataModels.Zoho.Subscriptions.CreateSubscriptions;

namespace GrocedyAPI.Infrastructure.Zoho.Subscription
{
    public static class ZohoCreateSubscriptionFactory
    {
        public static CreateZohoSubscriptionForNewCustomerRequest CreateNewCustomerSubscription(CreateSubscriptionRequest request, WpUsers user, bool isGift,List<Addon> associatedAddons)
        {
            CreateZohoSubscriptionForNewCustomerRequest subscriptionRequest = new CreateZohoSubscriptionForNewCustomerRequest();


            subscriptionRequest.CustomFields = new List<CustomField>() { new CustomField() {
                Label="IsGift",
                Value=isGift?"true":"false"
            } , new CustomField(){
                Label = "CreatedBy",
                Value = request.UserID
            } };
            if (!isGift)
                subscriptionRequest.Customer = new Customer().CreateCustomerObject(request, user);
            else
                subscriptionRequest.Customer = new Customer().CreateCustomerForGiftObject(request, user);
            subscriptionRequest.Plan = new Plan().CreatePlanObject(request);
            subscriptionRequest.Addons = new List<Addon>().CreateAddOns(associatedAddons);
            return subscriptionRequest;
        }

        public static CreateZohoSubscriptionRequest CreateCustomerSubscription(CreateSubscriptionRequest request, WpUsers user, string customerID, bool isGift, List<Addon> associatedAddons)
        {
            CreateZohoSubscriptionRequest subscriptionRequest = new CreateZohoSubscriptionRequest();
            subscriptionRequest.CustomerID = customerID;
            subscriptionRequest.CustomFields = new List<CustomField>() { new CustomField() {
                Label="IsGift",
                Value=isGift?"true":"false"
            } , new CustomField(){
                Label = "CreatedBy",
                Value = request.UserID
            } };
            if (!isGift)
                subscriptionRequest.Customer = new Customer().CreateCustomerObject(request, user);
            else
                subscriptionRequest.Customer = new Customer().CreateCustomerForGiftObject(request, user);
            subscriptionRequest.Plan = new Plan().CreatePlanObject(request);
            subscriptionRequest.Addons = new List<Addon>().CreateAddOns(associatedAddons);
            return subscriptionRequest;
        }

        public static Customer CreateCustomerObject(this Customer customer, CreateSubscriptionRequest request, WpUsers user)
        {
            customer.BillingAddress = new BillingAddress()
            {
                Attention=$"{request.BillingAddress.Fax}",
                Country = "NG",
                State = request.BillingState,
                City = request.BillingCity,
                Street = request.BillingStreet
            };
            customer.CompanyName = request.CustomerName;
            //CountryCode = "NG",
            customer.DisplayName = $"{request.FirstName} {request.LastName}"; //user.DisplayName;
            customer.Email = user.UserEmail;
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.ShippingAddress = new ShippingAddress()
            {
                Attention = $"{request.ShippingFirstName} {request.ShippingLastName} ,{request.ShippingPhoneNo}",
                Country = "NG",
                State = request.ShippingState,
                City = request.ShippingCity,
                Street = request.ShippingStreet
            };
            return customer;
        }

        public static Customer CreateCustomerForGiftObject(this Customer customer, CreateSubscriptionRequest request, WpUsers user)
        {
            customer.BillingAddress = new BillingAddress()
            {
                Attention =$"{request.FirstName} {request.LastName}",
                Country = "NG",
                State = request.GiftBillingState,
                City = request.GiftBillingCity,
                Street = request.GiftBillingStreet,
                Fax = request.Phone
            };
            customer.CompanyName = request.GiftCustomerName;
            //CountryCode = "NG",
            customer.DisplayName = $"{request.GiftFirstName} {request.GiftLastName}"; //user.DisplayName;
            customer.Email = request.GiftEmail;
            customer.FirstName = request.GiftFirstName;
            customer.LastName = request.GiftLastName;
            customer.CustomerSubType = "Individual";
            customer.Mobile = request.ShippingPhoneNo;
            customer.Phone = request.Phone;
            customer.ShippingAddress = new ShippingAddress()
            {
                Attention = $"{request.GiftFirstName} {request.GiftLastName}",
                Country = "NG",
                State = request.GiftShippingState,
                City = request.GiftShippingCity,
                Street = request.GiftShippingStreet,
                Fax = request.ShippingPhoneNo
            };
            return customer;
        }

        public static Plan CreatePlanObject(this Plan plan, CreateSubscriptionRequest request)
        {
            plan.BillingCycles = GetCycles(Convert.ToDateTime(request.SubscriptionStartDate, System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat), Convert.ToDateTime(request.SubscriptionEndDate, System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat));

            //plan.BillingCycles = GetCycles(DateTime.ParseExact(request.SubscriptionStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact(request.SubscriptionEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture));

            plan.PlanCode = request.PlanCode;
            plan.Quantity = 1;
            plan.Price = request.Amount;
            return plan;
        }

        public static List<Addon> CreateAddOns(this List<Addon> addons,List<Addon> associatedAddons)
        {
            addons = new List<Addon>();
            foreach (var item in associatedAddons)
            {
                addons.Add(item);
            }
            return addons;
        }

        public static int GetCycles(DateTime start, DateTime end)
        {
            //if (start > end)
            //    return GetCycles(end, start);

            //int months = 0;
            //do
            //{
            //    start = start.AddMonths(1);
            //    if (start > end)
            //        return months;

            //    months++;
            //}
            //while (true);
            int numMonths = 0;
            while (start < end)
            {
                start = start.AddMonths(1);
                numMonths++;
            }
            return numMonths;
        }

        //public static object CreateCouponObject() {
        //}
    }




}
