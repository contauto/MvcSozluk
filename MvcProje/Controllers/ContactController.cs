using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager _cm = new ContactManager(new EfContactDal());
        
        public ActionResult Index()
        {
            var contactvalues =  _cm.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalues =  _cm.GetById(id);
            return View(contactvalues);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}