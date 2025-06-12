namespace Qurbanet.Helpers.Exceptions
{
    //Genel Hatalar
    public class CustomException : Exception
    {
        public int ErrorCode { get; }
     
        public CustomException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
