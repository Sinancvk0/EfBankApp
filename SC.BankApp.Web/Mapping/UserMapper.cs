using SC.BankApp.Web.Data.Entities;
using SC.BankApp.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace SC.BankApp.Web.Mapping
{
    public class UserMapper:IUserMapper
    {
        public List<UserListModel> MapToListOfUserList(List<ApplicationUser> users)
        {
            return users.Select(x => new UserListModel
            {
                Id = x.Id,
                Name = x.Name,
                SurName = x.SurName
            }).ToList();
        }
        public UserListModel MapUserList(ApplicationUser user)
        {
            return new UserListModel
            {
                Id = user.Id,
                Name = user.Name,
                SurName = user.SurName
            };

        }

       
    }
}
