namespace TicketB2C.API.Models.DTO
{
    public class InputBuyTicket : IInputBuyTickets
    {
        public string TicketId { get; set; }
        public int Quantity { get; set; }
    }
}
