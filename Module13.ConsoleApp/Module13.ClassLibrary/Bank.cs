using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Module13.ClassLibrary
{
    public class Bank
    {
        private Queue<Client> clients = new Queue<Client>();

        public void AddClient(string name, string serviceType)
        {
            int clientId = clients.Count + 1;
            Client client = new Client(clientId, name, serviceType);
            Console.WriteLine($"новый клиент: {client.Name} " +
                $"(ID: {client.Id}, " +
                $"Тип обслуживания: {client.ServiceType})");
            clients.Enqueue(client);
        }

        public void ServeNextClient()
        {
            if (clients.Count > 0)
            {
                Client currentClient = clients.Dequeue();
                Console.WriteLine($"Обслуживается клиент: {currentClient.Name}" +
                    $" (ID: {currentClient.Id}, " +
                    $"Тип обслуживания: {currentClient.ServiceType})");

                switch (currentClient.ServiceType)
                {
                    case "Кредитование":
                        Console.WriteLine("Обслуживание по кредитованию займет некоторое время.");
                        break;
                    case "Открытие вклада":
                        Console.WriteLine("Открытие вклада требует времени на оформление.");
                        break;
                    case "Консультация":
                        Console.WriteLine("Консультация будет проведена в кратчайшие сроки.");
                        break;
                    default:
                        Console.WriteLine("Неизвестный тип обслуживания.");
                        break;
                }

                Console.WriteLine($"Клиент {currentClient.Name} обслужен.");
            }
            else
            {
                Console.WriteLine("Очередь пуста.");
            }
        }
        }
}
