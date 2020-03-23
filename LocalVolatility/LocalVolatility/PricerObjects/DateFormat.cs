using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ProjetVolSto.PricerObjects
{
    class Date:IEXDate
    {
        int day, month, year;
        public int Day { get => day; set => day = value; }
        public int Month { get => month; set => month = value; }
        public int Year { get => year; set => year = value; }
        
        public Date(int year,int month,[Optional] int day)
        {
            Year = year; Month= month; Day = day; 
        }

        public string Format()
        {
            if (Day.Equals(0))
            {
                return String.Format("{0}{1}", year, month);
            }
            else
            {
                return String.Format("{0}{1}{2}", year, month, day);
            }
            
        }


    }
}
