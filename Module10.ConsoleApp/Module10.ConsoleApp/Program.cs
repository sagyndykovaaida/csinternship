using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.ConsoleApp
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

        }
        public virtual void Print()
        {
            Console.WriteLine($"Full name: {FirstName} {LastName}");
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
        public override bool Equals(object obj)
        {
            if (obj is Person other)
            {
                return FirstName == other.FirstName && LastName == other.LastName;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName);
        }
    }
    public class Student : Person
    {
        public List<Teacher> Teachers { get; } = new List<Teacher>();

        public Student(string firstName, string lastName) : base(firstName, lastName)
        {

        }

        public void addTeacher(Teacher teacher)
        {
            Teachers.Add(teacher);
        }
        public override void Print()
        {
            Console.WriteLine($"Student name:{FirstName} {LastName}");
            Console.WriteLine("Teachers : ");
            for (int i = 0; i < Teachers.Count; i++)
            {
                Console.WriteLine(Teachers[i]);

            }
        }
    }

    public class Teacher : Person
    {
        public List<Student> students = new List<Student>();

        public Teacher(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public void addStudent(Student student)
        {
            students.Add(student);
            student.addTeacher(this);
        }
        public override void Print()
        {
            Console.WriteLine($"Teacher: {FirstName} {LastName}");
            Console.WriteLine("Students:");
            foreach (var student in students)
            {
                Console.WriteLine($"  {student}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Aida", "Alievna");

            Student student1 = new Student("Aida", "Alievna");

            Teacher teacher1 = new Teacher("Yevgeniy", "Gertsen");

            student1.addTeacher(teacher1);

            teacher1.addStudent(student1);

            List<Person> people = new List<Person> { person1, student1, teacher1, };

            foreach (var person in people)
            {
                person.Print();
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
