﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rev.Services.Exceptions
{
    public class DbConcurrencyExceptions : ApplicationException
    {
        public DbConcurrencyExceptions(string message) : base(message)
        {

        }
    }
}
