using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDapperPagingSortingFilteringDemo.Domain
{
    public partial class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
    }

    public partial class Product
    {
        public int TotalCount { get; set; }
        public int FilteredCount { get; set; }
    }
}
