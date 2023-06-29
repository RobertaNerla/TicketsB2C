using TicketB2C.API.Models.Domain;
using TicketB2C.API.Models.DTO;

namespace TicketB2C.API.Services
{
    public interface IPurchasedTicketService
    {
        
        Task<PurchasedTicket> CreateAsync(InputBuyTicket inputBuyTicket);
        Task<PurchasedTicket> CreateAsyncV2(InputBuyTicket inputBuyTicket, Guid purchasedId);
    }
}
