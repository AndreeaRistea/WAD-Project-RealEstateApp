using AgentieImobiliarWeb.Data;
using AgentieImobiliarWeb.Models;
using AgentieImobiliarWeb.Repositories.Interfaces;

namespace AgentieImobiliarWeb.Repositories
{
    public class EstateTypeRepository : IEstateTypeRepository //: RepositoryBase<EstateType>, IEstateTypeRepository
	{
        private EstateContext _context;
        public EstateTypeRepository(EstateContext context)
        {
            _context = context;

        }
        public IEnumerable<EstateType> GetAll()
        {
            return _context.EstateTypes.ToList();
        }

        public EstateType GetById(int id)
        {
            return _context.EstateTypes.FirstOrDefault(c => c.EstateTypeId == id);
        }

        public bool EstateTypeExists(int id)
        {
            return _context.EstateTypes.Any(c => c.EstateTypeId == id);
        }

        public void Create(EstateType estateType)
        {
            _context.EstateTypes.Add(estateType);
        }

        public void Delete(EstateType estateType)
        {
            _context.Remove(estateType);
        }

        public void Update(EstateType estateType)
        {
            _context.Update(estateType);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
