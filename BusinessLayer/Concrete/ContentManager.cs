using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
            _contentDal.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            _contentDal.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            _contentDal.Update(content);
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(x=>x.ContentId==id);
        }

        public List<Content> GetList()
        {
            return _contentDal.List();
        }

        public List<Content> GetList(string search)
        {
            return _contentDal.List(x=>x.ContentValue.Contains(search));
        }

        public List<Content> GetListByHeadingId(int id)
        {
            return _contentDal.List(x => x.HeadingId == id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDal.List(x => x.WriterId == id);
        }
    }
}
