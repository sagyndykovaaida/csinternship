using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building
{
    class Walls : IPart
    {
        public void Build()
        {
            Console.WriteLine("Стена построена");
        }
    }
}
