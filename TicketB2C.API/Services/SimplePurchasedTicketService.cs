using TicketB2C.API.Models.Domain;
using TicketB2C.API.Models.DTO;
using TicketB2C.API.Repositories;

namespace TicketB2C.API.Services
{
    public class SimplePurchasedTicketService : IPurchasedTicketService
    {
        private readonly ITicketService ticketService;
        private readonly IPurchasedTicketRepository purchasedTicketRepository;

        public SimplePurchasedTicketService(ITicketService ticketService, IPurchasedTicketRepository purchasedTicketRepository )
        {
            this.ticketService = ticketService;
            this.purchasedTicketRepository = purchasedTicketRepository;
        }
        public async Task<PurchasedTicket> CreateAsync(InputBuyTicket inputBuyTicket)
        {
            var existingTicket = await ticketService.GetTicketById(inputBuyTicket.TicketId);
            PurchasedTicket purchasedTicket = new PurchasedTicket()
            {
                PurchaseId = Guid.NewGuid(),
                TicketId = inputBuyTicket.TicketId,
                Quantity = inputBuyTicket.Quantity,
                PayedAmount = existingTicket.Cost
            };

            purchasedTicketRepository.Save(purchasedTicket);
            return purchasedTicket;
            
        }

        public async Task<PurchasedTicket> CreateAsyncV2(InputBuyTicket inputBuyTicket, Guid purchasedId)
        {
            var existingTicket = await ticketService.GetTicketById(inputBuyTicket.TicketId);
            PurchasedTicket purchasedTicket = new PurchasedTicket()
            {
                PurchaseId = purchasedId,
                TicketId = inputBuyTicket.TicketId,
                Quantity = inputBuyTicket.Quantity,
                PayedAmount = existingTicket.Cost
            };

            purchasedTicketRepository.Save(purchasedTicket);
            return purchasedTicket;
        }
    }
}
