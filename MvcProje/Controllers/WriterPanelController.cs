using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList; 
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MvcProje.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager _hm = new HeadingManager(new EfHeadingDal());
        CategoryManager _cm = new CategoryManager(new EfCategoryDal());
        WriterManager _wm = new WriterManager(new EfWriterDal());
        Context _c = new Context();

        [HttpGet]
        public ActionResult WriterProfile()
        {
            string s = (string)Session["WriterMail"].ToString();

            var writerValue = _wm.GetByWriterMail(s);
            return View(writerValue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer w)
        {
            WriterValidator writervalidator = new WriterValidator();
            ValidationResult result = writervalidator.Validate(w);
            if (result.IsValid)
            {
                w.PasswordSalt = w.PasswordSalt;
                w.PasswordHash = w.PasswordHash;
                _wm.WriterUpdate(w);
                return RedirectToAction("AllHeadings","WriterPanel");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult MyHeading(string s)
        {
            s = (string)Session["WriterMail"];
            var writeridinfo = _c.Writers.Where(x => x.WriterMail == s).Select(y => y.WriterId).FirstOrDefault();
            var values = _hm.GetListByWriter(writeridinfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valuecategory = (from x in _cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading h)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = _c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterId).FirstOrDefault();
            h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            h.WriterId = writeridinfo;
            h.HeadingStatus = true;
            _hm.HeadingAdd(h);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in _cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            var headingValue = _hm.GetById(id);
            return View(headingValue);
        }
        public ActionResult EditHeading(Heading h)
        {
            _hm.HeadingUpdate(h);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingvalue = _hm.GetById(id);
            headingvalue.HeadingStatus = false;
            _hm.HeadingDelete(headingvalue);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeadings(int i=1)
        {
            var headings = _hm.GetList().ToPagedList(i,4);
            return View(headings);
        }

    }
}