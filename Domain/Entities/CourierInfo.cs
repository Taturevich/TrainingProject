using System.Collections.Generic;

namespace Domain.Entities
{
    public class CourierInfo
    {
        public int UserId { get; set; }
        public int DateId { get; set; }
        public Category Category { get; set; }
        public List<Order> Orders { get; set; }
        public int Paid { get; set; }
        public int Ordered { get; set; }
        public bool IsPaid { get; set; }
    }
}
