using TicketB2C.API.Models.Domain;
using TicketB2C.API.Models.DTO;

namespace TicketB2C.API.Services
{
    public interface IPurchaseOrderService
    {
        //Task<PurchaseOrder> CreateAsync(InputBuyTicket inputBuyTicket);

        Task<PurchaseOrder> CreateAsyncV2(List<InputBuyTicket> inputBuyTickets);
    }
}
