namespace Qurbanet.Helpers.Exceptions
{
    //Doğrulama Hataları
    public class ValidationException : CustomException
    {
        public ValidationException(string message) : base(message, 2000) { }

        public ValidationException(string message, int errorCode) : base(message, errorCode) { }

    }
}
