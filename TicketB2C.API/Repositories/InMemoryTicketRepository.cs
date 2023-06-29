using Microsoft.AspNetCore.Mvc.ApiExplorer;
using TicketB2C.API.Models.Domain;
using TicketB2C.API.Models.DTO;

namespace TicketB2C.API.Repositories
{
    public class InMemoryTicketRepository : ITicketRepository
    {
        private Dictionary<string, Ticket> database;
        public InMemoryTicketRepository() 
        {
            this.database = new Dictionary<string, Ticket>();

            database.Add("TCKATMA001", new Ticket()
            {
                TicketId = "TCKATMA001",
                TicketDescription = "Biglietto urbano orario",
                Carrier = new Carrier()
                {
                    CarrierId = "ATMA",
                    CarrierDescription = "Azienda Trasporti e Mobilita di Ancona"

                },

                Cost = 1.25M

            });

            database.Add("TCKTPER0101", new Ticket()
            {
                TicketId = "TCKTPER0101",
                TicketDescription = "Biglietto extraurbano giornaliero Bologna",
                Carrier = new Carrier()
                {
                    CarrierId = "TPER",
                    CarrierDescription = "Trasporto Passeggeri Emilia Romagna"

                },

                Cost = 5.00M

            });

        }
        
        public async Task<Ticket?> GetTicketByIdAsync(string id)
        {
           var existingTicket =  database.Values.FirstOrDefault(x => x.TicketId == id);
            if(existingTicket == null)
            {
                return null;
            }
            return existingTicket;
        }

        public async Task<List<Ticket>> GetTicketsAsync()
        {
            return database.Values.ToList(); 

        }
        
    }
}
