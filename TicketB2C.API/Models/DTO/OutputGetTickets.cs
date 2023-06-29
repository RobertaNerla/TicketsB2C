namespace TicketB2C.API.Models.DTO
{
    public class OutputGetTickets
    {
        public List<TicketDto> Tickets { get; set; }

        public OutputGetTickets(List<TicketDto> tickets)
        {
            Tickets = tickets;
        }
    }
}
