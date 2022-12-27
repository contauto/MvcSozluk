using System;
using System.Linq;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MvcProje.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        MessageManager _mm = new MessageManager(new EfMessageDal());
        HomeManager _hm = new HomeManager();

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            int[] counts = _hm.GetCounts();
            ViewBag.Heading = counts[0];
            ViewBag.Content = counts[1];
            ViewBag.Writer = counts[2];
            ViewBag.Message = counts[3];
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(Message m)
        {
            m.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.ReceiverMail = "admin@admin.com";
            m.MessageStatus = true;
            _mm.MessageAdd(m);
            return View();
        }
    }
}