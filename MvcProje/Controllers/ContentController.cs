using BusinessLayer.Concrete;
using System.Web.Mvc;
using DataAccessLayer.EntityFramework;

namespace MvcProje.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager  _cm = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentvalues =  _cm.GetListByHeadingId(id);
            return View(contentvalues);
        }
        public ActionResult SearchingPage(string search)
        {
            if (search == null)
            {
                search = "";};
            var values =  _cm.GetList(search);
            return View(values);
        }
        
    }
}