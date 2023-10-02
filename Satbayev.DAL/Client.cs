﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satbayev.DAL
{
    public class Client
    {
        public int Id { get; set; }
        public DateTime Bday { get; set; }
        public int GetAge()
        {
            return DateTime.Now.Year -  Bday.Year;   
        }
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public string MiddleName { get; set; }
        public string ShortName { 
            get
            {
                if (string.IsNullOrEmpty(MiddleName))
                {
                    return string.Format("{0},{1}", FirstName, LastName[0]);
                }
                else
                {
                    return string.Format("{0},{1},{2}", FirstName, LastName[0], MiddleName[0]);
                }
               
            }
                }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public Address Address { get; set; }
    }

}
