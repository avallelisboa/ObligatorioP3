﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Models.BL
{
    public class Deposit : User
    {
       public Deposit(int id, string password) : base(id, password, "deposito"){  }
    }
}