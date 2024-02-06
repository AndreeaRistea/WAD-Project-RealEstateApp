using NuGet.Packaging.Signing;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace AgentieImobiliarWeb.Models
{
	public class Visualization
	{
		public int VisualizationId { get; set; }

        [DisplayName("Descrierea proprietatii")]
        public int EstateId { get; set; }
        //public int CustomerId { get; set; }
        [DisplayName("Numele clientului")]
        public string ClientName { get; set; }

        [DisplayName("Telefon")]
        public string Telephone { get; set; }

        [DisplayName("Data vizionarii")]
        [DataType(DataType.DateTime)]
        public DateTime AppointmentDate { get; set; }
		public Estate? Estate { get; set; }
		//public Customer? Customer { get; set; }
	}
}
