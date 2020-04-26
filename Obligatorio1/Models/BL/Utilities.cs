using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio1.Models.BL
{
    public static class Utilities
    {
        public static int digitsNumber(int n)
        {
            int d = 1;

            while (n >= 10)
            {
                n /= 10;
                d++;
            }

            return d;
        }
    }
}