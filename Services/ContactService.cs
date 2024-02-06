using AgentieImobiliarWeb.Models;
using AgentieImobiliarWeb.Repositories.Interfaces;

namespace AgentieImobiliarWeb.Services
{
    public class ContactService
    {
        private IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository) //: base(userRepository)
        {
            _contactRepository = contactRepository;
        }

        public Contact GetContactById(int id)
        {
            return _contactRepository.GetById(id);
        }

        public void AddContact(Contact contact)
        {
            _contactRepository.Create(contact);
            _contactRepository.Save();
        }

        public void UpdateContact(Contact contact)
        {
            _contactRepository.Update(contact);
            _contactRepository.Save();
        }

        public void DeleteContact(int id)
        {
            var contact = _contactRepository.GetById(id);
            if (contact != null)
            {
                _contactRepository.Delete(contact);
                _contactRepository.Save();
            }
        }

        public List<Contact> GetAllContacts()
        {
            return _contactRepository.GetAll().ToList();
        }

        public bool ContactExists(int id)
        {
            return _contactRepository.ContactsExists(id);
        }
    }
}
