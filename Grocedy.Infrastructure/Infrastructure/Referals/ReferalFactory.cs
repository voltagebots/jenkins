using System;
using System.Linq;
using Grocedy.Core.Core;
using System.Threading.Tasks;
using Grocedy.Domain.Models;

namespace GrocedyAPI.Infrastructure.Referals
{
    public class ReferalFactory
    {
        private IUnitOfWork unitOfWork;

        public ReferalFactory(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<(bool hasReferalCode, string referalCode)> CheckForReferalCode(string userID)
        {
            var referalDetails = await unitOfWork.UserReferalDetailsRepository.Find(u => u.UserId == userID);
            if (referalDetails.Count() == 0)
            {
                string referalCode = ReferalCodeGenerator(userID);
                await unitOfWork.UserReferalDetailsRepository.Add(new WpUserReferalDetails() { UserId = userID, Balance = "0", ReferalCode = referalCode, TotalEarnings = "" });
                await unitOfWork.SaveChangesAsync();
                return (hasReferalCode: true, referalCode: referalCode);

            }
            else
            {
                var referal = referalDetails.SingleOrDefault();
                return (hasReferalCode: true, referalCode: referal.ReferalCode);
            }

        }

        public async Task  AcceptReferal(string referedBy, string userID)
        {
            await unitOfWork.UserReferalMappingsRepository.Add(new WpUserreferalsMappings()
            {

                AcceptedDate = DateTime.Now,
                IsAccepted = 1,
                CreatedDate = DateTime.Now,
                ReferedBy = referedBy,
                RegisteredUserId = userID,
                TotalSubscriptions = 0
            });
            await unitOfWork.SaveChangesAsync();
        }

        public async Task< bool> IsFromReferal(string userID)
        {
            var hasReferal = await unitOfWork.UserReferalMappingsRepository.Find(u => u.RegisteredUserId == userID);
            return hasReferal.Count()>0;        }

        public async Task BookingFromReferal(string userID)
        {
            var referedByUser = await unitOfWork.UserReferalMappingsRepository.Single(u => u.RegisteredUserId == userID);
            var referedUserReferals = await unitOfWork.UserReferalDetailsRepository.Single(u => u.UserId == referedByUser.ReferedBy);
            if (referedUserReferals.CurrentSignUpsFromLastIntervalClaim+1 == 3)
            {
                //ref
            }

        }

        public void SendReferal()
        {

        }

        private string ReferalCodeGenerator(string userID)
        {
            var guid = Guid.NewGuid();
            var item = guid.ToString().Split('-')[1];
            string code = item + userID;
            return code;
        }

      
    }
}
