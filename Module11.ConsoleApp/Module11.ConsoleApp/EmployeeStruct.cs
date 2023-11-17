using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module11.ConsoleApp
{
    public enum Vacancies
    {
        Developer,
        Manager,
        Clerk
    }

    public struct Employee
    {
        public string Name;
        public Vacancies Vacancy;
        public int[] HireDate;
        public int Salary;
        public Employee(string name, Vacancies vacancy, int[] hireDate, int salary)
        {
            Name = name;
            Vacancy = vacancy;
            HireDate = hireDate;
            Salary = salary;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Имя: {Name}");
            Console.WriteLine($"Вакансия: {Vacancy}");
            Console.WriteLine($"Дата приема на работу: {HireDate[0]}.{HireDate[1]}.{HireDate[2]}");
            Console.WriteLine($"Зарплата: {Salary}");
        }
    }
    internal class EmployeeStruct
    {
        static void Main()
        {
            Employee employee1 = new Employee("User User", Vacancies.Manager, new int[] { 2022, 11, 16 }, 555555);
            Employee employee2 = new Employee("Test Test", Vacancies.Clerk, new int[] { 2021, 8, 25 }, 355555);

            Console.WriteLine("Инфо о сотруднике 1:");
            employee1.DisplayInfo();

            Console.WriteLine("Инфо о сотруднике 2:");
            employee2.DisplayInfo();
            Console.ReadKey();
        }

    }
}
