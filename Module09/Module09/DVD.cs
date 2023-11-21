using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module09
{
    public class DVD : Storage
    {
        public double ReadWriteSpeed
        {
            get 
            { 
                return ReadWriteSpeed; 
            }
            set 
            {
                ReadWriteSpeed = value; 
            }
        }

        public bool IsDoubleLayer
        {
            get 
            { 
                return IsDoubleLayer; 
            }
            set 
            {
                IsDoubleLayer = value; 
            }
        }

        public override double GetStorageVolume()
        {
            if (IsDoubleLayer)
            {
                return 9.0;
            }
            else
            {
                return 4.7;
            }
        }

        public override void CopyData(double dataSize)
        {
            double time = dataSize / ReadWriteSpeed;
            Console.WriteLine($"Time: {time} seconds");
        }

        public override double GetFreeSpace()
        {
            return GetStorageVolume() * 0.9;
        }

        public override void GetDeviceInfo()
        {
            string type = IsDoubleLayer ? "Double Layer" : "Single Layer";
            Console.WriteLine($"DVD - Device Name: {StorageName}, Model: {Model}," +
                $" Read/Write Speed: {ReadWriteSpeed} MB/s, Type: {type}");
        }

    }
}
