
using System.Web.Mvc;
using System.Web.Security;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.DTOs;

namespace MvcProje.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
         WriterLoginManager _writerLoginManager = new WriterLoginManager(new EfWriterDal());

        
        
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(WriterForLoginDto writerForLoginDto)
        {
            
            var userToLogin = _writerLoginManager.Login(writerForLoginDto);
            if (userToLogin==null)
            {
                return RedirectToAction("Login");
            }

            if (userToLogin!=null)
            {
              FormsAuthentication.SetAuthCookie(userToLogin.WriterMail,false);
              Session["Name"] = userToLogin.WriterName;
              Session["WriterMail"] = userToLogin.WriterMail;
              Session["Role"] = userToLogin.Role.RoleName;
              
                  if (userToLogin.Role.RoleId==1)
                  {
                      return RedirectToAction("Index", "AdminCategory");
                  
                  }
              
              return RedirectToAction("AllHeadings", "WriterPanel");
            
            }

            return RedirectToAction("Login");
            
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Register(WriterForRegisterDto writerForRegisterDto)
        {
            var userExists = _writerLoginManager.UserExists(writerForRegisterDto.WriterMail);
            if (userExists)
            {
                TempData["UserExist"] = "Hesabınız varmış";
                return RedirectToAction("Register");
            }
            _writerLoginManager.Register(writerForRegisterDto, writerForRegisterDto.WriterPassword);
            return RedirectToAction("Login");
        }
        
        
        
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings","Default");
        }
    }
}