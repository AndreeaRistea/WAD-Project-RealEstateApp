using AgentieImobiliarWeb.Models;
using AgentieImobiliarWeb.Repositories.Interfaces;
using System.Linq.Expressions;

namespace AgentieImobiliarWeb.Services
{
	public class EstateTypeService //: BaseService
	{
		private IEstateTypeRepository _estateTypeRepository;

		public EstateTypeService(IEstateTypeRepository estateTypeRepository) //: base(estateTypeRepository)
		{
            _estateTypeRepository = estateTypeRepository;
		}

		public EstateType GetEstateTypeById (int id)
		{
			return _estateTypeRepository.GetById(id);
		}

		public void AddEstateType(EstateType estateType)
		{
            _estateTypeRepository.Create(estateType);
            _estateTypeRepository.Save();
		}

		public void UpdateEstateType(EstateType estateType)
		{
            _estateTypeRepository.Update(estateType);
            _estateTypeRepository.Save();
        }

		public void DeleteEstateType(int id)
		{
			var estateType = _estateTypeRepository.GetById(id);
			if (estateType != null)
			{
                _estateTypeRepository.Delete(estateType);
                _estateTypeRepository.Save();
            }
        }

		public List<EstateType> GetAllEstateTypes()
		{
			return _estateTypeRepository.GetAll().ToList();
		}

        public bool EstateTypeExists(int id)
        {
            return _estateTypeRepository.EstateTypeExists(id);
        }
    }
}
