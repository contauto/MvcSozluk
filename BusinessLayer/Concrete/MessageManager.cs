using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;
namespace BusinessLayer.Concrete
{
   public class MessageManager:IMessageService
    {
         IMessageDal _messagedal;

        public MessageManager(IMessageDal messagedal)
        {
            _messagedal = messagedal;
        }

        public Message GetById(int id)
        {
            return _messagedal.Get(x => x.MessageId == id);
        }

        public List<Message> GetListInbox(string session)
        {
            return _messagedal.List(x => x.ReceiverMail==session && x.MessageStatus==true);
        }
        
        public List<Message> GetListDeleted(string s)
        {
            return _messagedal.List(x => (x.ReceiverMail == s ) && x.MessageStatus==false);
        }
        
        public List<Message> GetListDrafted(string s)
        {
            return _messagedal.List(x => ( x.SenderMail == s) && x.MessageStatus==false);
        }

        public List<Message> GetListSendbox(string s)
        {
            return _messagedal.List(x => x.SenderMail == s && x.MessageStatus==true);
        }

        public void MessageAdd(Message message)
        {
            _messagedal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            message.MessageStatus = false;
            _messagedal.Update(message);
        }

        public void MessageUpdate(Message message)
        {
            _messagedal.Update(message);
        }

        public void MessageDelete(int id)
        {
            var message = _messagedal.Get(x => x.MessageId == id);
            message.MessageStatus = false;
            _messagedal.Update(message);
            
        }

        public List<Message> GetListInbox(string session, string search)
        {
            return _messagedal.List(x=>x.ReceiverMail==session && x.MessageStatus==true &&
                (x.SenderMail.Contains(search) || x.Subject.Contains(search) || x.MessageContent.Contains(search)));
        }
    }
}
