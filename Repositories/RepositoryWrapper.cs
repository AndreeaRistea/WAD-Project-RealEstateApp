using AgentieImobiliarWeb.Data;
using AgentieImobiliarWeb.Repositories.Interfaces;

namespace AgentieImobiliarWeb.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
	{
		private EstateContext? _context;
		private IAnnouncementRepository? _announcementRepository;
		private IEstateRepository? _estateRepository;
		private IEstateTypeRepository? _estateTypeRepository;
		private IRequestEstateRepository? _requestEstateRepository;
		private IStatusRepository? _statusRepository;
		//private ICustomerRepository? _userRepository;
		private IVisualizationRepository? _visualizationRepository;
		//private IListEstateRepository? _listEstateRepository;
		public IAnnouncementRepository AnnouncementRepository
		{
			get
			{
				if(_announcementRepository == null)
				{
#pragma warning disable CS8604
					_announcementRepository = new AnnouncementRepository(_context);
#pragma warning disable CS8604
				}
				return _announcementRepository;
			}
		}

		public IEstateRepository EstateRepository {
			get
			{
				if(_estateRepository == null)
				{
#pragma warning disable CS8604
					_estateRepository = new EstateRepository(_context);
#pragma warning disable CS8604
				}
				return _estateRepository;
			} 
		}
		public IEstateTypeRepository EstateTypeRepository
		{
			get
			{
				if (_estateTypeRepository == null)
				{
#pragma warning disable CS8604
					_estateTypeRepository = new EstateTypeRepository(_context);
#pragma warning disable CS8604
				}
				return _estateTypeRepository;
			}
		}
		/*public IListEstateRepository ListEstateRepository
		{
			get
			{
				if(_listEstateRepository == null)
				{
#pragma warning disable CS8604
					_listEstateRepository = new ListEstateRepository(_context);
#pragma warning disable CS8604
				}
				return _listEstateRepository;
			}
		}*/
		public IRequestEstateRepository RequestEstateRepository
		{
			get
			{
				if (_requestEstateRepository == null)
				{
#pragma warning disable CS8604
					_requestEstateRepository = new RequestEstateRepository(_context);
#pragma warning disable CS8604
				}
				return _requestEstateRepository;
			}
		}
		public IStatusRepository StatusRepository
		{
			get
			{
				if(_statusRepository == null)
				{
#pragma warning disable CS8604
					_statusRepository = new StatusRepository(_context);
#pragma warning disable CS8604
				}
				return _statusRepository;
			}
		}
		/*public ICustomerRepository UserRepository
		{
			get
			{
				if(_userRepository == null)
				{
#pragma warning disable CS8604
					_userRepository = new CustomerRepository(_context);
#pragma warning disable CS8604
				}
				return _userRepository;
			}
		}*/
		public IVisualizationRepository VisualizationRepository
		{
			get
			{
				if (_visualizationRepository == null)
				{
#pragma warning disable CS8604
					_visualizationRepository = new VisualizationRepository(_context);
#pragma warning disable CS8604
				}
				return _visualizationRepository;
			}
		}

		public RepositoryWrapper(EstateContext estateContext)
		{
			_context = estateContext;
		}
		public void Save()
		{
#pragma warning disable CS8604
			_context.SaveChanges();
#pragma warning disable CS8604
		}
	}
}
