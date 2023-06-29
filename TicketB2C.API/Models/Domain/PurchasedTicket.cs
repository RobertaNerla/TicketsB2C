namespace TicketB2C.API.Models.Domain
{
    public class PurchasedTicket
    {
        public Guid PurchaseId { get; set; }
        public string TicketId { get; set; }
        public int Quantity { get; set; }
        public decimal PayedAmount { get; set; }

    }
}
