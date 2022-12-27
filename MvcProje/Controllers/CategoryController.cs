using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager _cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var categoryvalues =  _cm.GetList();
            return View(categoryvalues);
        }
        [HttpGet]

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category c)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(c);
            if (results.IsValid)
            {
                _cm.CategoryAdd(c);
                return RedirectToAction("GetCategoryList");
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
    }
}