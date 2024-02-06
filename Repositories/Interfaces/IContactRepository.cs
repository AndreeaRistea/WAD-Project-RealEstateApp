using AgentieImobiliarWeb.Models;

namespace AgentieImobiliarWeb.Repositories.Interfaces
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAll();
         Contact GetById(int id);

        bool ContactsExists(int id);
        void Create(Contact contact);
        void Update(Contact contact);
        void Delete(Contact contact);

        void Save();
    }
}
