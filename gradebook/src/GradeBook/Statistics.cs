using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook
{
    public class Statistics
    {
        public double Avereage
        {
            get
            {
                return Sum / Count;
            }
        }
        public double High;
        public double Low;

        public char Letter
        {
            get
            {
                switch (Avereage)
                {
                    case var d when d >= 90.0:
                        return 'A'; 
                    case var d when d >= 80.0:
                        return 'B'; 
                    case var d when d >= 70.0:
                        return 'C'; 
                    case var d when d >= 60.0:
                        return 'D'; 
                    default:
                        return 'F'; 

                }
            }
        }

        public double Sum;

        public double Count;

        public Statistics()
        {
            High = double.MinValue;
            Low = double.MaxValue;
            Sum = 0.0;
        }

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }
    }
}