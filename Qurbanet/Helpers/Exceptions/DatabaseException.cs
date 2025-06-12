namespace Qurbanet.Helpers.Exceptions
{
    //Veri Tabanı Hataları
    public class DatabaseException : CustomException
    {
        public DatabaseException(string message) : base(message, 4000) { }

        public DatabaseException(string message, int errorCode) : base(message, errorCode) { }

    }
}
