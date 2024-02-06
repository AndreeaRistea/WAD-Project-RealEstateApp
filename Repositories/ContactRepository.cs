using AgentieImobiliarWeb.Data;
using AgentieImobiliarWeb.Models;
using AgentieImobiliarWeb.Repositories.Interfaces;

namespace AgentieImobiliarWeb.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private EstateContext _context;
        public ContactRepository(EstateContext context)
        {
            _context = context;

        }
        public IEnumerable<Contact> GetAll()
        {
            return _context.Contacts.ToList();
        }

        public Contact GetById(int id)
        {
            return _context.Contacts.FirstOrDefault(c => c.ContactId == id);
        }

        public bool ContactsExists(int id)
        {
            return _context.Contacts.Any(c => c.ContactId == id);
        }

        public void Create(Contact contact)
        {
            _context.Contacts.Add(contact);
        }

        public void Delete(Contact contact)
        {
            _context.Remove(contact);
        }

        public void Update(Contact contact)
        {
            _context.Update(contact);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
