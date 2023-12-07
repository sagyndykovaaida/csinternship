using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Module15.ConsoleApp
{
    public class MyClass
    {
        private int firstField;
        public int secondField;

        public MyClass() { }

        public MyClass(int value)
        {
            firstField = value;
            secondField = value;
        }

        private void PrivateMethod()
        {
            Console.WriteLine("private method.");
        }

        public void PublicMethod()
        {
            Console.WriteLine("public method.");
        }

        public int CalculateSum(int a, int b)
        {
            return a + b;
        }


        static void Main()
        {
            Type myClassType = typeof(MyClass);

            Console.WriteLine("Class Name: " + myClassType.Name);

            Console.WriteLine("\nConstructors:");
            ConstructorInfo[] constructors = myClassType.GetConstructors();
            foreach (var constructor in constructors)
            {
                Console.WriteLine($"{constructor.Name}, Access: {constructor.Attributes}");
            }

            FieldInfo[] fields = myClassType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            PropertyInfo[] properties = myClassType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            
            foreach (var field in fields)
            {
                Console.WriteLine($"{field.Name}, Type: {field.FieldType}, Access: {field.Attributes}");
            }
            
            foreach (var property in properties)
            {
                Console.WriteLine($"{property.Name}, Type: {property.PropertyType}, Access: {property.Attributes}");
            }


            Console.WriteLine("\nMethods:");
            MethodInfo[] methods = myClassType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            
            foreach (var method in methods)
            {
                Console.WriteLine($"{method.Name}, Return Type: {method.ReturnType}, Access: {method.Attributes}");
            }
            Console.ReadKey();  
        }


    }




}
