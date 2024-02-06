namespace AgentieImobiliarWeb.Repositories.Interfaces
{
	public interface IRepositoryWrapper
	{
		IAnnouncementRepository AnnouncementRepository { get; }
		IEstateRepository EstateRepository { get; }
		IEstateTypeRepository EstateTypeRepository { get; }
		//IListEstateRepository ListEstateRepository { get; }
		IRequestEstateRepository RequestEstateRepository { get; }
		IStatusRepository StatusRepository { get; }
		//ICustomerRepository UserRepository { get; }
		IVisualizationRepository VisualizationRepository { get; }
		void Save();
	}
}
