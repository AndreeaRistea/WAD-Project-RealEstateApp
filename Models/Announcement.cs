using NuGet.Packaging.Signing;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgentieImobiliarWeb.Models
{
	public class Announcement
	{
		public int AnnouncementId { get; set; }

        [DisplayName("Tipul proprietatii")]
        public int? EstateTypeId { get; set; }

        [DisplayName("Status")]
        public int StatusId { get; set; }
        //public int? CustomerId { get; set; }

        [DisplayName("Descriere")]
        public string? Description { get; set; }

        //[DisplayName("Data publicarii")]
        //[DataType(DataType.DateTime)]
        //public DateTime PublishingDate { get; set; }

        [DisplayName("Numele autorului")]
        public string AuthorName { get; set; }

        [DisplayName("Date de contact (adresa de email/telefon)")]
        public string DataContact { get; set; }

		public EstateType?	EstateType { get; set; }	

        public Status? Status { get; set; }
		//public Customer? Customer { get; set; }

}
}
