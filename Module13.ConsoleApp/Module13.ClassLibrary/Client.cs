using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13.ClassLibrary
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ServiceType { get; set; }

        public Client(int id, string name, string serviceType)
        {
            Id = id;
            Name = name;
            ServiceType = serviceType;
        }
    }
}
