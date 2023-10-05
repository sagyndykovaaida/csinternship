using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModule04
{
    public partial class Aircraft
    {
        public string Model { get; set; }
        public int PassengerCapacity { get; set; }

        private double maxSpeed;

        public double GetMaxSpeed()
        {
            return maxSpeed;
        }

        public void SetMaxSpeed(double value)
        {
            maxSpeed = value;
        }

        private double wingspan;
        public double Wingspan
        {
            get 
            { 
                return wingspan; 
            }
            set
            {
                if (value >= 0)
                    wingspan = value;
                else
                    Console.WriteLine("Размах крыльев не может быть отрицательным.");
            }
        }
        public double Range { get; set; }

        private static int totalCount; 
        private static double averageMaxSpeed; 

        public Aircraft(string model, int passengerCapacity, double maxSpeed, double wingspan, double range)
        {
            Model = model;
            PassengerCapacity = passengerCapacity;
            SetMaxSpeed(maxSpeed);
            Wingspan = wingspan;
            Range = range;
            totalCount++;
            averageMaxSpeed = ((averageMaxSpeed * (totalCount - 1)) + maxSpeed) / totalCount;
        }

        public Aircraft(string model, int passengerCapacity, double maxSpeed)
            : this(model, passengerCapacity, maxSpeed, 0.0, 0.0)
        {
        }

        public Aircraft()
            : this("Unknown", 0, 0.0, 0.0, 0.0)
        {
        }

        static Aircraft()
        {
            totalCount = 0;
            averageMaxSpeed = 0.0;
        }

        public void SetRange(ref double newRange)
        {
            Range = newRange;
        }

        public static int TotalCount
        {
            get 
            { 
                return totalCount; 
            }
        }

        public static double AverageMaxSpeed
        {
            get 
            {
                return averageMaxSpeed; 
            }
        }
    }
}
