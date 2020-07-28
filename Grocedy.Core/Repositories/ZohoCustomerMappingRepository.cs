using System;
using Grocedy.Core.Core;
using Grocedy.Domain.Models;

namespace Grocedy.Core.Repositories
{
    public class ZohoCustomerMappingRepository:Repository<WpZohocustomerMapping>
    {
        public ZohoCustomerMappingRepository(GrocedyContext context):base(context)
        {
        }
    }
}
