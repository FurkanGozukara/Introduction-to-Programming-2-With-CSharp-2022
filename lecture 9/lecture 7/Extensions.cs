using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public static class Extensions
    {
        public static int toInt32(this string srNumber)
        {
            int irResult = 0;
            bool blResult = Int32.TryParse(srNumber, out irResult);

            if (blResult == false)
                return -1;
            else
                return irResult;
        }
    }

