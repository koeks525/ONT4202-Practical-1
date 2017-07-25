using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONT4202Practical01
{
    public class StockController
    {
        private List<StockItem> stockItemList;
        private static StockController stockController;

        private StockController()
        {
            stockItemList = new List<StockItem>();
        }

        public static StockController GetStockInstance()
        {
            if (stockController == null)
            {
                stockController = new StockController();
                return stockController;
            } else
            {
                return stockController;
            }
        }

        public void AddStockItem(StockItem newItem)
        {
            stockItemList.Add(newItem);
        }

        public void RemoveStockItem(StockItem item)
        {
            stockItemList.Remove(item);
        }

        public StockItem GetStockItem(int stockCode)
        {
            return stockItemList.First(i => i.StockCode == stockCode);
        }

        public List<StockItem> GetStockItems()
        {
            return stockItemList;
        }

        public double GetStockItemPrice(int stockItemCode)
        {
            StockItem selected = stockItemList.First(i => i.StockCode == stockItemCode);
            if (selected != null)
            {
                return selected.Price;
            } else
            {
                return -1;
            }
        }

        public bool UpdateStockItem(StockItem updateItem)
        {
            StockItem selected = stockItemList.First(i => i.StockCode == updateItem.StockCode);
            if (selected != null)
            {
                stockItemList.Remove(selected);
                stockItemList.Add(updateItem);
                return true;
            } else
            {
                return false;
            }
        }

        


    }
}
