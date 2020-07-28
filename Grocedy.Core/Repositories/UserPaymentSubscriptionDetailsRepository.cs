using System;
using Grocedy.Core.Core;
using Grocedy.Domain.Models;

namespace Grocedy.Core.Repositories
{
    public class UserPaymentSubscriptionDetailsRepository : Repository<WpUserpaymentsubcriptiondetails>
    {
        public UserPaymentSubscriptionDetailsRepository(GrocedyContext context) : base(context)
        {
        }
    }
}
