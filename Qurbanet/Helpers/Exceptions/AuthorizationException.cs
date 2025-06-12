namespace Qurbanet.Helpers.Exceptions
{
    //Yetkilendirme Hataları
    public class AuthorizationException : CustomException
    {
        public AuthorizationException(string message) : base(message, 5000) { }

        public AuthorizationException(string message, int errorCode) : base(message, errorCode) { }
    }
}
