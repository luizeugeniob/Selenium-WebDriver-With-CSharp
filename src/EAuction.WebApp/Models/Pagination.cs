using System.Collections.Generic;

namespace EAuction.WebApp.Models
{
    public class Pagination { }

    public class Page
    {
        public int Current { get; set; }
        public int Previous { get; set; }
        public int Next { get; set; }
        public int TotalRecords { get; set; }
    }

    public class Page<T>
    {
        public Page Info { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
