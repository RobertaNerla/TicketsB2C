namespace TicketB2C.API.Models.DTO
{
    public class TicketDto
    {
        public string TicketId { get; set; }
        public string TicketDescription { get; set; }
        public string CarrierId { get; set; }
        public string CarrierDescription { get; set; }

        //public CarrierDto Carrier { get; set; }
        public decimal Cost { get; set; }
    }
}
