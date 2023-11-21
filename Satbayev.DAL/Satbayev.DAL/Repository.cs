using LiteDB;
using Satbayev.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satbayev.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private string path;

        public Repository(string path)
        {
            this.path = path;
        }
        public bool Create(T data )
        {
                using (var db = new LiteDatabase(path))
                {
                    var clients = db.GetCollection<T>("Client");
                    clients.Insert(data);
                }
            return true;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(T data)
        {
            try
            {
                using (var db = new LiteDatabase(path))
                {
                    var clients = db.GetCollection<T>
                                    (typeof(T).Name);
                    clients.Update(data);
                }
            }
            catch (Exception ex)
            {
            }
            return true;

        }
    }
  
}
