using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgentieImobiliarWeb.Models
{
	public class RequestEstate
	{
		[Key]
		public int RequestId { get; set; }
		//public int CustomerId { get; set; }
		[DisplayName("Nume client")]
		public string Name { get; set; }

        [DisplayName("Numarul de telefon")]
        public string? PhoneNumber { get; set; }
	

        [DisplayName("Descrierea proprietatii care va intereseaza")]
        public string? Details { get; set; }
		//public Customer Customer { get; set; }
		
	}
}
