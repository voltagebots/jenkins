using System;
using Grocedy.Core.Core;
using Grocedy.Domain.Models;

namespace Grocedy.Core.Repositories
{
    public class UserReferalDetailsRepository:Repository<WpUserReferalDetails>
    {
        public UserReferalDetailsRepository(GrocedyContext context): base(context)
        {
        }
    }
}
