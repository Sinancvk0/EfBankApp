using SC.BankApp.Web.Data.Context;
using SC.BankApp.Web.Data.Entities;
using SC.BankApp.Web.Data.Interfaces;

namespace SC.BankApp.Web.Data.Repositories
{
    public class AccountRepositorty:IAccountRepository
    {
        private readonly BankContext _context;

        public AccountRepositorty(BankContext context)
        {
            _context = context;
        }

        public void Create(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();


        }
    }
}
