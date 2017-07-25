using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONT4202Practical01
{
    public class StockItem
    {
        public int StockCode { get; set; }
        public String ItemName { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public override string ToString()
        {
            return ItemName + " " + Price;
        }
    }
}
