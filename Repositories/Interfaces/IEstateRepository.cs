using AgentieImobiliarWeb.Models;

namespace AgentieImobiliarWeb.Repositories.Interfaces
{
	public interface IEstateRepository //: IRepositoryBase<Estate>
	{
        IEnumerable<Estate> GetAll();
        Estate GetByIdWithRelatedEntities(int id);

        Estate GetById(int id);
        bool EstateExists(int id);
        void Create(Estate estate);
        void Update(Estate estate);
        void Delete(Estate estate);

        void Save();

		IEnumerable<Estate> GetAllRentEstate();

		IEnumerable<Estate> GetSaleEstate();

		List<Status> GetAllStatuses();
        List<EstateType> GetAllEstateTypes();
    }
}
