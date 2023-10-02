using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satbayev.DAL
{
    internal class Account
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int ClintId { get; set; }
        public string AccountNumber { get; set; }
        public DateTime ExpDay { get; set; }
        public string Currency { get; set; }
        private double _Balance;
        public double Balance {
            get
            {
                return _Balance;
            }
            set
            {
                if (value < 0)
                {
                    _Balance = 0;
                }
                else
                {
                    _Balance = value;
                }
            }
                
                }
        public bool isActivity { get; set; } = true;

    }
}
