using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager _hm = new HeadingManager(new EfHeadingDal());
        ContentManager  _cm = new ContentManager(new EfContentDal());
        public ActionResult Headings()
        {
            var headinglist = _hm.GetList();
            return View(headinglist);
        }
        public PartialViewResult Index(int id=0)
        {
            var contentlist =  _cm.GetListByHeadingId(id);
            return PartialView(contentlist);
        }
    }
}