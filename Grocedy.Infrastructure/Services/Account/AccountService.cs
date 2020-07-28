using System;
using System.Linq;
using System.Threading.Tasks;
using CryptSharp;
using Grocedy.Core.Core;
using Grocedy.Domain.Models;
using Grocedy.Infrastructure.BusinessObjects;
using Grocedy.Infrastructure.Infrastructure;
using GrocedyAPI.DataModels.Account;
using GrocedyAPI.DataModels.Zoho;
using GrocedyAPI.DataModels.Zoho.Subscriptions.CreateSubscriptions;
using GrocedyAPI.Helpers;

namespace Grocedy.Infrastructure.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpClientFactory httpClientFactory;

        public AccountService(IUnitOfWork unitOfWork, IHttpClientFactory httpClientFactory)
        {
            this.unitOfWork = unitOfWork;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<object> CheckLoginAsync(Login request)
        {
            var user = await unitOfWork.UserRepository.Find(u => u.UserEmail == request.Email);

            if (user.ToList().Count == 0)
            {
                //User Not found
                return (new
                {
                    Status = false,
                    Message = "User not exists for the given email address"
                });
            }
            else
            {

                var userMeta = await unitOfWork.UsersMetaRepository.Find(u => u.MetaKey == "wpforms-pending" && u.UserId == user.Single().Id);
                bool userActivated = false;
                if (userMeta.ToList().Count > 0)
                {
                    //There are records and may be user account was activated

                    if (userMeta.Single().MetaValue == "0")
                    {
                        //User Activated
                        userActivated = true;
                    }
                    else
                    {
                        userActivated = false;
                    }
                }
                else
                {
                    userActivated = true;
                }
                if (userActivated)
                {
                    var status = Crypter.CheckPassword(request.Password, user.Single().UserPass);
                    //var status = WordPressPasswordUtil.IsValid(request.Password, user.Single().UserPass);
                    if (status)
                    {

                        //Valid User
                        return (new
                        {
                            Status = true,
                            Message = "Login Successfull",
                            UserID = user.Single().Id,
                            AccessToken = this.httpClientFactory.Token(HttpClientFactory.APIType.ZohoSubscription).Result.AccessToken,
                            ZohoInventoryAccessToken = this.httpClientFactory.Token(HttpClientFactory.APIType.ZohoInventory).Result.AccessToken,
                            UserDetails = GetUserDetails(Convert.ToString(user.Single().Id), user.First())
                        });
                    }
                    else
                    {
                        //Invalid User Name or Password
                        return (new
                        {
                            Status = false,
                            Message = "Invalid Password"
                        });
                    }
                }
                else
                {
                    //Invalid User Name or Passwords
                    return (new
                    {
                        Status = false,
                        Message = "Please activate your account",
                        UserID = user.Single().Id
                    });
                }
            }
        }

        public dynamic GetUserDetails(string userID, WpUsers user)
        {
            var usersMeta =  unitOfWork.UsersMetaRepository.All().Result;

            var billingFirstName = usersMeta.SingleOrDefault(u => u.MetaKey == "billing_first_name" & u.UserId == long.Parse(userID));

            var firstName = usersMeta.SingleOrDefault(u => u.MetaKey == "first_name" & u.UserId == long.Parse(userID));

            var lastName = usersMeta.SingleOrDefault(u => u.MetaKey == "last_name" & u.UserId == long.Parse(userID));

            var billingLastName = usersMeta.SingleOrDefault(u => u.MetaKey == "billing_last_name" & u.UserId == long.Parse(userID));

            var billingAddress1 = usersMeta.SingleOrDefault(u => u.MetaKey == "billing_address_1" & u.UserId == long.Parse(userID));
            
            var billingAddress2 = usersMeta.SingleOrDefault(u => u.MetaKey == "billing_address_2" & u.UserId == long.Parse(userID));

            var billingCity = usersMeta.SingleOrDefault(u => u.MetaKey == "billing_city" & u.UserId == long.Parse(userID));

            var billingPostCode = usersMeta.SingleOrDefault(u => u.MetaKey == "billing_postcode" & u.UserId == long.Parse(userID));

            var billingCountry = usersMeta.SingleOrDefault(u => u.MetaKey == "billing_country" & u.UserId == long.Parse(userID));

            var billingSstate = usersMeta.SingleOrDefault(u => u.MetaKey == "billing_state" & u.UserId == long.Parse(userID));

            var billingLandmark = usersMeta.SingleOrDefault(u => u.MetaKey == "billing_landmark" & u.UserId == long.Parse(userID));

            var billingPhone = usersMeta.SingleOrDefault(u => u.MetaKey == "billing_phone" & u.UserId == long.Parse(userID));

            var shippingAddress1 = usersMeta.SingleOrDefault(u => u.MetaKey == "shipping_address_1" & u.UserId == long.Parse(userID));

            var shippingAddress2 = usersMeta.SingleOrDefault(u => u.MetaKey == "shipping_address_2" & u.UserId == long.Parse(userID));

            var shippingCity = usersMeta.SingleOrDefault(u => u.MetaKey == "shipping_city" & u.UserId == long.Parse(userID));

            var shippingPostCode = usersMeta.SingleOrDefault(u => u.MetaKey == "shipping_postcode" & u.UserId == long.Parse(userID));

            var shippingCountry = usersMeta.SingleOrDefault(u => u.MetaKey == "shipping_country" & u.UserId == long.Parse(userID));

            var shippingSstate = usersMeta.SingleOrDefault(u => u.MetaKey == "shipping_state" & u.UserId == long.Parse(userID));

            var shippingLandmark = usersMeta.SingleOrDefault(u => u.MetaKey == "shipping_landmark" & u.UserId == long.Parse(userID));

            var shippingPhone = usersMeta.SingleOrDefault(u => u.MetaKey == "shipping_phone" & u.UserId == long.Parse(userID));



            return new
            {
                BillingAddress1 = billingAddress1?.MetaValue,
                BillingAddress2 = billingAddress2?.MetaValue,
                BillingCity = billingCity?.MetaValue,
                BillingCountry = billingCountry?.MetaValue,
                BillingFirstName = billingFirstName?.MetaValue,
                BillingLastName = billingLastName?.MetaValue,
                BillingLandmark = billingLandmark?.MetaValue,
                BillingPostCode = billingPostCode?.MetaValue,
                BillingSstate = billingSstate?.MetaValue,
                LastName = lastName?.MetaValue,
                FirstName = firstName?.MetaValue,
                Email = user.UserEmail,
                Phone = billingPhone?.MetaValue,
                shippingAddress1 = shippingAddress1?.MetaValue,
                shippingAddress2 = shippingAddress2?.MetaValue,
                shippingCity = shippingCity?.MetaValue,
                shippingCountry = shippingCountry?.MetaValue,
                shippingLandmark = shippingLandmark?.MetaValue,
                shippingPhone = shippingPhone?.MetaValue,
                shippingPostCode = shippingPostCode?.MetaValue,
                shippingSstate = shippingSstate?.MetaValue
            };

        }

        public async Task<object> ChangeDeliveryAddressAsync(ChangeDeliveryRequest request)
        {
            var userMetas = await unitOfWork.UsersMetaRepository.All();
            var userDetails = await unitOfWork.UserRepository.Get(long.Parse(request.UserID));
            var user = userMetas.Where(u => u.UserId == long.Parse(request.UserID)).Count();


            //Update
            if (userMetas.Where(u => u.MetaKey == "billing_first_name" & u.UserId == long.Parse(request.UserID)).Count() > 0)
            {
                var billingFirstName=   await unitOfWork.UsersMetaRepository.Single((u => u.MetaKey == "billing_first_name" & u.UserId == long.Parse(request.UserID)));
                
                billingFirstName.MetaValue = request.FirstName;
                 unitOfWork.UsersMetaRepository.Update(billingFirstName);
            }
            else
            {

                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = long.Parse(request.UserID),
                    MetaKey = "billing_first_name",
                    MetaValue = request.FirstName
                });

            }

            if (userMetas.Where(u => u.MetaKey == "billing_last_name" & u.UserId == long.Parse(request.UserID)).Count() > 0)
            {
                var billingFirstName = await unitOfWork.UsersMetaRepository.Single(u => u.MetaKey == "billing_last_name" & u.UserId == long.Parse(request.UserID));
                billingFirstName.MetaValue = request.LastName;
                unitOfWork.UsersMetaRepository.Update(billingFirstName);
            }
            else
            {
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = long.Parse(request.UserID),
                    MetaKey = "billing_last_name",
                    MetaValue = request.LastName
                });

            }

            if (userMetas.Where(u => u.MetaKey == "billing_address_1" & u.UserId == long.Parse(request.UserID)).Count() > 0)
            {
                var billingFirstName = await unitOfWork.UsersMetaRepository.Single(u => u.MetaKey == "billing_address_1" & u.UserId == long.Parse(request.UserID));
                billingFirstName.MetaValue = request.Address1;
                unitOfWork.UsersMetaRepository.Update(billingFirstName);
            }
            else
            {
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = long.Parse(request.UserID),
                    MetaKey = "billing_address_1",
                    MetaValue = request.Address1
                });

            }
            if (userMetas.Where(u => u.MetaKey == "billing_address_2" & u.UserId == long.Parse(request.UserID)).Count() > 0)
            {
                var billingFirstName = await unitOfWork.UsersMetaRepository.Single(u => u.MetaKey == "billing_address_2" & u.UserId == long.Parse(request.UserID));
                billingFirstName.MetaValue = request.Address2;
                unitOfWork.UsersMetaRepository.Update(billingFirstName);
            }
            else
            {
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = long.Parse(request.UserID),
                    MetaKey = "billing_address_2",
                    MetaValue = request.Address2
                });

            }
            if (userMetas.Where(u => u.MetaKey == "billing_city" & u.UserId == long.Parse(request.UserID)).Count() > 0)
            {
                var billingFirstName = await unitOfWork.UsersMetaRepository.Single(u => u.MetaKey == "billing_city" & u.UserId == long.Parse(request.UserID));
                billingFirstName.MetaValue = request.BillingCity;
                unitOfWork.UsersMetaRepository.Update(billingFirstName);
            }
            else
            {
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = long.Parse(request.UserID),
                    MetaKey = "billing_city",
                    MetaValue = request.BillingCity
                });

            }
            if (userMetas.Where(u => u.MetaKey == "billing_postcode" & u.UserId == long.Parse(request.UserID)).Count() > 0)
            {
                var billingFirstName = await unitOfWork.UsersMetaRepository.Single(u => u.MetaKey == "billing_postcode" & u.UserId == long.Parse(request.UserID));
                billingFirstName.MetaValue = request.BillingPostCode;
                unitOfWork.UsersMetaRepository.Update(billingFirstName);
            }
            else
            {
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = long.Parse(request.UserID),
                    MetaKey = "billing_postcode",
                    MetaValue = request.BillingPostCode
                });

            }
            if (userMetas.Where(u => u.MetaKey == "billing_country" & u.UserId == long.Parse(request.UserID)).Count() > 0)
            {
                var billingFirstName = await unitOfWork.UsersMetaRepository.Single(u => u.MetaKey == "billing_country" & u.UserId == long.Parse(request.UserID));
                billingFirstName.MetaValue = request.BillingCountry;
                unitOfWork.UsersMetaRepository.Update(billingFirstName);
            }
            else
            {
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = long.Parse(request.UserID),
                    MetaKey = "billing_country",
                    MetaValue = request.BillingCountry
                });

            }
            if (userMetas.Where(u => u.MetaKey == "billing_state" & u.UserId == long.Parse(request.UserID)).Count() > 0)
            {
                var billingFirstName = await unitOfWork.UsersMetaRepository.Single(u => u.MetaKey == "billing_state" & u.UserId == long.Parse(request.UserID));
                billingFirstName.MetaValue = request.BillingState;
                unitOfWork.UsersMetaRepository.Update(billingFirstName);
            }
            else
            {
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = long.Parse(request.UserID),
                    MetaKey = "billing_state",
                    MetaValue = request.BillingState
                });

            }
            if (userMetas.Where(u => u.MetaKey == "billing_landmark" & u.UserId == long.Parse(request.UserID)).Count() > 0)
            {
                var billingFirstName = await unitOfWork.UsersMetaRepository.Single(u => u.MetaKey == "billing_landmark" & u.UserId == long.Parse(request.UserID));
                billingFirstName.MetaValue = request.Landmark;
                unitOfWork.UsersMetaRepository.Update(billingFirstName);
            }
            else
            {
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = long.Parse(request.UserID),
                    MetaKey = "billing_landmark",
                    MetaValue = request.Landmark
                });

            }
            if (userMetas.Where(u => u.MetaKey == "billing_phone" & u.UserId == long.Parse(request.UserID)).Count() > 0)
            {
                var billingFirstName = await unitOfWork.UsersMetaRepository.Single(u => u.MetaKey == "billing_phone" & u.UserId == long.Parse(request.UserID));
                billingFirstName.MetaValue = request.BillingPhone;
                unitOfWork.UsersMetaRepository.Update(billingFirstName);
            }
            else
            {
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = long.Parse(request.UserID),
                    MetaKey = "billing_phone",
                    MetaValue = request.BillingPhone
                });

            }


            //Shipping Details
            if (userMetas.Where(u => u.MetaKey == "shipping_address_1" & u.UserId == long.Parse(request.UserID)).Count() > 0)
            {
                var billingFirstName = await unitOfWork.UsersMetaRepository.Single(u => u.MetaKey == "shipping_address_1" & u.UserId == long.Parse(request.UserID));
                billingFirstName.MetaValue = request.ShippingAddress1;
                unitOfWork.UsersMetaRepository.Update(billingFirstName);
            }
            else
            {
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = long.Parse(request.UserID),
                    MetaKey = "shipping_address_1",
                    MetaValue = request.ShippingAddress1
                });

            }
            if (userMetas.Where(u => u.MetaKey == "shipping_address_2" & u.UserId == long.Parse(request.UserID)).Count() > 0)
            {
                var billingFirstName = await unitOfWork.UsersMetaRepository.Single(u => u.MetaKey == "shipping_address_2" & u.UserId == long.Parse(request.UserID));
                billingFirstName.MetaValue = request.ShippingAddress2;
                unitOfWork.UsersMetaRepository.Update(billingFirstName);
            }
            else
            {
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = long.Parse(request.UserID),
                    MetaKey = "shipping_address_2",
                    MetaValue = request.ShippingAddress2
                });

            }
            if (userMetas.Where(u => u.MetaKey == "shipping_city" & u.UserId == long.Parse(request.UserID)).Count() > 0)
            {
                var billingFirstName = await unitOfWork.UsersMetaRepository.Single(u => u.MetaKey == "shipping_city" & u.UserId == long.Parse(request.UserID));
                billingFirstName.MetaValue = request.ShippingCity;
                unitOfWork.UsersMetaRepository.Update(billingFirstName);
            }
            else
            {
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = long.Parse(request.UserID),
                    MetaKey = "shipping_city",
                    MetaValue = request.ShippingCity
                });

            }
            if (userMetas.Where(u => u.MetaKey == "shipping_postcode" & u.UserId == long.Parse(request.UserID)).Count() > 0)
            {
                var billingFirstName = await unitOfWork.UsersMetaRepository.Single(u => u.MetaKey == "shipping_postcode" & u.UserId == long.Parse(request.UserID));
                billingFirstName.MetaValue = request.ShippingPostCode;
                unitOfWork.UsersMetaRepository.Update(billingFirstName);
            }
            else
            {
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = long.Parse(request.UserID),
                    MetaKey = "shipping_postcode",
                    MetaValue = request.ShippingPostCode
                });

            }
            if (userMetas.Where(u => u.MetaKey == "shipping_country" & u.UserId == long.Parse(request.UserID)).Count() > 0)
            {
                var billingFirstName = await unitOfWork.UsersMetaRepository.Single(u => u.MetaKey == "shipping_country" & u.UserId == long.Parse(request.UserID));
                billingFirstName.MetaValue = request.ShippingCountry;
                unitOfWork.UsersMetaRepository.Update(billingFirstName);
            }
            else
            {
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = long.Parse(request.UserID),
                    MetaKey = "shipping_country",
                    MetaValue = request.ShippingCountry
                });

            }
            if (userMetas.Where(u => u.MetaKey == "shipping_state" & u.UserId == long.Parse(request.UserID)).Count() > 0)
            {
                var billingFirstName = await unitOfWork.UsersMetaRepository.Single(u => u.MetaKey == "shipping_state" & u.UserId == long.Parse(request.UserID));
                billingFirstName.MetaValue = request.ShippingState;
                unitOfWork.UsersMetaRepository.Update(billingFirstName);
            }
            else
            {
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = long.Parse(request.UserID),
                    MetaKey = "shipping_state",
                    MetaValue = request.ShippingState
                });

            }
            if (userMetas.Where(u => u.MetaKey == "shipping_landmark" & u.UserId == long.Parse(request.UserID)).Count() > 0)
            {
                var billingFirstName = await unitOfWork.UsersMetaRepository.Single(u => u.MetaKey == "shipping_landmark" & u.UserId == long.Parse(request.UserID));
                billingFirstName.MetaValue = request.ShippingLandmark;
                unitOfWork.UsersMetaRepository.Update(billingFirstName);
            }
            else
            {
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = long.Parse(request.UserID),
                    MetaKey = "shipping_landmark",
                    MetaValue = request.ShippingLandmark
                });

            }
            if (userMetas.Where(u => u.MetaKey == "shipping_phone" & u.UserId == long.Parse(request.UserID)).Count() > 0)
            {
                var billingFirstName = await unitOfWork.UsersMetaRepository.Single(u => u.MetaKey == "shipping_phone" & u.UserId == long.Parse(request.UserID));
                billingFirstName.MetaValue = request.ShippingPhone;
                unitOfWork.UsersMetaRepository.Update(billingFirstName);

            }
            else
            {
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = long.Parse(request.UserID),
                    MetaKey = "shipping_phone",
                    MetaValue = request.ShippingPhone
                });

            }

                await unitOfWork.SaveChangesAsync();


            var userMappings = await unitOfWork.ZohoCustomerMappingRepository.All();
            request.CustomerID = userMappings.Where(u => u.UserId == long.Parse(request.UserID)).SingleOrDefault().ZohoCustomerId;

            var updateCustomer = await this.httpClientFactory.PutAsync<CreateCustomerResponse, CreateCustomerRequest>(
               $"https://subscriptions.zoho.com/api/v1/customers/{request.CustomerID}", new CreateCustomerRequest()
               {

                   FirstName = request.FirstName,
                   LastName = request.LastName,
                   BillingPhone = request.BillingPhone,
                   ShippingPhone = request.ShippingPhone,
                   BillingAddress = new BillingAddress()
                   {
                       Attention = $"{request.FirstName} {request.LastName}",
                       Country = "NG",
                       State = request.BillingState,
                       City = request.BillingCity,
                       Street = $"{request.Address1},{request.Address2}"
                   },
                   ShippingAddress = new ShippingAddress()
                   {
                       Attention = $"{request.FirstName} {request.LastName}",
                       Street = $"{request.ShippingAddress1},{request.ShippingAddress2}",
                       Country = "NG",
                       State = request.ShippingState,
                       City = request.ShippingCity
                   }

               }, HttpClientFactory.APIType.ZohoSubscription, request.Token
               );


            return (new
            {
                Status = true,
                Message = "Successfully updated the details",
                UserDetails = GetUserDetails(Convert.ToString(request.UserID), userDetails)
            });

        }

        public async Task<object> ChangePasswordAsync(ChangePasswordRequest request)
        {
            var user = await unitOfWork.UserRepository.Find(u => u.Id == long.Parse(request.UserID));
            var status = WordPressPasswordUtil.IsValid(request.OldPassword, user.Single().UserPass);
            if (!status)
            {
                //Old Password not matched
                return (new
                {
                    Status = false,
                    Message = "Your old Password doesn't match"
                });
            }
            else
            {
                //Change the Password
                var passwordHash = Crypter.Phpass.Crypt(request.NewPassword);

                var userDetails = user.Single();
                userDetails.UserPass = passwordHash;
                unitOfWork.UserRepository.Update(userDetails);
                await unitOfWork.SaveChangesAsync();
                return (new
                {
                    Status = true,
                    Message = "Password updated successfully"
                });

            }
        }

        public async Task<object> RegisterAsync(Register register)
        {
            var users = await unitOfWork.UserRepository.Find(u => u.UserEmail.Equals(register.Email));
            if (users.ToList().Count > 0)
            {
                return (new
                {
                    Status = false,
                    Message = "User with given email already exists"
                });
            }
            else
            {
                await unitOfWork.UserRepository.Add(new WpUsers()
                {
                    DisplayName = $"{register.FirstName} {register.LastName}",
                    UserEmail = register.Email,
                    UserStatus = 1,
                    UserPass = Crypter.Phpass.Crypt(register.Password),
                    UserLogin = register.Email,
                    UserNicename = register.Email.Replace('.', '-'),
                    UserRegistered = DateTime.Now,
                    UserActivationKey = string.Empty,
                    UserUrl = string.Empty
                });

                var user = await unitOfWork.UserRepository.Single(u => u.UserEmail.Equals(register.Email));
                var usersMeta = await unitOfWork.UsersMetaRepository.Find(u => u.MetaKey == "wpforms-pending" && u.UserId == user.Id);
                if (usersMeta.ToList().Count > 0)

                {
                    var userMeta = usersMeta.Single();
                    userMeta.MetaValue = "0";

                }
                else
                {
                    await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                    {
                        UserId = user.Id,
                        MetaKey = "wpforms-pending",
                        MetaValue = "1"
                    });
                }
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = user.Id,
                    MetaKey = "first_name",
                    MetaValue = register.FirstName
                });
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = user.Id,
                    MetaKey = "last_name",
                    MetaValue = register.LastName
                });
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = user.Id,
                    MetaKey = "nickname",
                    MetaValue = user.DisplayName
                });
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = user.Id,
                    MetaKey = "billing_first_name",
                    MetaValue = register.FirstName
                });
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = user.Id,
                    MetaKey = "billing_last_name",
                    MetaValue = register.LastName
                });
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = user.Id,
                    MetaKey = "shipping_first_name",
                    MetaValue = register.FirstName
                });
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = user.Id,
                    MetaKey = "shipping_last_name",
                    MetaValue = register.LastName
                });
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = user.Id,
                    MetaKey = "billing_phone",
                    MetaValue = register.PhoneNumber
                });
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = user.Id,
                    MetaKey = "billing_email",
                    MetaValue = register.Email
                });
                await unitOfWork.UsersMetaRepository.Add(new WpUsermeta()
                {
                    UserId = user.Id,
                    MetaKey = "wpforms-confirmation",
                    MetaValue = "639"
                });

                await unitOfWork.SaveChangesAsync();
                //var referalDetails = context.WpUserReferalDetails.Where(r => r.ReferalCode == register.ReferalCode).SingleOrDefault();
                //if (referalDetails != null)
                //{
                //    context.WpUserreferalsMappings.Add(new WpUserreferalsMappings() { });
                //}
                var ActivationLink = WordPressPasswordUtil.GetActivationLink(Convert.ToString(user.Id), user.UserEmail);
                //EmailHelper.Send(ActivationLink);

                EmailHelper email = new EmailHelper("sylendra92@gmail.com", register.Email, "[Grocedy] Your username and password info (Activation Required)", $"IMPORTANT: You must activate your account before you can login. Please visit the link below. {ActivationLink}");
                if (email.SendElastic())
                {
                    return (new
                    {
                        Status = true,
                        Message = "Registration Success",
                        UserID = user.Id,
                        UserDetails = GetUserDetails(Convert.ToString(user.Id), user),


                    });
                }
                else
                {
                    return (new
                    {
                        Status = true,
                        Message = "Registration Success , but failed to sent Activation Link .",
                        UserID = user.Id,
                        UserDetails = GetUserDetails(Convert.ToString(user.Id), user),


                    });
                }
            }

        }

        public async Task<object> ResendActivationLink(string userID, string email,string template)
        {
        
            //EmailHelper.Send(ActivationLink);

            EmailHelper emailHelper = new EmailHelper("sylendra92@gmail.com", email, "[Grocedy] Your username and password info (Activation Required)", template);
            if (emailHelper.SendElastic())
            {
                return (new
                {
                    Status = true,
                    Message = $"Please check your inbox ,we have sent invitation link to your email address {email} "
                });
            }
            else
            {
                return (new
                {   
                    Status = true,
                    Message = "Registration Success , but Failed to sent Activation Link .",
                    UserID = userID
                });
            }
        }

        public async Task<object> ForgotPasswordLink(string email)
        {
            var user = await unitOfWork.UserRepository.Find(u => u.UserEmail == email);
            var temporaryPassword = WordPressPasswordUtil.GetUniqID();
            var randomPassword = Crypter.Phpass.Crypt(temporaryPassword);
            
            
            if (user.ToList().Count == 0)
            {
                //User Not found
                return (new
                {
                    Status = false,
                    Message = "User not exists for the given email address"
                });
            }
            else
            {
                var userDetails = await unitOfWork.UserRepository.Single(u => u.Id == user.Single().Id);
                userDetails.UserPass = randomPassword;
                unitOfWork.UserRepository.Update(userDetails);
                await unitOfWork.SaveChangesAsync();
                var ActivationLink = WordPressPasswordUtil.GetForgotPasswordLink(Convert.ToString(user.Single().Id), email, temporaryPassword);

                EmailHelper emailHelper = new EmailHelper("sylendra92@gmail.com", email, "[Grocedy] Password Reset Request for Grocedy", $"Someone has requested a new password for the following account on Grocedy:. {ActivationLink}");
                if (emailHelper.SendElastic())
                {
                    return (new
                    {
                        Status = true,
                        Message = $"Please check your inbox ,we have sent randomly generated password  to your email address {email}."
                    });
                }
                else
                {
                    return (new
                    {
                        Status = true,
                        Message = "Success , but Failed to sent reset password Link ."
                    });
                }
            }
          
        }
    }
}
