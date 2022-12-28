namespace EntityLayer.DTOs
{
    public class WriterForLoginDto:IDto
    {
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public bool RememberMe { get; set; }
    }
}