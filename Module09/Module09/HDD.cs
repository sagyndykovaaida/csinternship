using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module09
{
    public class HDD : Storage
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

        public int Partitions
        {
            get 
            {
                return Partitions; 
            }
            set 
            {
                Partitions = value; 
            }
        }

        public double PartitionSize
        {
            get 
            { 
                return PartitionSize; 
            }
            set 
            {
                PartitionSize = value; 
            }
        }

        public override double GetStorageVolume()
        {
            return PartitionSize * PartitionSize;
        }

        public override void CopyData(double dataSize)
        {
            double time = dataSize / UsbSpeed;
            Console.WriteLine($"Time: {time} seconds");
        }

        public override double GetFreeSpace()
        {
            return GetStorageVolume() * 0.9;
        }

        public override void GetDeviceInfo()
        {
            Console.WriteLine($"HDD - Device Name: {StorageName}, Model: {Model}, " +
                $"USB Speed: {UsbSpeed} MB/s, Partitions: {Partitions}, Partition Size: {PartitionSize} GB");
        }   

    }
}
