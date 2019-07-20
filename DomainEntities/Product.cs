using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product:BaseEntity
    {
        //public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Brand { get; set; }
        [Required]
        public int Price { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
