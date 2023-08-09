using SC.BankApp.Web.Data.Entities;
using System.Collections.Generic;

namespace SC.BankApp.Web.Data.Interfaces
{
    public interface IApplicationUserRepository
    {
        List<ApplicationUser>GetAll();
        ApplicationUser GetById(int id);
    }
}
