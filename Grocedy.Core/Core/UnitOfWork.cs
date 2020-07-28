using System;
using System.Threading.Tasks;
using Grocedy.Core.Repositories;
using Grocedy.Domain.Models;

namespace Grocedy.Core.Core
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly GrocedyContext context;
        public UnitOfWork(GrocedyContext context)
        {
            this.context = context;
        }

        private IRepository<WpUsers> _userRepository;
        public IRepository<WpUsers> UserRepository => _userRepository ??( _userRepository = new UsersRepository(context));

        private IRepository<WpUsermeta> _userMetaRepository;
        public IRepository<WpUsermeta> UsersMetaRepository => _userMetaRepository ?? (_userMetaRepository = new UsersMetaRepository(context));

        private IRepository<WpZohocustomerMapping> _zohoCustomerMappingRepository;
        public IRepository<WpZohocustomerMapping> ZohoCustomerMappingRepository => _zohoCustomerMappingRepository ?? (_zohoCustomerMappingRepository = new ZohoCustomerMappingRepository(context));

        private IRepository<WpLogs> _logsRepository;
        public IRepository<WpLogs> LogsRepository => _logsRepository ?? (_logsRepository = new LogsRepository(context));

        private IRepository<WpUserpaymentsubcriptiondetails> _userPaymentSubscriptionDetailsRepository;
        public IRepository<WpUserpaymentsubcriptiondetails> UserPaymentSubscriptionDetailsRepository => _userPaymentSubscriptionDetailsRepository ?? (_userPaymentSubscriptionDetailsRepository = new UserPaymentSubscriptionDetailsRepository(context));

        private IRepository<WpUserReferalDetails> _userReferalDetailsReository;
        public IRepository<WpUserReferalDetails> UserReferalDetailsRepository => _userReferalDetailsReository ??( _userReferalDetailsReository = new UserReferalDetailsRepository(context));

        private IRepository<WpUserreferalsMappings> _userReferalMappingsReository;
        public IRepository<WpUserreferalsMappings> UserReferalMappingsRepository => _userReferalMappingsReository ?? (_userReferalMappingsReository = new UserReferalsMappingsRepository(context));

        public async Task SaveChangesAsync()
        {
          var x =  await context.SaveChangesAsync();
        }
    }
}
