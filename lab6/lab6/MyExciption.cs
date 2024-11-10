using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public class DataBaseException : Exception
    {
        public DataBaseException(string message) : base(message) { }
    }

    public class FailConnectionException : ArgumentException
    {
        public FailConnectionException(string message, string val) : base(message)
        {
            Value = val;
        }

        public string Value { get; set; }
    }

    public class DataBaseArgumentsException : ArgumentOutOfRangeException
    {
        public int Value { get; set; }

        public DataBaseArgumentsException(string message, int val) : base(message)
        {
            Value = val;
        }
    }
}
