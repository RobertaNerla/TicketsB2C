namespace TicketB2C.API.Models.Domain
{
    public class Ticket
    {
        public string TicketId { get; set; }
        public string TicketDescription { get; set; }
        public Carrier Carrier { get; set; }
        public decimal Cost { get; set; }
    }
}
