using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONT4202Practical01
{
    public class OnlineSalesFacade
    {
        private ClientController clientController;
        private StockController stockController;
        private Notifier notifier;
        public OnlineSalesFacade(ClientController clientController, StockController stockController)
        {
            this.clientController = clientController;
            this.stockController = stockController;
            notifier = new Notifier();
        }

        public void SellItem(int stockItemID, int clientID, int numberToSell)
        {
            StockItem selectedItem = stockController.GetStockItem(stockItemID);
            Client selectedClient = clientController.GetClient(clientID);
            if (selectedClient != null && selectedItem != null)
            {
                selectedItem.Count = numberToSell;
                selectedClient.AddStockItem(selectedItem);
                //selectedItem.Count -= numberToSell;
                double totalOrderAmount = Math.Round((selectedItem.Price * numberToSell), 2);
                selectedClient.OutstandingBalance += totalOrderAmount;
                //stockController.UpdateStockItem(selectedItem);
                clientController.UpdateClient(selectedClient);
                notifier.SendEmail($"Dear {selectedClient.Name} \n\nYou made the following purchase:\n\n{selectedItem.ToString()}\nThe total cost for this order is R{totalOrderAmount}. \nThis brings your outstanding amount to R{selectedClient.OutstandingBalance}", "New Purchase Made", selectedClient.EmailAddress);
                notifier.DisplayText(selectedItem.ToString());
                
            } else
            {
                Console.WriteLine("No client or stock item found");
            }
        }

        public void UpdateItem(int stockItemID, double newPrice)
        {
            List<Client> clientList = new List<Client>();
            StockItem selectedItem = stockController.GetStockItem(stockItemID);
            if (selectedItem != null)
            {
                selectedItem.Price = Math.Round(newPrice, 2);
                bool isUpdated = stockController.UpdateStockItem(selectedItem);
                foreach (Client thisClient in clientController.GetClients())
                {
                    if (thisClient.GetStockItem(selectedItem.StockCode) != null)
                    {
                        clientList.Add(thisClient);
                    }
                }
                if (clientList != null)
                {
                    foreach (Client thisClient in clientList)
                    {
                        notifier.SendSMS($"Item {selectedItem.ItemName} price changed to {selectedItem.Price}", thisClient.PhoneNumber);
                    }
                } else
                {
                    Console.WriteLine("No Clients have purchased this item");
                }
            } else
            {
                Console.WriteLine("No item found with the selected code");
            }
        }

        //Why does the question ask us to send client ID? That means youre only notifying 1 client if theyre overdue??
        public void NotifyOverdue()
        {
            List<Client> overdueClients = new List<Client>();
            foreach (Client thisClient in clientController.GetClients())
            {
                if (thisClient.OutstandingBalance >= 1000)
                {
                    overdueClients.Add(thisClient);
                }
            }
            if (overdueClients.Count > 0)
            {
                foreach (Client thisClient in overdueClients)
                {
                    notifier.SendSMS($"Dear {thisClient.Name}, you have an outstanding balance of R{thisClient.OutstandingBalance}", thisClient.PhoneNumber);
                }
            } else
            {
                Console.WriteLine("No overdue clients");
            }
        }

        public void CalculateSpecial(int clientID, int stockCode)
        {
            Client selectedClient = clientController.GetClient(clientID);
            StockItem selectedItem = stockController.GetStockItem(stockCode);
            if (selectedClient != null && selectedItem != null)
            {
                int count = selectedClient.GetStockItemCount();
                if (selectedClient.GetStockItemCount() >= 10 && selectedClient.GetStockItemCount() <= 20)
                {
                    double amount = Math.Round(selectedItem.Price - (selectedItem.Price * 0.05), 2);
                    notifier.DisplayText($"You Qualify for a 5% discount on {selectedItem.ItemName}. Your new price is: R{amount}");
                    Console.WriteLine();
                } else if (selectedClient.GetStockItemCount() > 20)
                {
                    double amount = Math.Round(selectedItem.Price - (selectedItem.Price * 0.10), 2);
                    notifier.DisplayText($"You qualify for a 10% discount on {selectedItem.ItemName}. Your new price is R{amount}");
                    Console.WriteLine();
                }
            }
        }
    }
}
