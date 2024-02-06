using AgentieImobiliarWeb.Models;
using AgentieImobiliarWeb.Repositories.Interfaces;
using System.Linq.Expressions;

namespace AgentieImobiliarWeb.Services
{
	public class StatusService// : BaseService
	{
		private IStatusRepository _statusRepository;
		public StatusService(IStatusRepository statusRepository) //: base(statusRepository)
		{
            _statusRepository = statusRepository;
		}

		public Status GetStatusById(int id)
		{
			return _statusRepository.GetById(id);
		}

		public void AddStatus(Status status)
		{
            _statusRepository.Create(status);
            _statusRepository.Save();
        }

		public void UpdateStatus(Status status)
		{
            _statusRepository.Update(status);
            _statusRepository.Save();
        }

		public void DeleteStatus(int id)
		{
			var status = _statusRepository.GetById(id);
			if (status != null)
			{
                _statusRepository.Delete(status);
                _statusRepository.Save();
            }
        }

		public List<Status> GetAllStatus()
		{
			return _statusRepository.GetAll().ToList();
		}

        public bool StatusExists(int id)
        {
            return _statusRepository.StatusExists(id);
        }
    }
}
