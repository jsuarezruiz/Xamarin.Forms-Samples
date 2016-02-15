using System;
using System.Diagnostics;

namespace AgeCalc.Services
{
    public class AgeCalculator
    {
        public static int Calc(DateTime now, DateTime birthDay)
        {
            string age = string.Empty;

            TimeSpan ts = now.Subtract(birthDay);

            int t = ts.Days;
            int y, m, d;

            y = t / 365;
            t = t % 365;

            m = t / 30;
            d = t % 30;

            Debug.WriteLine(y + " years " + m + " months " + d + " days");

            return y;
        }
    }
}
