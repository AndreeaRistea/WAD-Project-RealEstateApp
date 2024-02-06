using AgentieImobiliarWeb.Models;

namespace AgentieImobiliarWeb.Repositories.Interfaces
{
	public interface IEstateTypeRepository //: IRepositoryBase<EstateType>
	{
        IEnumerable<EstateType> GetAll();
        EstateType GetById(int id);

        bool EstateTypeExists(int id);
        void Create(EstateType estateType);
        void Update(EstateType estateType);
        void Delete(EstateType estateType);

        void Save();
    }
}
