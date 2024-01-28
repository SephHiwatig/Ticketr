namespace Ticketr.Data.Models
{
    public class ClientContact
    {
        public int ClientId { get; set; }

        public Guid ApplicationUserId { get; set; }

        public Client? Client { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
