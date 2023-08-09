using SC.BankApp.Web.Data.Entities;
using SC.BankApp.Web.Models;

namespace SC.BankApp.Web.Mapping
{
    public interface IAccountMapper
    {
        public Account Map(AccountCreateModel model);
    }
}
