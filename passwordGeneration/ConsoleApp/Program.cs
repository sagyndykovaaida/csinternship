using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            PasswordManager passwordManager = new PasswordManager();
            Console.WriteLine("------Генератор паролей------");
            Console.WriteLine("Введите длину пароля (от 8 до 32 символов):");
            passwordManager.GetPassword();
            passwordManager.DisplayTips();

            Console.ReadKey();
        }

    }
}
