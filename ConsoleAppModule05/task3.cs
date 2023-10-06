using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppModule05
{
    internal class task3
    {
        static void Main()
        {
            try
            {
                FirstMethod();
            }
            catch (CustomException ex)
            {
                Console.WriteLine("error: " + ex.Message);
            }
            Console.ReadKey();
        }

        static void FirstMethod()
        {
            try
            {
                SecondMethod();
            }
            catch (Exception ex)
            {
                throw new CustomException("error in FirstMethod", ex);
            }
        }

        static void SecondMethod()
        {
            throw new InvalidOperationException("error in SecondMethod");
        }
    }

    class CustomException : Exception
    {
        public CustomException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
