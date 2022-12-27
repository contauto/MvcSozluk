using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager _cm = new ContentManager(new EfContentDal());
        Context _c = new Context();
        // GET: WriterPanelContent
        
        public ActionResult MyContent(string s)
        {
            
            s = (string)Session["WriterMail"];
            var writeridinfo = _c.Writers.Where(x => x.WriterMail == s).Select(y => y.WriterId).FirstOrDefault();
            var contentvalues = _cm.GetListByWriter(writeridinfo);
            return View(contentvalues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.data = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterMail"];
            var writeridinfo = _c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = writeridinfo;
            content.ContentStatus = true;
            _cm.ContentAdd(content);
            return RedirectToAction("MyContent");
        }
    }
}