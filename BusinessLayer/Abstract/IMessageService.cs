using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
  public interface IMessageService
    {
        List<Message> GetListInbox(string s);
        List<Message> GetListSendbox(string s);
        
        List<Message> GetListDeleted(string s);
        void MessageAdd(Message message);
        Message GetById(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
        void MessageDelete(int id);
        List<Message> GetListInbox(string session,string search);
    }
}
