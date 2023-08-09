using SC.BankApp.Web.Data.Configurations;
using SC.BankApp.Web.Data.Entities;

namespace SC.BankApp.Web.Data.Interfaces
{
    public interface IAccountRepository
    {
        void Create(Account account);
    }
}
