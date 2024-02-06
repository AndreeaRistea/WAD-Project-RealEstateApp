using AgentieImobiliarWeb.Models;

namespace AgentieImobiliarWeb.Repositories.Interfaces
{
	public interface IAnnouncementRepository //: IRepositoryBase<Announcement>
	{
        IEnumerable<Announcement> GetAll();
        Announcement GetByIdWithRelatedEntities(int id);

        Announcement GetById(int id);
        bool AnnouncementExists(int id);
        void Create(Announcement announcement);
        void Update(Announcement announcement);
        void Delete(Announcement announcement);

        void Save();

       // List<Customer> GetAllCustomers();
        List<EstateType> GetAllEstateTypes();

        List<Status> GetAllStatus();
    }
}
