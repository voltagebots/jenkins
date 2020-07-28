using System;
using Grocedy.Core.Core;
using Grocedy.Domain.Models;

namespace Grocedy.Core.Repositories
{
    public class LogsRepository : Repository<WpLogs>
    {
        public LogsRepository(GrocedyContext context) : base(context)
        {
        }
    }
}
