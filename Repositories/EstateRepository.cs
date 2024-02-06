using AgentieImobiliarWeb.Data;
using AgentieImobiliarWeb.Models;
using AgentieImobiliarWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgentieImobiliarWeb.Repositories
{
    public class EstateRepository :IEstateRepository //: RepositoryBase<Estate>, IEstateRepository
	{
            private EstateContext _context;
        public EstateRepository(EstateContext estateContext) //: base(estateContext)
        {
            _context = estateContext;
        }

        public void Create(Estate estate)
        {
            _context.Estates.Add(estate);
        }

        public void Delete(Estate estate)
        {
            _context.Remove(estate);
        }

        public IEnumerable<Estate> GetAll()
        {

            return _context.Estates.Include(e => e.EstateType)
                   .Include(e => e.Status);
        }

        public IEnumerable<Estate> GetAllRentEstate()
        {
            return _context.Estates.Include(e => e.EstateType)
                .Include(e => e.Status)
                .Where(e => e.Status.StatusName == "inchiriat");
        }

		public IEnumerable<Estate> GetSaleEstate()
		{
			return _context.Estates
				.Include(e => e.EstateType)
				.Include(e => e.Status)
				.Where(e => e.Status.StatusName == "vanzare");
		}

		public List<Status> GetAllStatuses()
        {
            return _context.Status.ToList();
        }

        public List<EstateType> GetAllEstateTypes()
        {
            return _context.EstateTypes.ToList();
        }

        public Estate GetById(int id)
        {
            return _context.Estates.Find(id);
        }

        public Estate GetByIdWithRelatedEntities(int id)
        {
            return _context.Estates.Include(e => e.EstateType)
                 .Include(s => s.Status)
                 .FirstOrDefault(m => m.EstateId == id);
        }

        public bool EstateExists(int id)
        {
            return _context.Estates.Any(o => o.EstateId == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Estate estate)
        {
            _context.Update(estate);
        }

    }
	
}
