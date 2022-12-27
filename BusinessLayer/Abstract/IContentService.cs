using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
   public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetList(string ara);
        List<Content> GetListByWriter(int id);
        List<Content> GetListByHeadingId(int id);
        void ContentAdd(Content content);
        Content GetById(int id);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);
    }
}
