using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    [Serializable]
    public class TheaterRepertoire
    {
        public Author Author { get; set; }
        public Play Play { get; set; }
        public List<Date> Dates { get; set; } 
    }
}
