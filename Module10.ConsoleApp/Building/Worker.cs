using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building
{
    class Worker : IWorker
    {
        private string name;

        public Worker(string name)
        {
            this.name = name;
        }

        public void DoWork(List<IPart> parts)
        {
            foreach (IPart part in parts)
            {
                part.Build();
            }
        }
    }
}
