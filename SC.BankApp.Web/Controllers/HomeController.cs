using Microsoft.AspNetCore.Mvc;
using SC.BankApp.Web.Data.Context;
using SC.BankApp.Web.Data.Interfaces;
using SC.BankApp.Web.Data.Repositories;
using SC.BankApp.Web.Mapping;

namespace SC.BankApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankContext _context;
        private readonly IApplicationUserRepository _userRepository;
        private readonly IUserMapper _userMapper;

        public HomeController(BankContext bankContext, IApplicationUserRepository userRepository, IUserMapper userMapper)
        {
            this._context = bankContext;
            _userRepository = userRepository;
            _userMapper = userMapper;
        }

        public IActionResult Index()
        {

            return View(_userMapper.MapToListOfUserList( _userRepository.GetAll()));
        }
    }
}
