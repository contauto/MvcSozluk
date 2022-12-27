
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
   public class Writer
    {
        [Key]
        public int WriterId { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "İsim alanı gereklidir")]
        public string WriterName { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Soyadı alanı gereklidir")]
        public string WriterSurname { get; set; }
        [StringLength(250)]
        public string WriterImage { get; set; }

        [StringLength(100)]
        public string WriterAbout { get; set; }
        [StringLength(200)]
        [Required(ErrorMessage = "Mail alanı gereklidir")]
        public string WriterMail { get; set; }
        
        public byte[] PasswordHash { get; set; }
        
        public byte[] PasswordSalt { get; set; }
        
        [StringLength(50)]
        public string WriterTitle { get; set; }
        public bool WriterStatus { get; set; }
        public int? RoleId { get; set; }
        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }
        public virtual Role Role { get; set; }
    }
}
