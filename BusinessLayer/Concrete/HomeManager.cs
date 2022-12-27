using System.Linq;
using DataAccessLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class HomeManager
    {
        private Context _context = new Context();

       public int[] GetCounts()
        {
            int[] count = new int[4];
            count[0]=_context.Headings.Count();
            count[1]=_context.Contents.Count();
            count[2]=_context.Writers.Count();
            count[3]=_context.Messages.Count();
            return count;
        }

        
    }
}