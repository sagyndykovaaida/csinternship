using System;

namespace ClassLibraryModule04
{
    public partial class Aircraft
    {
        public void Fly()
        {
            Console.WriteLine($"{Model} летит с максимальной скоростью {GetMaxSpeed()} km/h.");
        }
    }
}
