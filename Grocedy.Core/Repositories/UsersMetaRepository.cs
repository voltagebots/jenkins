using System;
using Grocedy.Core.Core;
using Grocedy.Domain.Models;

namespace Grocedy.Core.Repositories
{
    public class UsersMetaRepository : Repository<WpUsermeta>
    {
        public UsersMetaRepository(GrocedyContext context) : base(context)
        {
        }
    }
}
