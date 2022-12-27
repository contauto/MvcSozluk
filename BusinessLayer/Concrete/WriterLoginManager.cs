
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Utilities.Security.Hashing;

namespace BusinessLayer.Concrete
{
    public class WriterLoginManager : IWriterLoginService
    {
        readonly RoleManager _roleManager = new RoleManager(new EfRoleDal());
        readonly IWriterDal _writerDal;
         public WriterLoginManager(IWriterDal writerDal)
         {
             _writerDal = writerDal;
         }
        
        public Writer Register(WriterForRegisterDto writerForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var writer = new Writer
            {
                WriterMail = writerForRegisterDto.WriterMail,
                WriterName = writerForRegisterDto.WriterName,
                WriterSurname = writerForRegisterDto.WriterSurname,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                WriterStatus = true,
                WriterAbout = null,
                WriterImage = "https://cdn-icons-png.flaticon.com/512/149/149071.png",
                WriterTitle = null,
                Role = _roleManager.GetRoleById(2)
                
            };
            _writerDal.Insert(writer);
            return writer;
        }

        public Writer Login(WriterForLoginDto writerForLoginDto)
        {
            var userToCheck = _writerDal.Get(x => x.WriterMail == writerForLoginDto.WriterMail);
            if (userToCheck == null)
            {
                return null;
            }

            if (!HashingHelper.VerifyPasswordHash(writerForLoginDto.WriterPassword, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return null;
            }

            return userToCheck;
        }

        public bool UserExists(string email)
        {
            if (_writerDal.Get(x => x.WriterMail == email) != null)
            {
                return true;
            }
            return false;
        }

      
    }
}
