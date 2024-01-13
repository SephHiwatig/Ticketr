using System.Runtime.Serialization;

namespace Ticketr.Data.Exceptions
{
    [Serializable]
    public class DataDbContextException : Exception
    {
        public DataDbContextException()
        {
        }

        public DataDbContextException(string? message) : base(message)
        {
        }

        public DataDbContextException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
