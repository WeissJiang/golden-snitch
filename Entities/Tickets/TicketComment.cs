using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace golden_snitch.Entities.Tickets
{
    public class TicketComment : GenericRecord
    {
        public int Id { get; set; }
        public string Comment { get; set; } = string.Empty; // Optional by convention, can be null
  
        [Required] public int TicketId { get; set; }
        [ForeignKey("TicketId")] public virtual Ticket Ticket { get; set; }
    }
}
