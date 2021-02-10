#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace StructsAndEnums
{
    class Program
    {
        static void doWork()
        {
            Console.WriteLine("Chapter 9 Lab");
            Month first = Month.January;
            Console.WriteLine(first);
            Console.WriteLine((int)first);
            first++;
            Console.WriteLine(first);
            Console.WriteLine((int) first);
            first += 10;
            Console.WriteLine(first);
            Console.WriteLine((int)first);
            first++;
            Console.WriteLine(first);
            Console.WriteLine((int)first);

            Month last = Month.Ceasar;
            Console.WriteLine(last);
            last++;
            Console.WriteLine(last);

            Console.WriteLine("--------------------------------------");
            Date defaultDate = new Date();
            Console.WriteLine(defaultDate);

            Date weddingAnniversary = new Date(2019, Month.December, 28);
            Console.WriteLine(weddingAnniversary);

            Date weddingAnniversaryCopy = weddingAnniversary; 
            Console.WriteLine($"Value of copy is {weddingAnniversaryCopy}");
            weddingAnniversary.AdvanceMonth();
            Console.WriteLine($"New Value of weddingAnniversary is {weddingAnniversary}");
            Console.WriteLine($"Value of copy is {weddingAnniversaryCopy}");

        }

        static void Main()
        {
            try
            {
                doWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    struct Date
    {
        private int year;
        private Month month;
        private int day;

        public Date(int ccyy, Month mm, int dd)
        {
            this.year = ccyy - 1900;
            this.month = mm;
            this.day = dd - 1;
        }

        public override string ToString()
        {
            string data = $"{this.month}, {this.day + 1} {this.year + 1900}";
            return data;

        }

        public void AdvanceMonth()
        {
            this.month++;
            if (this.month == Month.December + 1)
            {
                this.month = Month.January;
                this.year++;
            }
        }
    }

    enum Month
    {
        January, //0
        February, //1
        March, //2
        April, //3
        May, //4
        June, //5
        July, //6
        August, //7
        September, //8
        October, //9
        November, //10
        December, //11
        Ceasar //12
    }
}
