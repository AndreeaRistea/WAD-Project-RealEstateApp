using AgentieImobiliarWeb.Models;
using AgentieImobiliarWeb.Repositories;
using AgentieImobiliarWeb.Repositories.Interfaces;
using System.Linq.Expressions;

namespace AgentieImobiliarWeb.Services
{
	public class EstateService //: BaseService
	{
		private IEstateRepository _estateRepository;
		public EstateService(IEstateRepository estateRepository) // base(estateRepository)
		{
            _estateRepository = estateRepository;
		}

		public Estate GetEstateById(int id)
		{
			return _estateRepository.GetById(id);
		}

		public void AddEstate(Estate estate)
		{
            _estateRepository.Create(estate);
            _estateRepository.Save();
        }

		public void UpdateEstate(Estate estate)
		{
            _estateRepository.Update(estate);
            _estateRepository.Save();
        }

		public void DeleteEstate(int id)
		{
			var estate = _estateRepository.GetById(id);
			if(estate != null)
			{
                _estateRepository.Delete(estate);
                _estateRepository.Save();
            }
        }

        public Estate GetEstateAndRelatedById(int id)
        {
            return _estateRepository.GetByIdWithRelatedEntities(id);
        }

        public List<Estate> GetAllEstates()
		{
			return _estateRepository.GetAll().ToList();
		}

		public List<Estate> GetAllRentEstates()
		{
			return _estateRepository.GetAllRentEstate().ToList();
		}

		public List<Estate> GetSaleEstates()
		{
			return _estateRepository.GetSaleEstate().ToList();
		}

		public List<EstateType> GetAllEstateTypes()
		{
			return _estateRepository.GetAllEstateTypes().ToList(); 
		}

		public List<Status> GetAllStatuses()
		{
			return _estateRepository.GetAllStatuses().ToList();
        }

        public bool EstateExists(int id)
        {
            return _estateRepository.EstateExists(id);
        }
    }
}
