using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager _cm = new CategoryManager(new EfCategoryDal());
        [Authorize(Roles= "Admin")]
        public ActionResult Index()
        {
            var categoryvalues = _cm.GetList();
            return View(categoryvalues);
        }
        [HttpGet]
        public ActionResult AddCategory() { 
            return View();
    }
        [HttpPost]
        public ActionResult AddCategory(Category c) {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(c);
            if (results.IsValid)
            {
                _cm.CategoryAdd(c);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
    }
        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = _cm.GetById(id);
            _cm.CategoryDelete(categoryvalue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalue = _cm.GetById(id);
            return View(categoryvalue);
        }
        [HttpPost]
        public ActionResult EditCategory(Category c)
        {
            _cm.CategoryUpdate(c);
            return RedirectToAction("Index");
        }
    }
}
