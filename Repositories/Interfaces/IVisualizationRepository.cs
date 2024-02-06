using AgentieImobiliarWeb.Models;
namespace AgentieImobiliarWeb.Repositories.Interfaces
{
	public interface IVisualizationRepository //: IRepositoryBase<Visualization>
	{
        IEnumerable<Visualization> GetAll();
        Visualization GetByIdWithRelatedEntities(int id);

        Visualization GetById(int id);
        bool VisualizationExists(int id);
        void Create(Visualization visualization);
        void Update(Visualization visualization);
        void Delete(Visualization visualization);

        void Save();

        //List<Customer> GetAllCustomers();
        List<Estate> GetAllEstates();
    }
}
