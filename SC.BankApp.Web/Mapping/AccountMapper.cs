using SC.BankApp.Web.Data.Entities;
using SC.BankApp.Web.Models;

namespace SC.BankApp.Web.Mapping
{
    public class AccountMapper:IAccountMapper
    {
        public Account Map(AccountCreateModel model)
        {
            return new Account
            {
                AccountNumber = model.AccountNumber,
                ApplicationUserId = model.ApplicationUserId,
                Balance = model.Balance,


            };
        }
    }
}
