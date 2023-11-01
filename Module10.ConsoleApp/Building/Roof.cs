using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building
{
    class Roof : IPart
    {
        public void Build()
        {
            Console.WriteLine("Крыша установлена");
        }
    }
}
