namespace Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TicketPrice { get; set; }
        public int TotalTickets { get; set; }
        public int AvaibleTickets { get; set; }
        
    }
}
