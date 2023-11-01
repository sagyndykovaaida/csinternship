using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building
{
    class TeamLeader 
    {
        public void DoWork(List<IPart> parts)
        {
            Console.WriteLine("Отчет о построенных частях дома:");

            foreach (IPart part in parts)
            {
                Console.Write("- ");
                part.Build();
            }

            Console.WriteLine("Строительство дома завершено");
        }
    }
}
