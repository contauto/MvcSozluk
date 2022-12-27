using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager _hm=new HeadingManager(new EfHeadingDal());
        CategoryManager _cm = new CategoryManager(new EfCategoryDal());
        WriterManager _wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingvalues = _hm.GetList();
            return View(headingvalues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in _cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            List<SelectListItem> valuewriter = (from x in _wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurname,
                                                    Value = x.WriterId.ToString()
                                                }).ToList();
            ViewBag.vlw = valuewriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading h)
        {

            h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _hm.HeadingAdd(h);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in _cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            var headingvalue = _hm.GetById(id);
            return View(headingvalue);
        }
        public ActionResult EditHeading(Heading h)
        {
            _hm.HeadingUpdate(h);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingvalue = _hm.GetById(id);
            headingvalue.HeadingStatus = false;
            _hm.HeadingDelete(headingvalue);
            return RedirectToAction("Index");
        }
        public ActionResult HeadingReport()
        {
            var headingvalues = _hm.GetList();
            return View(headingvalues);
        }
    }
}