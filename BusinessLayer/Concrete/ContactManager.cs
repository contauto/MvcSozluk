using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
   public class ContactManager:IContactService
    {
        IContactDal _contactdal;

        public ContactManager(IContactDal contactdal)
        {
            _contactdal = contactdal;
        }

        public void ContactAdd(Contact contact)
        {
            _contactdal.Insert(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            _contactdal.Update(contact);
        }

        public void ContactDelete(Contact contact)
        {
            _contactdal.Delete(contact);
        }

        public Contact GetById(int id)
        {
            return _contactdal.Get(x => x.ContactId == id);
        }

        public List<Contact> GetList()
        {
            return _contactdal.List();
        }
    }
}
