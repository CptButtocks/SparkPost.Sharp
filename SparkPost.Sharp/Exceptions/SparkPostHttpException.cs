using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkPost.Sharp.Exceptions
{
    public class SparkPostHttpException : Exception
    {
        public SparkPostHttpException(string? message) : base(message)
        {
        }

        public SparkPostHttpException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
