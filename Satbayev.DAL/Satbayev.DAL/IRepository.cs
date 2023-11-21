﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satbayev.DAL
{
    public interface IRepository<T>
    {
        bool Create(T data);
        List<T> GetAll();
        bool Update(T data);
        bool Delete(int id);
    }
}
