using EntityLayer.Concrete;
using EntityLayer.DTOs;

namespace BusinessLayer.Abstract
{
   public interface IWriterLoginService
    {
        Writer Register(WriterForRegisterDto writerForRegisterDto, string password);
        Writer Login(WriterForLoginDto userForLoginDto);
        bool UserExists(string email);
    }
}
