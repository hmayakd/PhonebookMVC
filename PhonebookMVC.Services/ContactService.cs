using PhonebookMVC.Models;

namespace PhonebookMVC.Services
{
    internal class ContactService : IContactService
    {
        static List<Contact> _contacts = new List<Contact>();
        public void Create(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _contacts.Add(new Contact
                {
                    Company = $"Default Company {i.ToString()}",
                    Name = $"Default Name {i.ToString()}",
                    Country = $"Default Country {i.ToString()}"
                });
            }
        }
        public void Create(Contact? contact)
        {
            if (contact != null)
                _contacts.Add(contact);
        }
        public void Delete(Guid id)
        {
            _contacts.RemoveAll(x => x.Id == id);
        }

        public Contact? Get(Guid id)
            => _contacts.FirstOrDefault(x => x.Id == id);

        public IEnumerable<Contact>? GetAll()
            => _contacts;

        public void Update(Contact? contact)
        {
            Contact? currentContact = _contacts.FirstOrDefault(c => c.Id == contact?.Id);
            int index = -1;
            if (currentContact != null)
                index = _contacts.IndexOf(currentContact);
            if (contact != null)
                _contacts[index] = contact;
        }
    }
}