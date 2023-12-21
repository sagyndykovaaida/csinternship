using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class UserSettings
    {
        private readonly Random random = new Random();

        private readonly PasswordGenerator passwordGenerator = new PasswordGenerator();

        public bool Uppercase { get; set; } = true;
        public bool Lowercase { get; set; } = true;
        public bool Digits { get; set; } = true;
        public bool SpecialSymbols { get; set; } = true;
        public string ExcludedCharacters { get; set; } = "Il10Oo";

        public string GeneratePassword(int length)
        {
            string allowedChars = GetAllowedChars();

            if (string.IsNullOrEmpty(allowedChars))
            {
                Console.WriteLine("Error");
                return string.Empty;
            }

            StringBuilder password = new StringBuilder(); // предоставляет изменяемую последовательность символов

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(0, allowedChars.Length);
                password.Append(allowedChars[index]);
            }

            return password.ToString();
        }

        private string GetAllowedChars()
        {
            List<Func<string>> characterSets = new List<Func<string>>
            {
                () => Uppercase ? ExcludeSymbols(passwordGenerator.UppercaseChars) : "",
                () => Lowercase ? ExcludeSymbols(passwordGenerator.LowercaseChars) : "",
                () => Digits ? ExcludeSymbols(passwordGenerator.NumChars) : "",
                () => SpecialSymbols ? passwordGenerator.SpecialSymbols : ""
            };

            return string.Concat(characterSets.Select(set => set()));
        }

        public string ExcludeSymbols(string input)
        {
            foreach (char c in ExcludedCharacters)
            {
                input = input.Replace(c.ToString(), string.Empty);
            }
            return input;
        }

        private bool GetUserChoice(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return input == "1";
        }

        public void Category()
        {
            Uppercase = GetUserChoice("Включить заглавные буквы (1 - да, 0 - нет): ");
            Lowercase = GetUserChoice("Включить строчные буквы (1 - да, 0 - нет): ");
            Digits = GetUserChoice("Включить цифры (1 - да, 0 - нет): ");
            SpecialSymbols = GetUserChoice("Включить специальные символы (1 - да, 0 - нет): ");
        }
    }
}
