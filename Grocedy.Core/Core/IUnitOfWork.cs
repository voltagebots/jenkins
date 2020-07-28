using System;
using System.Threading.Tasks;
using Grocedy.Domain.Models;

namespace Grocedy.Core.Core
{
    public interface IUnitOfWork
    {
        IRepository<WpUsers> UserRepository { get; }
        IRepository<WpUsermeta> UsersMetaRepository { get; }
        IRepository<WpZohocustomerMapping> ZohoCustomerMappingRepository { get; }
        IRepository<WpLogs> LogsRepository { get; }
        IRepository<WpUserpaymentsubcriptiondetails> UserPaymentSubscriptionDetailsRepository { get; }
        IRepository<WpUserreferalsMappings> UserReferalMappingsRepository { get; }
        IRepository<WpUserReferalDetails> UserReferalDetailsRepository { get; }
        Task SaveChangesAsync();
    }
}
