namespace Ticketr.Data.Models
{
    public class TicketSecondaryResource
    {
        public Guid TicketId { get; set; }
        public Guid SecondaryResourceId { get; set; }

        public Ticket? Ticket { get; set; }
        public ApplicationUser? SecondaryResource { get; set; }
    }
}
