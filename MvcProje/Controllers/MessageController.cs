using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager _mm = new MessageManager(new EfMessageDal());
        MessageValidator _mv = new MessageValidator();
        [Authorize]
        public ActionResult Inbox(string search)
        {
            string session = (string)Session["WriterMail"];
            if (search == null)
            {
                search = "";
            }
            var messagelist = _mm.GetListInbox(session,search);
            TempData["in"] = messagelist.Count.ToString();
            return View(messagelist);
        }
        public ActionResult Sendbox()
        {
            string s = (string)Session["WriterMail"];
            var messagelist = _mm.GetListSendbox(s);
            TempData["send"] = messagelist.Count.ToString();
            return View(messagelist);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var messagevalue = _mm.GetById(id);
            return View(messagevalue);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var messagevalue = _mm.GetById(id);
            return View(messagevalue);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message m,String submitButton)
        {
            ValidationResult results = _mv.Validate(m);
            if (results.IsValid)
            {
                m.SenderMail=(string)Session["WriterMail"];
                m.SenderName = (string) Session["Name"];
                m.MessageDate =DateTime.Parse(DateTime.Now.ToShortDateString());
                switch(submitButton) {
                    case "Send":
                        m.MessageStatus = true;
                        break;
                        
                    case "Draft":
                        m.MessageStatus = false;
                        break;
                }
                _mm.MessageAdd(m);
                return RedirectToAction("Sendbox");
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
        public ActionResult Drafts()
        {
            string s = (string)Session["WriterMail"];
            var messagelist = _mm.GetListDrafted(s);
            TempData["drafts"] = messagelist.Count.ToString();
            return View(messagelist);
        }
        public ActionResult Trash()
        {
            string s = (string)Session["WriterMail"];
            var messagelist = _mm.GetListDeleted(s);
            TempData["trash"] = messagelist.Count.ToString();
            return View(messagelist);
        }

        public ActionResult Delete(FormCollection formCollection)
        {
            string[] ids = formCollection["ID"].Split(new char[]{ ',' });  
            foreach (string id in ids)  
            {  
                _mm.MessageDelete(Convert.ToInt32(id));
            }  
            return RedirectToAction("Inbox");
        }
    }
}