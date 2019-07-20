using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Item :BaseEntity
    {

        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
<<<<<<< HEAD
        public Product Product { get; set; }
=======
        public Product Product{ get; set; }
>>>>>>> test_branch
        public int Quantity { get; set; }
        public int Price { get; set; }

    }
}
