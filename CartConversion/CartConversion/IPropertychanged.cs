using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartConversion
{
    public delegate void PropertyeventHandler(object sender, PropertyEventArgs e);
    public interface IPropertychanged
    {
        event PropertyeventHandler PropertyChanged;
    }

    public class PropertyEventArgs : EventArgs
    {
        public string PropertyName { get; }

        public PropertyEventArgs(string propertyName)
        {
            PropertyName = propertyName;
        }
    }

    public class Class : IPropertychanged
    {
        private int prop;

        public int Propp
        {
            get { return prop; }
            set
            {
                if (prop != value)
                {
                    prop = value;
                    OnMyPropertyChanged();
                }
            }
        }

        public event PropertyeventHandler PropertyChanged;

        protected virtual void OnMyPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyEventArgs("Propp"));
        }
    }

}
