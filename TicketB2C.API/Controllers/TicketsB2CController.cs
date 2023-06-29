using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketB2C.API.Models.DTO;
using TicketB2C.API.Repositories;
using TicketB2C.API.Services;

namespace TicketB2C.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsB2CController : ControllerBase
    {
        
        private readonly ITicketService ticketService;
        private readonly IPurchaseOrderService purchaseOrderService;
        private readonly IMapper mapper;

        public TicketsB2CController(ITicketService ticketService, IPurchaseOrderService purchaseOrderService, IMapper mapper)
        {
            
            this.ticketService = ticketService;
            this.purchaseOrderService = purchaseOrderService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            var listOfTicketsDomainModel = await ticketService.GetTicketsAsync();
            return Ok(new OutputGetTickets(mapper.Map<List<TicketDto>>(listOfTicketsDomainModel)));
        }

        [HttpPost]

        public async Task<IActionResult> BuyTicket([FromBody] List<InputBuyTicket> inputBuyTickets)
        {
            var purchasedOrderModel = await purchaseOrderService.CreateAsyncV2(inputBuyTickets);
            return Created("", new OutputBuyTicket()
            {
                PurchaseId = purchasedOrderModel.PurchaseId,
                PayedAmount = purchasedOrderModel.PayedAmount
            });
        }

        //[HttpPost]

        //public async Task<IActionResult> BuyTicket([FromBody] InputBuyTicket inputBuyTicket)
        //{
        //    var purchasedOrderModel = await purchaseOrderService.CreateAsync(inputBuyTicket);
        //    return Created("", new OutputBuyTicket()
        //    {
        //        PurchaseId = purchasedOrderModel.PurchaseId,
        //        PayedAmount = purchasedOrderModel.PayedAmount
        //    });
        //}
    }
}
