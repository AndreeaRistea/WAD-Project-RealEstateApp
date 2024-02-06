using System.ComponentModel;

namespace AgentieImobiliarWeb.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        [DisplayName("Nume si prenume")]
        public string? AuthorName { get; set; }

        [DisplayName("Adresa dvs. de email")]
        public string? ContactEmail { get; set; }

        [DisplayName("Continut")]
        public string? ContactMessage { get; set; }
    }
}
