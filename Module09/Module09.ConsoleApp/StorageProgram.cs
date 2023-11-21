using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Module09.ConsoleApp
{
    internal class StorageProgram
    {
        static void Main()
        {
            List<Storage> list = new List<Storage>()
        {
            new Flash() { StorageName = "FlashDrive1", Model = "Model1", UsbSpeed = 100, MemorySize = 32 },
            new DVD() { StorageName = "DVD1", Model = "Model2", ReadWriteSpeed = 70, IsDoubleLayer = false },
            new HDD() { StorageName = "HDD1", Model = "Model3", UsbSpeed = 50, Partitions = 2, PartitionSize = 500 }
        };

            double totalStorageVolume = 0;
            foreach (var device in list)
            {
                totalStorageVolume += device.GetStorageVolume();
            }

            Console.WriteLine($"Total Storage: {totalStorageVolume} GB");

            double dataSizeToCopy = 565; 
            foreach (var device in list)
            {
                device.CopyData(dataSizeToCopy);
            }

            double totalTime = 0;
            foreach (var device in list)
            {
                totalTime += dataSizeToCopy / device.GetFreeSpace();
            }

            Console.WriteLine($"Total Time: {totalTime} seconds");

            int flashDriveCount = (int)Math.Ceiling(dataSizeToCopy / ((Flash)list[0]).MemorySize);
            int dvdCount = (int)Math.Ceiling(dataSizeToCopy / ((DVD)list[1]).GetStorageVolume());
            int hddCount = (int)Math.Ceiling(dataSizeToCopy / ((HDD)list[2]).GetStorageVolume());

            Console.WriteLine($"Count Flash Drives: {flashDriveCount}");
            Console.WriteLine($"Count DVDs Needed: {dvdCount}");
            Console.WriteLine($"Count HDDs Needed: {hddCount}");


            Console.ReadKey();
        }
    }
}
