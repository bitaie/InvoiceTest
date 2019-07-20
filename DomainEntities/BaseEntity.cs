using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BaseEntity
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public DateTime AddedDate
        {
            get
            {
                return AddedDate;
            }

            set { AddedDate = DateTime.Now; }
        }
        public DateTime ModifiedDate { get; set; }
        //public string IPAddress { get; set; }
    }
}
