namespace EntityLayer.DTOs
{
    public class WriterForRegisterDto:IDto
    {
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public string WriterName { get; set; }
        public string WriterSurname { get; set; }
    }
}