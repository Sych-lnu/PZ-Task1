using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int SupplierID { get; set; }
        public int Count { get; set; }
    }
}
