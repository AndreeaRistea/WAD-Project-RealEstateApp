using AgentieImobiliarWeb.Models;
using AgentieImobiliarWeb.Repositories;
using AgentieImobiliarWeb.Repositories.Interfaces;
using System.Linq.Expressions;

namespace AgentieImobiliarWeb.Services
{
	public class RequestEstateService //: BaseService
	{
		private IRequestEstateRepository _requestEstateRepository;
		public RequestEstateService(IRequestEstateRepository requestEstateRepository) //: base(requestEstateRepository)
		{
            _requestEstateRepository = requestEstateRepository;
		}

		public RequestEstate GetRequestEstateTypeById(int id)
		{
			return _requestEstateRepository.GetById(id);
		}

		public void AddRequestEstate(RequestEstate requestEstate)
		{
            _requestEstateRepository.Create(requestEstate);
            _requestEstateRepository.Save();
        }

		public void UpdateRequestEstate(RequestEstate requestEstate)
		{
            _requestEstateRepository.Update(requestEstate);
            _requestEstateRepository.Save();
        }

		public void DeleteRequestEstate(int id)
		{
			var request = _requestEstateRepository.GetById(id);
			if(request != null)
			{
                _requestEstateRepository.Delete(request);
                _requestEstateRepository.Save();
            }
        }

		public List<RequestEstate> GetAllRequestEstate()
		{
			return _requestEstateRepository.GetAll().ToList();
		}

       /* public List<Customer> GetAllCustomers()
        {
            return _requestEstateRepository.GetAllCustomers();
        }
       */
      /* public RequestEstate GetRequestEstateAndRelatedById(int id)
        {
            return _requestEstateRepository.GetByIdWithRelatedEntities(id);
        }*/

        public bool RequestEstateExists(int id)
        {
            return _requestEstateRepository.RequestEstateExists(id);
        }
    }
}
