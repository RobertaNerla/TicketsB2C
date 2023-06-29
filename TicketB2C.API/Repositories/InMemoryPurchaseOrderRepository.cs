using TicketB2C.API.Models.Domain;

namespace TicketB2C.API.Repositories
{
    public class InMemoryPurchaseOrderRepository : IPurchaseOrderRepository
    {
        private Dictionary<Guid, PurchaseOrder> database;
        public InMemoryPurchaseOrderRepository()
        {
            this.database = new Dictionary<Guid, PurchaseOrder>();
        }
        public void Save(PurchaseOrder purchaseOrder)
        {
            this.database.Add(purchaseOrder.PurchaseId, purchaseOrder);
        }
    }
}
