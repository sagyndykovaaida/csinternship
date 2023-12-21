using System;

namespace ClassLibrary
{
    public class PasswordManager
    {
        private readonly IUserSettingsProvider userSettingsProvider;

        public PasswordManager(IUserSettingsProvider userSettingsProvider)
        {
            this.userSettingsProvider = userSettingsProvider ?? throw new ArgumentNullException(nameof(userSettingsProvider));
        }
         
        public void GetPassword()
        {
            int passwordLength = PromptForPasswordLength();
           
            UserSettings userSettings = userSettingsProvider.GetUserSettings();
            userSettings.Category();
            string password = userSettings.GeneratePassword(passwordLength);

            if (!string.IsNullOrEmpty(password))
            {
                Console.WriteLine($"Ваш пароль: {password}");
            }
        }
         
        private int PromptForPasswordLength()  // чтобы выбрать длину пароля  
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

        public void DisplayTips() // советы по безопасности
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

    public interface IUserSettingsProvider
    {
        UserSettings GetUserSettings();
    }
}
