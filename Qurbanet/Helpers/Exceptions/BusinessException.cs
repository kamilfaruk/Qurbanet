namespace Qurbanet.Helpers.Exceptions
{
    //İş Mantığı (Business Logic) Hataları
    public class BusinessException : CustomException
    {
        public BusinessException(string message) : base(message, 3000) { }

        public BusinessException(string message, int errorCode) : base(message, errorCode) { }

    }
}
