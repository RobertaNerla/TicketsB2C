﻿using TicketB2C.API.Models.Domain;
using TicketB2C.API.Models.DTO;

namespace TicketB2C.API.Repositories
{
    public interface IPurchaseOrderRepository
    {
        void Save(PurchaseOrder purchaseOrder);
    }
}
