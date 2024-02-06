using AgentieImobiliarWeb.Data;
using AgentieImobiliarWeb.Models;
using AgentieImobiliarWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgentieImobiliarWeb.Repositories
{
    public class VisualizationRepository : IVisualizationRepository //: RepositoryBase<Visualization>, IVisualizationRepository
    {
        private EstateContext _context;

        public VisualizationRepository(EstateContext context)
        {
            _context = context;
        }

        public void Create(Visualization visualization)
        {
            _context.Visualizations.Add(visualization);
        }

        public void Delete(Visualization visualization)
        {
            _context.Remove(visualization);
        }

        public IEnumerable<Visualization> GetAll()
        {
            return _context.Visualizations.Include(v => v.Estate);
        }

        /*public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }*/

        public List<Estate> GetAllEstates()
        {
            return _context.Estates.ToList();
        }

        public Visualization GetById(int id)
        {
            return _context.Visualizations.Find(id);
        }

        public Visualization GetByIdWithRelatedEntities(int id)
        {
            return _context.Visualizations.Include(v => v.Estate)
                .FirstOrDefault(m => m.VisualizationId == id);
        }

        public bool VisualizationExists(int id)
        {
            return _context.Visualizations.Any(o => o.VisualizationId == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Visualization visualization)
        {
            _context.Update(visualization);
        }
    }
}
