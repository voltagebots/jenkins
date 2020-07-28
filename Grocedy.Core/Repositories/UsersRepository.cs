using System;
using Grocedy.Core.Core;
using Grocedy.Domain.Models;

namespace Grocedy.Core.Repositories
{
    public class UsersRepository : Repository<WpUsers>
    {
        public UsersRepository(GrocedyContext context):base(context)
        {
        }
    }
}
