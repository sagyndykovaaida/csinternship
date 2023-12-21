using ClassLibrary;
using System;

namespace ConsoleApp
{
    public class UserSettingsProvider : IUserSettingsProvider
    {
        public UserSettings GetUserSettings()
        {
            return new UserSettings();
        }
    }

    internal class Program
    {
        static void Main()
        {
            IUserSettingsProvider userProvider = new UserSettingsProvider();
            PasswordManager passwordManager = new PasswordManager(userProvider);

            Console.WriteLine("------Генератор паролей------");
            Console.WriteLine("Введите длину пароля (от 8 до 32 символов):");
            passwordManager.GetPassword();
            passwordManager.DisplayTips();

            Console.ReadKey();
        }
    }
}
