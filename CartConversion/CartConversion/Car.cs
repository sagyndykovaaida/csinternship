
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartConversion
{
    public abstract class Car
    {
        public event EventHandler<string> RaceEvent;
        public event EventHandler<string> FinishEvent;
        public int CurrentSpeed { get; private set; } = 0;
        public int MaxSpeed { get; set; }
        public bool IsDead { get; private set; } = false;

        public abstract string Model { get; }

        public virtual void Accelerate(int delta)
        {
            if (IsDead)
            {
                RaceEvent?.Invoke(this, $"{Model} is dead");
            }
            else
            {
                CurrentSpeed += delta;

                if (CurrentSpeed >= MaxSpeed)
                {
                    IsDead = true;
                    FinishEvent?.Invoke(this, $"{Model} has finished the race!");
                }
                else
                {
                    RaceEvent?.Invoke(this, $"{Model} is racing at {CurrentSpeed} speed.");
                }
            }
        }
    }

    public class RaceCar : Car
    {
        public override string Model => "RaceCar";

        public RaceCar(int maxSpeed)
        {
            MaxSpeed = maxSpeed;
        }
    }

    public class SportsCar : Car
    {
        public override string Model => "SportsCar";

        public SportsCar(int maxSpeed)
        {
            MaxSpeed = maxSpeed;
        }
    }

    public class RacingGame
    {
        public event EventHandler<string> RaceStartEvent; 

        public void StartRace()
        {
            RaceStartEvent?.Invoke(this, "Race is starting!");
        }
    }

}
