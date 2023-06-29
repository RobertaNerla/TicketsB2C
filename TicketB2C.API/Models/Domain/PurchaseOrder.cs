namespace TicketB2C.API.Models.Domain
{
    public class PurchaseOrder
    {
        public Guid PurchaseId { get; set; }
        public List<PurchasedTicket> Tickets { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public decimal PayedAmount { get; set; }


    }
}
