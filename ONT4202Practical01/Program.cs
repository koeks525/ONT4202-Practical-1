using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONT4202Practical01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "ONT4101 Practical 01 Okuhle Ngada s213215136";
            Client clientOne = new Client()
            {
                ClientID = 1,
                Name = "Okuhle",
                Surname = "Ngada",
                EmailAddress = "okuhle.ngada@outlook.com",
                PhoneNumber = "0829534225",
                OutstandingBalance = 0,
            };
            Client clientTwo = new Client()
            {
                ClientID = 2,
                Name = "Samantha",
                Surname = "Windlings",
                EmailAddress = "samantha.windlings@gmail.com",
                PhoneNumber = "0651234951",
                OutstandingBalance = 0,
            };
            Client clientThree = new Client()
            {
                ClientID = 3,
                Name = "Lihle",
                Surname = "Ngumbela",
                EmailAddress = "lihle.ngumbela@gmail.com",
                PhoneNumber = "0821924832",
                OutstandingBalance = 0,
            };
            Client clientFour = new Client()
            {
                ClientID = 4,
                Name = "Sharkeesha",
                Surname = "Trevon",
                EmailAddress = "sharkeesha@gmail.com",
                PhoneNumber = "0113750392",
                OutstandingBalance = 0
            };
            ClientController clientController = ClientController.GetClientInstance();
            clientController.AddClient(clientOne);
            clientController.AddClient(clientTwo);
            clientController.AddClient(clientThree);
            clientController.AddClient(clientFour);
            StockItem itemOne = new StockItem()
            {
                StockCode = 1,
                ItemName = "Tiger Wheels Professional",
                Price = 4599.99,
                Count = 25
            };
            StockItem itemTwo = new StockItem()
            {
                StockCode = 2,
                ItemName = "Low Cost Wheels",
                Price = 899.95,
                Count = 20,
            };
            StockItem itemThree = new StockItem()
            {
                StockCode = 3,
                ItemName = "Coffee cup holder (Portable Edition)",
                Price = 499.95,
                Count = 30
            };
            StockItem itemFour = new StockItem()
            {
                StockCode = 4,
                ItemName = "Leather Seat Pollish",
                Price = 399.95,
                Count = 35,
            };
            StockController stockController = StockController.GetStockInstance();
            stockController.AddStockItem(itemOne);
            stockController.AddStockItem(itemTwo);
            stockController.AddStockItem(itemThree);
            stockController.AddStockItem(itemFour);

            OnlineSalesFacade salesFacade = new OnlineSalesFacade(clientController, stockController);
            //Sell items (stock id, client id, nr)
            salesFacade.SellItem(1, 1, 3);
            salesFacade.SellItem(1, 2, 2);
            salesFacade.SellItem(2, 1, 3);
            salesFacade.SellItem(2, 3, 20);
            salesFacade.SellItem(3, 3, 4);
            salesFacade.SellItem(3, 3, 5);
            salesFacade.SellItem(4, 4, 3);
            salesFacade.SellItem(4, 1, 3);
            //Update items
            salesFacade.UpdateItem(1, 10999.95);
            salesFacade.UpdateItem(2, 499.99);
            //Notify any overdue clients
            salesFacade.NotifyOverdue();
            //Calculate any special discounts
            salesFacade.CalculateSpecial(3, 4);
            Console.ReadLine();
        }
    }
}
