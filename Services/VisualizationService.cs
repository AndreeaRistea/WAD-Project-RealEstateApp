using AgentieImobiliarWeb.Models;
using AgentieImobiliarWeb.Repositories.Interfaces;
using Microsoft.CodeAnalysis.Elfie.Model.Tree;
using System.Linq.Expressions;

namespace AgentieImobiliarWeb.Services
{
	public class VisualizationService //: BaseService
	{
		private IVisualizationRepository _visualizationRepository;
		public VisualizationService(IVisualizationRepository visualizationRepository) //: base(visualizationRepository)
		{
            _visualizationRepository = visualizationRepository;
		}

		public Visualization GetVisualizationById(int id)
		{
			return _visualizationRepository.GetById(id);
		}

		public void AddVisualization(Visualization visualization)
		{
            _visualizationRepository.Create(visualization);
            _visualizationRepository.Save();
        }

		public void UpdateVisualization(Visualization visualization)
		{
            _visualizationRepository.Update(visualization);
            _visualizationRepository.Save();
        }

		public void DeleteVisualization(int id)
		{
			var visualization = _visualizationRepository.GetById(id);
			if(visualization != null)
			{
                _visualizationRepository.Delete(visualization);
                _visualizationRepository.Save();
            }
        }

        public Visualization GetVisualizationAndRelatedById(int id)
        {
            return _visualizationRepository.GetByIdWithRelatedEntities(id);
        }

        /*public List<Customer> GetAllCustomers()
        {
            return _visualizationRepository.GetAllCustomers();
        }*/

        public List<Estate> GetAllEstates()
        {
            return _visualizationRepository.GetAllEstates();
        }
        public List<Visualization> GetAllVisualization()
		{
			return _visualizationRepository.GetAll().ToList();
		}

        public bool VisualizationExists(int id)
        {
            return _visualizationRepository.VisualizationExists(id);
        }

    }
}
