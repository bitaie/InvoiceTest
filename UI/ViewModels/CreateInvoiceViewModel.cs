using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.ViewModels
{
    public class CreateInvoiceViewModel
    {
<<<<<<< HEAD
        public Invoice Invoice { get; set; }
        public Item Item { get; set; }
        public IList<Item> Items { get; set; }
        public IEnumerable<string> Products { get; set; }
        public Customer Customer { get; set; }
=======
        public Customer customer { get; set; }
        public Invoice invoice { get; set; }
        public IEnumerable<Item> items { get; set; }
        public IEnumerable<Product> products { get; set; }
>>>>>>> test_branch
    }
}
