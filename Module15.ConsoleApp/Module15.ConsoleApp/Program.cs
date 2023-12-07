using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Module15.ConsoleApp
{

    class Person // 2 task 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    } 
    internal class Program
    {
        static void Main(string[] args)
        {
            Type consoleType = typeof(Console);

            MethodInfo[] method = consoleType.GetMethods();

            foreach (var m in method)
            {
                Console.WriteLine(m.Name);
            } // 1 task 


            Person person = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 30
            };

            Type personType = typeof(Person);
            PropertyInfo[] properties = personType.GetProperties();
            foreach (var i in properties)
            {
                object value = i.GetValue(person);
                Console.WriteLine($"{i.Name}: {value}");
            } // 2 task 



            string str = "Here 3rd task"; // 3 task 
            Type strType = typeof(string);
            MethodInfo substr = strType.GetMethod("Substring", new Type[] { typeof(int), typeof(int) });
            object[] paramss = { 7, 5 };
            object result = substr.Invoke(str, paramss);

            Console.WriteLine("String: " + str);
            Console.WriteLine("Substring: " + result);



            Type listType = typeof(List<>); // 4 task 
            ConstructorInfo[] constructors = listType.GetConstructors();
            Console.WriteLine("список конструкторов класса :");

            foreach (var i in constructors)
            {
                Console.Write(i.Name + "(");
                ParameterInfo[] pars = i.GetParameters();

                for (int j = 0; j < pars.Length; j++)
                {
                    Console.Write(pars[j].ParameterType.Name);

                    if (j < pars.Length - 1)
                    {
                        Console.Write(", ");
                    }
                }

                Console.WriteLine(")");
            }


            Console.ReadKey();  

        }
    }
}
