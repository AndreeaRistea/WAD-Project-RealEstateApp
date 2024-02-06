using AgentieImobiliarWeb.Data;
using AgentieImobiliarWeb.Models;
using AgentieImobiliarWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AgentieImobiliarWeb.Repositories
{
    public class AnnouncementRepository : IAnnouncementRepository //: RepositoryBase<Announcement>, IAnnouncementRepository
	{
		private EstateContext _context;
		public AnnouncementRepository(EstateContext estateContext) //: base(estateContext)
		{
			_context = estateContext;
		}

        public void Create(Announcement announcement)
        {
            _context.Announcements.Add(announcement);
        }

        public void Delete(Announcement announcement)
        {
            _context.Remove(announcement);
        }

        public IEnumerable<Announcement> GetAll()
        {
            return _context.Announcements.Include(a => a.EstateType)
                .Include(s=>s.Status);
        }

       /* public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }*/

        public List<EstateType> GetAllEstateTypes()
        {
            return _context.EstateTypes.ToList();
        }

        public List<Status> GetAllStatus()
        {
            return _context.Status.ToList();
        }

        public Announcement GetById(int id)
        {
            return _context.Announcements.Find(id);
        }

        public Announcement GetByIdWithRelatedEntities(int id)
        {
            return _context.Announcements.Include(a => a.EstateType)
                .Include(s => s.Status)
                .FirstOrDefault(m => m.AnnouncementId == id);
        }

        public bool AnnouncementExists(int id)
        {
            return _context.Announcements.Any(o => o.AnnouncementId == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Announcement announcement)
        {
            _context.Update(announcement);
        }
    }
}
