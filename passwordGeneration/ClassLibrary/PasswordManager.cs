using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class PasswordManager
    {

        UserSettings userSettings = new UserSettings();

        public void GetPassword()
        {
            int passwordLength = PromptForPasswordLength();
            userSettings.Category();
            string password = userSettings.GeneratePassword(passwordLength);

            if (!string.IsNullOrEmpty(password))
            {
                Console.WriteLine($"Ваш пароль: {password}");
            }
        }

        private int PromptForPasswordLength()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int passwordLength) && passwordLength >= 8 && passwordLength <= 32)
                {
                    return passwordLength;
                }
                else
                {
                    Console.WriteLine("Пожалуйста, введите корректное число от 8 до 32.");
                }
            }
        }


        public void DisplayTips()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Советы по безопасному использованию и хранению паролей:");
            Console.WriteLine("1. Никогда не используйте один и тот же пароль на разных сайтах или сервисах.");
            Console.WriteLine("2. Используйте длинные пароли смешанного типа (буквы верхнего и нижнего регистра, цифры и специальные символы).");
            Console.WriteLine("3. Не записывайте пароли на бумаге или в недостоверных электронных документах.");
            Console.WriteLine("4. Используйте парольные менеджеры для безопасного хранения и управления паролями.");
            Console.WriteLine("5. Регулярно меняйте пароли для повышения безопасности вашего аккаунта.");
            Console.WriteLine("6. Остерегайтесь фишинговых атак и не раскрывайте пароли по электронной почте или телефону.");
            Console.WriteLine("7. Следите за безопасностью вашего компьютера и устройств, где хранятся пароли.");
        }

    }
}
