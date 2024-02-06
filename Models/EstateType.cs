using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgentieImobiliarWeb.Models
{
	public class EstateType
	{
		[Key]
		public int EstateTypeId { get; set; }

        [DisplayName("Tip de proprietate")]
        public string? EstateTypeName { get; set;}
		public ICollection<Estate>? Estates { get; set; }
		public ICollection<Announcement>? Announcements { get; set; }

	}
}
