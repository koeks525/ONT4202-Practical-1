using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONT4202Practical01
{
    public class ClientController
    {
        private List<Client> clientList;
        private static ClientController clientController;

        private ClientController()
        {
            clientList = new List<Client>();
        }

        public static ClientController GetClientInstance()
        {
            if (clientController == null)
            {
                clientController = new ClientController();
                return clientController;
            } else
            {
                return clientController;
            }
        }

        public void AddClient(Client newClient)
        {
            clientList.Add(newClient);
        }

        public void RemoveClient(Client oldClient)
        {
            clientList.Remove(oldClient);
        }

        public bool UpdateClient(Client updateClient)
        {   //Long way of doing this - I thought i could "MVC" this :( 
            Client selectedClient = clientList.First(i => i.ClientID == updateClient.ClientID);
            if (selectedClient != null)
            {
                clientList.Remove(selectedClient);
                selectedClient.EmailAddress = updateClient.EmailAddress;
                selectedClient.Name = updateClient.Name;
                selectedClient.OutstandingBalance = updateClient.OutstandingBalance;
                selectedClient.PhoneNumber = updateClient.PhoneNumber;
                selectedClient.Surname = updateClient.Surname;
                clientList.Add(selectedClient);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Client GetClient(int clientID)
        {
            return clientList.First(i => i.ClientID == clientID);
        }

        public List<Client> GetClients()
        {
            return clientList;
        }
    }
}
