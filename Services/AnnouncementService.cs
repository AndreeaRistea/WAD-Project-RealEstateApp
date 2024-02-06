using AgentieImobiliarWeb.Models;
using AgentieImobiliarWeb.Repositories;
using AgentieImobiliarWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AgentieImobiliarWeb.Services
{
	public class AnnouncementService //: BaseService
	{
		private IAnnouncementRepository _announcementRepository;
		public AnnouncementService(IAnnouncementRepository announcementRepository) //: base(announcementRepository)
		{
            _announcementRepository = announcementRepository;
		}

		public Announcement GetAnnouncementById(int id)
		{
			return _announcementRepository.GetById(id);
		}

		public void AddAnnouncement(Announcement announcement)
		{
            _announcementRepository.Create(announcement);
            _announcementRepository.Save();
        }

		public void UpdateAnnouncement(Announcement announcement)
		{
            _announcementRepository.Update(announcement);
            _announcementRepository.Save();
        }

		public void DeleteAnnouncement(int id)
		{
			var announcement = _announcementRepository.GetById(id);
			if (announcement != null)
			{
                _announcementRepository.Delete(announcement);
                _announcementRepository.Save();
            }
        }

        public Announcement GetAnnouncementAndRelatedById(int id)
        {
            return _announcementRepository.GetByIdWithRelatedEntities(id);
        }

        public List<Announcement> GetAllAnnouncements()
		{
			return _announcementRepository.GetAll().ToList();
		}

		/*public List<Customer> GetAllCustomers()
		{
			return _announcementRepository.GetAllCustomers().ToList();
		}*/

		public List<EstateType> GetAllEstateTypes()
		{
			return _announcementRepository.GetAllEstateTypes().ToList();
		}

		public List<Status> GetAllStatus()
		{
			return _announcementRepository.GetAllStatus().ToList();
		}
        public bool AnnouncementExists(int id)
        {
            return _announcementRepository.AnnouncementExists(id);
        }
    }
}
