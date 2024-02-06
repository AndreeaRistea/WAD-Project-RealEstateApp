using AgentieImobiliarWeb.Models;

namespace AgentieImobiliarWeb.Repositories.Interfaces
{
	public interface IRequestEstateRepository //: IRepositoryBase<RequestEstate>
	{
        IEnumerable<RequestEstate> GetAll();
       //RequestEstate GetByIdWithRelatedEntities(int id);

        RequestEstate GetById(int id);
        bool RequestEstateExists(int id);
        void Create(RequestEstate requestEstate);
        void Update(RequestEstate requestEstate);
        void Delete(RequestEstate requestEstate);

        void Save();


		// List<Customer> GetAllCustomers();
	}
}
