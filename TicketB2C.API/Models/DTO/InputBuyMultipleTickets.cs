namespace TicketB2C.API.Models.DTO
{
    public class InputBuyMultipleTickets : IInputBuyTickets
    {
        public List<InputBuyTicket> ticketsPurchased { get; set; }
    }
}
