using System.Collections.Generic;

namespace Domain.Entities
{
    public class CategoryInfo
    {
        public Date Date { get; set; }
        public Play Play { get; set; }
        public List<Category> Categories { get; set; }
        
    }
}
