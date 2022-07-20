namespace PhonebookMVC.Models
{
    public class Contact
    {
        public Contact()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string? Company { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
    }
}