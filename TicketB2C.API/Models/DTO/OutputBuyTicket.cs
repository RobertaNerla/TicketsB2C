using TicketB2C.API.Models.Domain;

namespace TicketB2C.API.Models.DTO
{
    public class OutputBuyTicket
    {
        public Guid PurchaseId { get; set; }
        public decimal PayedAmount { get; set; }
    }
}
