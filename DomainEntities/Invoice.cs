using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Invoice:BaseEntity
    {
        //public int Id { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public int CustomerId { get; set; }
        public int TotalPrice { get; set; }

    }
}
