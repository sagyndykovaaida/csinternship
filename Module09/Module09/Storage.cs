using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Module09
{
    public abstract class Storage
    {
        public string StorageName
        {
            get 
            { 
                return StorageName;
            }
            set 
            { 
                StorageName = value; 
            }
        }

        public string Model
        {
            get 
            { 
                return Model; 
            }
            set 
            { 
                Model = value; 
            }
        }
        public abstract double GetStorageVolume();

        public abstract void CopyData(double dataSize);

        public abstract double GetFreeSpace();

        public abstract void GetDeviceInfo();
    }
}
