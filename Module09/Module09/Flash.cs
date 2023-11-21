using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module09
{
    public class Flash : Storage
    {
        
        public double UsbSpeed
        {
            get 
            { 
                return UsbSpeed; 
            }
            set 
            {
                UsbSpeed = value; 
            }
        }

        public double MemorySize
        {
            get 
            { 
                return MemorySize; 
            }
            set 
            { 
                MemorySize = value; 
            }
        }

        public override double GetStorageVolume()
        {
            return MemorySize;
        }

        public override void CopyData(double dataSize)
        {
            double time = dataSize / UsbSpeed;
            Console.WriteLine($"Time: {time} seconds");
        }

        public override double GetFreeSpace()
        {
            return MemorySize * 0.9;
        }

        public override void GetDeviceInfo()
        {
            Console.WriteLine($"Flash Drive - Device Name: {StorageName}, " +
                $"Model: {Model}, USB Speed: {UsbSpeed} MB/s, Memory Size: {MemorySize} GB");
        }
    }
}
