using CartConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppModule12
{
    internal class Program
    {
        delegate void GetMessage();
        static void Main(string[] args)
        {
            /*GetMessage del;
            if(DateTime.Now.Hour < 12)
            {
                del = GoodMorning;
            }
            else
            {
                del= GoodEvening;

            }*/
            /* del.Invoke();*/ //call delegate 

            Acccount acc = new Acccount(500, 10);
            acc.RegisterHandler(ShowMessage);
            acc.Withdraw(100);


            Car car = new Car();
            car.RegisterWithCarEngine(ShowMessage);
            for(int i = 0;i < 8; i++)
            {
                car.Accelerate(30);

            }
            Console.ReadKey();



        }
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public class Acccount
        {
            int _sum;
            int _percentage;

            public Acccount(int _sum, int _percentage )
            {
                this._sum = _sum;
                this._percentage = _percentage;

            }
            public delegate void AccountStateHandler(string message);

            AccountStateHandler del;

            public void RegisterHandler(AccountStateHandler _del)
            {
                del = _del;

            }

            public int CurrentSum { get
                {
                    return _sum;
                } 
            }
            public void Put(int sum)
            {
                _sum += sum;
            }

            public void Withdraw(int sum)
            {
                if (sum <= _sum)
                {
                    _sum -= sum;
                    del("Summa " + _sum.ToString());
                }
                else
                {
                    del("Error");
                }
                
            }
        }



        static void GoodMorning()
        {
            Console.WriteLine("Good Morning");
        }

        static void GoodEvening()
        {
            Console.WriteLine("Good Evening");
        }
    }
}
