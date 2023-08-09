using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SC.BankApp.Web.Data.Context;
using SC.BankApp.Web.Data.Entities;
using SC.BankApp.Web.Data.Interfaces;
using SC.BankApp.Web.Data.Repositories;
using SC.BankApp.Web.Mapping;
using SC.BankApp.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace SC.BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        #region //*********GenericRepositotyden Önce Kullandığım Implementastonlar*******************//


        //private readonly BankContext _context;
        //private readonly IApplicationUserRepository _userRepository;
        //private readonly IUserMapper _userMapper;
        //private readonly IAccountRepository _accountRepository;
        //private readonly IAccountMapper _accountMapper;

        //public AccountController(BankContext context, IApplicationUserRepository userRepository, IUserMapper userMapper, IAccountRepository accountRepository , IAccountMapper accountMapper )
        //{
        //    _context = context;
        //    _userRepository = userRepository;
        //    _userMapper = userMapper;
        //    _accountRepository = accountRepository;
        //    _accountMapper = accountMapper;
        //}
        #endregion

        private readonly IRepository<Account> _accountrepository;
        private readonly IRepository<ApplicationUser> _appUserRepository;

        public AccountController(IRepository<Account> accountrepository, IRepository<ApplicationUser> appUserRepository)
        {
            _accountrepository = accountrepository;
            _appUserRepository = appUserRepository;
        }

        public IActionResult Create(int id)
        {
            var userInfo = _appUserRepository.GetById(id);
            return View(new UserListModel
            {
                Id = userInfo.Id,
                Name = userInfo.Name,
                SurName = userInfo.SurName


            });
        }
        [HttpPost]
        public IActionResult Create(AccountCreateModel model)
        {
            _accountrepository.Create(new Account
            {
                AccountNumber = model.AccountNumber,
                Balance = model.Balance,
                ApplicationUserId = model.ApplicationUserId,

            });
            
           
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult GetByUserId(int userId)
        {
            var query=_accountrepository.GetQueryable();
            var accounts= query.Where(x=>x.ApplicationUserId==userId).ToList();
            var user=_appUserRepository.GetById(userId);

            ViewBag.Fullname = user.Name + " " + user.SurName;

            var list = new List<AccountListModel>();
            foreach (var item in accounts)
            {
                list.Add(new()
                {
                    AccountNumber=item.AccountNumber,
                    Balance=item.Balance,
                    ApplicationUserId=item.ApplicationUserId,
                    Id=item.Id

                });
            }
            return View(list);
            
        }
        [HttpGet]
        public IActionResult SendMoney(int accountId)
        {
            var query= _accountrepository.GetQueryable();  
            var accounts=query.Where (x=>x.Id!=accountId).ToList();
                     
            var list = new List<AccountListModel>();

            ViewBag.SenderId = accountId;
            foreach(var account  in accounts)
            {
                list.Add(new()
                {
                    AccountNumber = account.AccountNumber,
                    ApplicationUserId = account.ApplicationUserId,  
                    Balance = account.Balance,
                    Id  =account.Id

                });

            }
         
            return View(new SelectList(list,"Id","AccountNumber"));
        }
        [HttpPost]
        public IActionResult SendMoney(SendMoneyModel model)
        {
            var senderAccount=_accountrepository.GetById(model.SenderId);
            senderAccount.Balance -= model.Amount;

            _accountrepository.Update(senderAccount);


           var account=_accountrepository.GetById(model.AccountId);

            account.Balance += model.Amount;
            _accountrepository.Update(account);

            return RedirectToAction("Index","Home");
        }

    }
}
