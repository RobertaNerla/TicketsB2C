using AutoMapper;
using TicketB2C.API.Models.Domain;
using TicketB2C.API.Models.DTO;

namespace TicketB2C.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Ticket, TicketDto>()
                .ForMember(dest => dest.CarrierId, opt => opt.MapFrom(src => src.Carrier.CarrierId))
                .ForMember(dest => dest.CarrierDescription, opt => opt.MapFrom(src => src.Carrier.CarrierDescription))
                .ReverseMap();

            CreateMap<Carrier, CarrierDto>().ReverseMap();

            //CreateMap<InputBuyTicket, PurchaseOrder>()
            //    .ForMember(dest => dest.PurchaseId, opt => opt.MapFrom(src => Guid.NewGuid()))
            //    .ForMember(dest => dest.Tickets, opt=> opt.MapFrom(src => new PurchasedTicket()
            //    {
            //        PurchaseId = Guid.NewGuid(),
            //        TicketId = src.TicketId,
            //        Quantity = src.Quantity,
            //        PayedAmount
            //    }) )
        }
    }
}
