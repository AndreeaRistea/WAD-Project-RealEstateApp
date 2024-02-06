using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgentieImobiliarWeb.Models
{
	public class Status
	{
		[Key]
		public int StatusId { get; set; }

        [DisplayName("Status")]
        public string? StatusName { get; set; }
		public ICollection<Estate>? Estates { get; set; }

        public ICollection<Announcement>? Announcements { get; set; }

	}
}
