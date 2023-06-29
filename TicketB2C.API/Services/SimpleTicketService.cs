using TicketB2C.API.Models.Domain;
using TicketB2C.API.Repositories;

namespace TicketB2C.API.Services
{
    public class SimpleTicketService : ITicketService
    {
        private readonly ITicketRepository ticketRepository;

        public SimpleTicketService(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }
        public async Task<Ticket> GetTicketById(string ticketId)
        {
             var existingTicket = await ticketRepository.GetTicketByIdAsync(ticketId);
            if(existingTicket == null)
            {
                throw new InvalidOperationException($"Ticket with ID {ticketId} not found.");
            }
            return existingTicket;
        }

        public async Task<List<Ticket>> GetTicketsAsync()
        {
            return await ticketRepository.GetTicketsAsync();
        }
    }
}
