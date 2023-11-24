using CartConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppModule12
{
    internal class PropertyChanged
    {
        static void Main()
        {
            Class obj = new Class();

            obj.PropertyChanged += PropertyChangedObj;
            obj.Propp = 42;
            obj.PropertyChanged -= PropertyChangedObj;
            Console.ReadKey();
        }

        private static void PropertyChangedObj(object o, PropertyEventArgs e)
        {
            Console.WriteLine($"Свойство {e.PropertyName} было изменено");
        }
    }
}
