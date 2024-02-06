using AgentieImobiliarWeb.Data;
using AgentieImobiliarWeb.Models;
using AgentieImobiliarWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgentieImobiliarWeb.Repositories
{
    public class RequestEstateRepository : IRequestEstateRepository//: RepositoryBase<RequestEstate>, IRequestEstateRepository
    {
        private EstateContext _context;

        public RequestEstateRepository(EstateContext context)
        {
            _context = context;
        }

        public void Create(RequestEstate requestEstate)
        {
            _context.RequestEstates.Add(requestEstate);
        }

        public void Delete(RequestEstate requestEstate)
        {
            _context.Remove(requestEstate);
        }

        public IEnumerable<RequestEstate> GetAll()
        {
            return _context.RequestEstates;

		}

       /* public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }*/

        public RequestEstate GetById(int id)
        {
            return _context.RequestEstates.Find(id);
        }


		
		/*public RequestEstate GetByIdWithRelatedEntities(int id)
        {
            return _context.RequestEstates.Include(t => t.EstateType)
                .Include(s=>s.Status)
                .FirstOrDefault(m => m.RequestId == id);
        }*/

		public bool RequestEstateExists(int id)
        {
            return _context.RequestEstates.Any(o => o.RequestId == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(RequestEstate requestEstate)
        {
            _context.Update(requestEstate);
        }
    }
}

