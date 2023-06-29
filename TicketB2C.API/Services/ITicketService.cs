using TicketB2C.API.Models.Domain;

namespace TicketB2C.API.Services
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetTicketsAsync();
        Task<Ticket> GetTicketById(string ticketId);
    }
}
