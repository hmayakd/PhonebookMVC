using PhonebookMVC.Models;

namespace PhonebookMVC.Services
{
    public interface IContactService
    {
        IEnumerable<Contact>? GetAll();
        Contact? Get(Guid id);
        void Create(int count);
        void Create(Contact? contact);
        void Update(Contact? contact);
        void Delete(Guid id);
    }
}
