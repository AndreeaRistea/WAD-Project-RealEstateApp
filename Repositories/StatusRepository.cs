using AgentieImobiliarWeb.Data;
using AgentieImobiliarWeb.Models;
using AgentieImobiliarWeb.Repositories.Interfaces;

namespace AgentieImobiliarWeb.Repositories
{
    public class StatusRepository : IStatusRepository//: RepositoryBase<Status>, IStatusRepository
    {
        private EstateContext _context;
        public StatusRepository(EstateContext context)
        {
            _context = context;

        }
        public IEnumerable<Status> GetAll()
        {
            return _context.Status.ToList();
        }

        public Status GetById(int id)
        {
            return _context.Status.FirstOrDefault(c => c.StatusId == id);
        }

        public bool StatusExists(int id)
        {
            return _context.Status.Any(c => c.StatusId == id);
        }

        public void Create(Status status)
        {
            _context.Status.Add(status);
        }

        public void Delete(Status status)
        {
            _context.Remove(status);
        }

        public void Update(Status status)
        {
            _context.Update(status);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
