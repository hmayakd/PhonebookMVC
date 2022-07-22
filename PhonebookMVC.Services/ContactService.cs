using PhonebookMVC.Models;
using System.Data.SqlClient;

namespace PhonebookMVC.Services
{
    internal class ContactService : IContactService
    {
        static List<Contact> _contacts = new List<Contact>();
        public void Create(int count)
        {
            //for (int i = 0; i < count; i++)
            //{
            //    _contacts.Add(new Contact
            //    {
            //        Company = $"Default Company {i.ToString()}",
            //        Name = $"Default Name {i.ToString()}",
            //        Country = $"Default Country {i.ToString()}"
            //    });
            //}
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
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Phonebook;Persist Security Info=True;
                                        User ID=sa;Password=1234";
            string sqlExpression = "SELECT Contacts.Guid, Companies.Name, Employees.Name, Companies.Country " +
                                        "FROM((Contacts INNER JOIN Companies ON Contacts.Id_Company = Companies.Id) " +
                                        "INNER JOIN Employees ON Contacts.Id_Employee = Employees.Id)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read()) 
                    {
                        _contacts.Add(new Contact
                        {
                            Id = Guid.Parse(reader.GetValue(0).ToString()),
                            Company = reader.GetValue(1).ToString(),
                            Name = reader.GetValue(2).ToString(),
                            Country = reader.GetValue(3).ToString()
                            
                        });
                    }
                }
                reader.Close();
            }
            return _contacts;
        }


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