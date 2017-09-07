using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceModel
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string SEName { get; set; }
        public Nullable<decimal> CostPrice { get; set; }
        public Nullable<decimal> SalesPrice { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
