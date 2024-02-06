using AgentieImobiliarWeb.Models;
namespace AgentieImobiliarWeb.Repositories.Interfaces
{
	public interface IStatusRepository //: IRepositoryBase<Status>
	{
        IEnumerable<Status> GetAll();
        Status GetById(int id);

        bool StatusExists(int id);
        void Create(Status status);
        void Update(Status status);
        void Delete(Status status);

        void Save();
    }
}
