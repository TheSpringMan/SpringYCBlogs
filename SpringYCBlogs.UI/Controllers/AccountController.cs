using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.Mvc;
using SpringYCBlogs.UI.Infrastructure.Provider;
using SpringYCBlogs.UI.Models;
using SpringYCBlogs.Service;

namespace SpringYCBlogs.UI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService account)
        {
            this.accountService = account;
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool value = this.accountService.UserExist(x => x.UserName.ToLower() == model.UserName.ToLower() && x.Password.ToLower() == model.Password.ToLower());
                if (value)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "用户名或密码无效");
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (this.accountService.UserExist(x=>x.UserName.ToLower() == model.UserName || x.Email.ToLower() == model.UserName))
                {
                    ModelState.AddModelError("", "用户名或邮箱已注册，请直接登录。");
                    return View();
                }
                else
                {
                    this.accountService.AddUser(new Domain.Models.User
                    {
                        UserName = model.UserName,
                        Password = model.Password
                    });
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}