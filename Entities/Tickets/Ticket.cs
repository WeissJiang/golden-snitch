using golden_snitch.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace golden_snitch.Entities.Tickets
{
    [Comment("Tickets stands for the tasks with description and other props")]
    public class Ticket : GenericRecord
    {
        [Required] public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = "datetime")] public DateTime? DueDateUTC { get; set; }
        [JsonIgnore] public virtual List<TicketComment>? Comments { get; }
        [JsonIgnore] public virtual List<TicketHour>? Hours { get; }
        public int? TicketTagId { get; set; }
        [ForeignKey("TicketTagId")] public virtual TicketTag? Tag { get; set; }
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")] public virtual User Owner { get; set; }

        public int TaskId { get; set; }
        [ForeignKey("TaskId")] public virtual Task Task { get; set; }
    }

    public static class TicketProcess
    {
        public const int
            Todo = 0,
            InProgress = 1,
            Done = 2,
            OnHold = 3;
    }

    public static class TicketExtensions
    {
        public static IQueryable<Ticket> GetTickets(this IQueryable<Ticket> ticket)
        {
            return ticket
                .Include(t => t.Owner)
                .Include(t => t.Tag)
                .Include(t => t.Comments)
                .Include(t => t.Hours);
        }
    }
}
