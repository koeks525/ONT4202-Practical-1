using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONT4202Practical01
{
    public class Client
    {
        public int ClientID { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public double OutstandingBalance { get; set; }
        public String PhoneNumber { get; set; }
        public String EmailAddress { get; set; }
        public List<StockItem> purchasedStock;
        public override string ToString()
        {
            return Name + " " + Surname;
        }

        public Client()
        {
            purchasedStock = new List<StockItem>();
        }

        public void AddStockItem(StockItem newOne)
        {
            purchasedStock.Add(newOne);
        }

        public StockItem GetStockItem(int stockCode)
        {
            try
            {
                StockItem selected = purchasedStock.First(i => i.StockCode == stockCode);
                return selected;
            } catch (Exception error)
            {
                return null;
            }
        }

        public int GetStockItemCount()
        {
            int count = 0;
            foreach (StockItem item in purchasedStock)
            {
                count = count +  item.Count;
            }
            return count;
            
        }
    }
}
