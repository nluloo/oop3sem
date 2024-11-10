using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab3
{
    public static class StatisticOperation
    {
        public static int Sum(params MyString[] myStrings)
        {
            return myStrings.Sum(ms => ms.ToString().Length);
        }

        public static int DifferenceMaxMin(params MyString[] myStrings)
        {
            if (myStrings.Length == 0) return 0;
            int maxLength = myStrings.Max(ms => ms.ToString().Length);
            int minLength = myStrings.Min(ms => ms.ToString().Length);
            return maxLength - minLength;
        }

        public static int ElementCount(MyString myString)
        {
            return myString.ToString().Length;
        }

        public static int WordCount(this string str)
        {
            return Regex.Matches(str, @"\b\w+\b").Count;
        }

        public static int WordCount(this MyString myString)
        {
            return Regex.Matches(myString.ToString(), @"\b\w+\b").Count;
        }


        public static MyString smile(this string a, int place)
        {
            var symb = new KeyValuePair<int, string>(place - 1, "♥");
            return new MyString(a.Substring(0, place - 1) + symb.Value + a.Substring(place));
        }

        public static MyString smile(this MyString a, int place)
        {
            var symb = new KeyValuePair<int, string>(place - 1, "♥");
            return new MyString(a.ToString().Substring(0, place - 1) + symb.Value + a.ToString().Substring(place));
        }
    }
}
