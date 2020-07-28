using System;
using Grocedy.Core.Core;
using Grocedy.Domain.Models;

namespace Grocedy.Core.Repositories
{
    public class UserReferalsMappingsRepository:Repository<WpUserreferalsMappings>
    {
        public UserReferalsMappingsRepository(GrocedyContext context):base(context)
        {
        }
    }
}
