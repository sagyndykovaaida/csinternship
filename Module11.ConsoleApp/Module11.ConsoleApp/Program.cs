using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module11.ConsoleApp
{
    internal class Program
    {
        public interface IEmployee
        {
            string Name { get; set; }
            int Id { get; set; }
            decimal Salary { get; set; }
            DateTime HireDate { get; set; }
            string Position { get; set; }
            char Gender { get; set; }
        }

        public struct Employee : IEmployee
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public decimal Salary { get; set; }
            public DateTime HireDate { get; set; }
            public string Position { get; set; }
            public char Gender { get; set; }

            public override string ToString()
            {
                return $"Имя: {Name}, Id: {Id}," +
                    $" Зарплата: {Salary:C}, Должность: {Position}, " +
                    $"Пол: {Gender}, Дата приема: {HireDate.ToShortDateString()}";
            }
        }
        static void Main(string[] args)
        {
            Console.Write("количество сотрудников: ");
            int n = int.Parse(Console.ReadLine());

            Employee[] employees = new Employee[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"инфо о сотруднике #{i + 1}:");
                employees[i] = ReadEmployeeData();
            }

            PrintAllEmployees(employees);

            Console.Write("должность для вывода информации: ");
            string selectedPosition = Console.ReadLine();
            PrintEmployeesByPosition(employees, selectedPosition);

            CheckSalary(employees);

            Console.Write("дата (гггг-мм-дд) для фильтрации сотрудников: ");
            DateTime filterDate = DateTime.Parse(Console.ReadLine());
            PrintHiredAfterDate(employees, filterDate);

            Console.Write("Введите пол (М/Ж), либо оставьте пустым для вывода всех: ");
            char genderFilter = char.TryParse(Console.ReadLine(), out char gender) ? gender : '\0';
            PrintEmployeesByGender(employees, genderFilter);

            Console.ReadKey();
        }

        static Employee ReadEmployeeData()
        {
            Employee employee = new Employee();

            Console.Write("Имя: ");
            employee.Name = Console.ReadLine();

            Console.Write("ID: ");
            employee.Id = int.Parse(Console.ReadLine());

            Console.Write("Зарплата: ");
            employee.Salary = decimal.Parse(Console.ReadLine());

            Console.Write("Дата приема на работу (гггг-мм-дд): ");
            employee.HireDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Должность: ");
            employee.Position = Console.ReadLine();

            Console.Write("Пол (М/Ж): ");
            employee.Gender = char.Parse(Console.ReadLine());

            return employee;
        }

        static void PrintAllEmployees(Employee[] employees)
        {
            Console.WriteLine("\nПолная инфо:");
            foreach (var i in employees)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine();
        }

        static void PrintEmployeesByPosition(Employee[] employees, string position)
        {
            Console.WriteLine($"\nСотрудники на должности {position}:");
            foreach (var employee in employees)
            {
                bool check = true;

                if (employee.Position.Length != position.Length)
                {
                    check = false;
                }
                else
                {
                    for (int i = 0; i < employee.Position.Length; i++)
                    {
                        if (char.ToLower(employee.Position[i]) != char.ToLower(position[i]))
                        {
                            check = false;
                            break;
                        }
                    }
                }

                if (check)
                {
                    Console.WriteLine(employee.ToString());
                }
            }
            Console.WriteLine();
        }


        static void CheckSalary(Employee[] employees)
        {
            decimal averageSalary = CalculateAverageSalary(employees);
            Console.WriteLine($"\nМенеджеры с зарплатой выше средней зарплаты  ({averageSalary:C}):");

            var emp = employees.Where(e => e.Position.Equals("Менеджер", StringComparison.OrdinalIgnoreCase) && e.Salary > averageSalary)
                                    .OrderBy(e => e.Name);

            foreach (var e in emp)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine();
        }

        static decimal CalculateAverageSalary(Employee[] employees)
        {
            decimal totalSalary = 0;
            int Count = 0;

            foreach (var i in employees)
            {
                if (string.Equals(i.Position, "Клерк", StringComparison.OrdinalIgnoreCase))
                {
                    totalSalary += i.Salary;
                    Count++;
                }
            }
            return Count > 0 ? totalSalary / Count : 0;
        }

        static void PrintHiredAfterDate(Employee[] employees, DateTime hireDate)
        {
            Console.WriteLine($"\nСотрудники, принятые на работу после {hireDate.ToShortDateString()}, отсортированные по фамилии:");

            var filteredEmployees = employees.Where(e => e.HireDate > hireDate)
                                            .OrderBy(e => e.Name);

            foreach (var i in filteredEmployees)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine();
        }

        static void PrintEmployeesByGender(Employee[] employees, char genderFilter)
        {
            string genderString = genderFilter == 'М' ? "мужчины" : (genderFilter == 'Ж' ? "женщины" : "все");
            Console.WriteLine($"\nИнформация о сотрудниках {genderString}:");

            var filter = employees.Where(e => genderFilter == '\0' || e.Gender == genderFilter)
                                            .OrderBy(e => e.Name);

            foreach (var i in filter)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine();
        }
    }
}
