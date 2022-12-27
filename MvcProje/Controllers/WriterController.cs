
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class WriterController : Controller
    {
        WriterManager _wm = new WriterManager(new EfWriterDal());
        RoleManager _rm = new RoleManager(new EfRoleDal());
        WriterValidator _writervalidator = new WriterValidator();
        public ActionResult Index()
        {
            var writervalues = _wm.GetList();
            return View(writervalues);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer w)
        {
            
            ValidationResult result = _writervalidator.Validate(w);
            if (result.IsValid)
            {
                _wm.WriterAdd(w);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writerValue = _wm.GetById(id);
            var roleValue = writerValue.Role.RoleId;
            List<SelectListItem> valueRole = (from x in _rm.GetList()
                select new SelectListItem
                {
                    Selected = (x.RoleId==roleValue),
                    Text = x.RoleName,
                    Value = x.RoleId.ToString()
                }).ToList();
            ViewBag.userRole = valueRole;
            return View(writerValue);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer w)
        {
            ValidationResult result = _writervalidator.Validate(w);
            if (result.IsValid)
            {
                w.PasswordHash = w.PasswordHash;
                w.PasswordSalt = w.PasswordSalt;
                w.WriterStatus = true;
                _wm.WriterUpdate(w);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}