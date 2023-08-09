using SC.BankApp.Web.Data.Entities;
using SC.BankApp.Web.Models;
using System.Collections.Generic;

namespace SC.BankApp.Web.Mapping
{
    public interface IUserMapper
    {
        List<UserListModel> MapToListOfUserList(List<ApplicationUser> users);
       UserListModel MapUserList(ApplicationUser user);
    }
}
