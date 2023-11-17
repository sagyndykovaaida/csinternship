using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace Module11.ConsoleApp
{
    public enum Status
    {
        Created,
        Shipped,
        Delivered
    }

    public class Info
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public Status Status { get; set; }
        public string Description { get; set; } 

    }
    public class DbHandler
    {
        private LiteDatabase _db;

        public DbHandler(string databasePath)
        {
            _db = new LiteDatabase(databasePath);
        }

        public LiteCollection<Info> GetCollection()
        {
            return (LiteCollection<Info>)_db.GetCollection<Info>("waybills");
        }
    }

    public class FileHandler
    {
        public void SaveToFile(string path, string content)
        {
            File.WriteAllText(path, content);
        }

        public void CopyFile(string sourcePath, string destinationPath)
        {
            File.Copy(sourcePath, destinationPath, true);
        }
    }

    public class CourierService
    {
        private readonly DbHandler _dbHandler;
        private readonly FileHandler _fileHandler;

        public CourierService(string databasePath)
        {
            _dbHandler = new DbHandler(databasePath);
            _fileHandler = new FileHandler();
        }

        public void CreateOrder(string senderName, string receiverName)
        {
            
            var collection = _dbHandler.GetCollection();

            var i = new Info
            {
                Id = GetNextOrderId(),
                CreateDate = DateTime.Now,
                SenderName = senderName,
                ReceiverName = receiverName,
                Status = Status.Created
            };

            collection.Insert(i);

            i.Description = $"ID: {i.Id}\n" +
                                  $"Creation Date: {i.CreateDate}\n" +
                                  $"Sender: {i.SenderName}\n" +
                                  $"Receiver: {i.ReceiverName}\n" +
                                  $"Status: {i.Status}";

            _fileHandler.SaveToFile($"order{i.Id}.txt", i.Description);
        }

        public List<Info> GetAllOrders()
        {
            var collection = _dbHandler.GetCollection();
            return collection.FindAll().Select(w => new Info
            {
                Id = w.Id,
                CreateDate = w.CreateDate,
                SenderName = w.SenderName,
                ReceiverName = w.ReceiverName
            }).ToList();
        }

        public Info GetOrderById(int waybillId)
        {
            var collection = _dbHandler.GetCollection();
            return collection.FindOne(w => w.Id == waybillId);
        }

        private int GetNextOrderId()
        {
            var collection = _dbHandler.GetCollection();
            return collection.Count() > 0 ? collection.Max(w => w.Id) + 1 : 1;
        }
    }
    internal class Delivery
    {
        static void Main()
        {

            Console.Write("имя отправителя: ");
            string senderName = Console.ReadLine();

            Console.Write("имя получателя: ");
            string receiverName = Console.ReadLine();

            var courierService = new CourierService("C:\\temp\\courier.db");

            try
            {
                courierService.CreateOrder(senderName, receiverName);
                Console.WriteLine("КН успешно создана.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании КН: {ex.Message}");
            }

            Console.ReadKey();  
        }
    }
}
