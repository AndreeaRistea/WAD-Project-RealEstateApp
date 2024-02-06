using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentieImobiliarWeb.Models
{
	public class Estate
	{
		public int EstateId { get; set; }

        [DisplayName("Tipul proprietatii")]
        public int EstateTypeId { get; set; }

        [DisplayName("Status")]
        public int StatusId { get; set; }

        [DisplayName("Pret in euro")]
        public int Price { get; set; }

        [DisplayName("Oras")]
        public string? City { get; set; }

        [DisplayName("Adresa")]
        public string? Address { get; set; }

        [DisplayName("Descriere")]
        public string? Description { get; set; }

        [DisplayName("Tipul proprietatii")]
        public EstateType EstateType { get; set; }	
		public Status Status { get; set; }

		//public ICollection<ListEstate>? ListEstates { get; set; }

		public ICollection<Visualization>? Visualizations { get; set; }
	}
}
