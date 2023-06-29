using TicketB2C.API.Models.Domain;

namespace TicketB2C.API.Repositories
{
    public class InMemoryPurchasedTicketRepository : IPurchasedTicketRepository
    {
        private Dictionary<string, PurchasedTicket> database;
        public InMemoryPurchasedTicketRepository()
        {
            this.database = new Dictionary<string, PurchasedTicket>();
        }
        public void Save(PurchasedTicket purchasedTicket)
        {
            this.database.Add(purchasedTicket.PurchaseId.ToString() + purchasedTicket.TicketId, purchasedTicket);
        }
    }
}
