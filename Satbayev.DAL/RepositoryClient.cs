using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satbayev.DAL
{

    public class RepositoryClient
    {
        private string Path = @"C:\Temp\MyData.db";
        public RepositoryClient(string Path) { 
            this.Path = Path;
        }
        public bool CreateClient(Client client)
        {
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var clients = db.GetCollection<Client>("Client");
                    clients.Insert(client);


                }
            }
            catch (Exception) { 

            }

            
            return true;
        }
        public Client GetClient(string email, string password)
        {
            using (var db = new LiteDatabase(Path))
            {
                return db.GetCollection<Client>("Client").FindAll().First(f => f.Email == email & f.Password == password);

            }

        }
        public Client GetClient(int Id)
        {
            using (var db = new LiteDatabase(Path))
            {
                return db.GetCollection<Client>("Client").FindAll().First(f => f.Id == Id);

            }

        }
    }
}

