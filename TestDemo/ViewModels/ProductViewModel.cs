using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestDemo.ViewModels
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string SEName { get; set; }
        public string Description { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalesPrice { get; set; }
        public string Brand { get; set; }
        public bool Status { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}