namespace Ticketr.Data.Exceptions
{
    [Serializable]
    public class ConnectionStringNullException : DataDbContextException
    {
        public ConnectionStringNullException()
        {
        }
    }
}
