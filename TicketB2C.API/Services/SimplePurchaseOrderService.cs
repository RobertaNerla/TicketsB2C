using TicketB2C.API.Models.Domain;
using TicketB2C.API.Models.DTO;
using TicketB2C.API.Repositories;

namespace TicketB2C.API.Services
{
    public class SimplePurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository purchaseOrderRepository;
        private readonly IPurchasedTicketService purchasedTicketService;

        public SimplePurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository, IPurchasedTicketService purchasedTicketService)
        {
            this.purchaseOrderRepository = purchaseOrderRepository;
            this.purchasedTicketService = purchasedTicketService;
            
        }
        //public async Task<PurchaseOrder> CreateAsync(InputBuyTicket inputBuyTicket)
        //{
        //    var newpurchasedTicket = await purchasedTicketService.CreateAsync(inputBuyTicket);

        //    PurchaseOrder purchaseOrder = new PurchaseOrder
        //    {
        //        PurchaseId = newpurchasedTicket.PurchaseId,
        //        Tickets = newpurchasedTicket,
        //        DateOfPurchase = DateTime.UtcNow,
        //        PayedAmount = newpurchasedTicket.PayedAmount * newpurchasedTicket.Quantity
        //    };

        //    purchaseOrderRepository.Save(purchaseOrder);
        //    return purchaseOrder;
        //}

        public async Task<PurchaseOrder> CreateAsyncV2(List<InputBuyTicket> inputBuyTickets)
        {
            var purchaseId = Guid.NewGuid();
            decimal totalPrice = 0.00M;
            List<PurchasedTicket> purchasedTickets = new List<PurchasedTicket>();
            foreach (var input in inputBuyTickets)
            {
                var newpurchasedTicket = await purchasedTicketService.CreateAsyncV2(input,purchaseId);
                purchasedTickets.Add(newpurchasedTicket);
                totalPrice += newpurchasedTicket.PayedAmount * newpurchasedTicket.Quantity;
            }

            PurchaseOrder purchaseOrder = new PurchaseOrder()
            {
                PurchaseId = purchaseId,
                Tickets = purchasedTickets,
                DateOfPurchase = DateTime.UtcNow,
                PayedAmount = totalPrice
            };

            purchaseOrderRepository.Save(purchaseOrder);
            return purchaseOrder;
        }

    }
}
