using TicketB2C.API.Models.Domain;

namespace TicketB2C.API.Repositories
{
    public interface IPurchasedTicketRepository
    {
        void Save(PurchasedTicket purchasedTicket);
    }
}
