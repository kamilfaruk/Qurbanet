using System.Data;
using Qurbanet.Helpers.Exceptions;
using static Qurbanet.Helpers.Exceptions.CustomException;

namespace Qurbanet.Helpers
{
    public static class Constants
    {
        public static class CustomExceptions
        {
            // Genel Hatalar
            public static readonly CustomException NotFound = new CustomException("The requested resource was not found.", 1001);
            public static CustomException NotFoundWithId(int id) => new CustomException($"The resource with ID {id} was not found.", 1001);
            public static readonly CustomException Unauthorized = new CustomException("You are not authorized to perform this action.", 1002);
            public static readonly CustomException Forbidden = new CustomException("You do not have permission to access this resource.", 1003);
            public static readonly CustomException BadRequest = new CustomException("The request was invalid or cannot be processed.", 1004);
            public static readonly CustomException InternalServerError = new CustomException("An unexpected error occurred on the server.", 1005);

            // Doğrulama Hataları
            public static readonly ValidationException ValidationFailed = new ValidationException("Validation failed for the provided input.", 2001);
            public static readonly ValidationException RequiredFieldMissing = new ValidationException("A required field is missing or empty.", 2002);
            public static readonly ValidationException InvalidFormat = new ValidationException("The provided input format is invalid.", 2003);
            public static readonly ValidationException ValueOutOfRange = new ValidationException("The provided value is out of the acceptable range.", 2004);

            // İş Mantığı (Business Logic) Hataları
            public static readonly BusinessException BusinessRuleViolation = new BusinessException("A business rule has been violated.", 3001);
            public static readonly BusinessException DuplicateEntry = new BusinessException("The resource already exists and cannot be duplicated.", 3002);
            public static readonly BusinessException OperationNotAllowed = new BusinessException("This operation is not allowed.", 3003);
            public static readonly BusinessException DependencyFailure = new BusinessException("A required dependency failed to execute.", 3004);

            // Veri Tabanı Hataları
            public static readonly DatabaseException DatabaseConnectionFailed = new DatabaseException("Failed to connect to the database.", 4001);
            public static readonly DatabaseException RecordNotFound = new DatabaseException("The specified record was not found in the database.", 4002);
            public static readonly DatabaseException QueryExecutionFailed = new DatabaseException("Failed to execute the database query.", 4003);

            // Yetkilendirme Hataları
            public static readonly AuthorizationException TokenExpired = new AuthorizationException("Your authentication token has expired.", 5001);
            public static readonly AuthorizationException InvalidToken = new AuthorizationException("The authentication token is invalid.", 5002);
            public static readonly AuthorizationException RoleNotAllowed = new AuthorizationException("Your role does not have permission to perform this action.", 5003);
        }

        public static class Tables
        {
            public const string Users = "Users";
            public const string Organizations = "Organizations";
            public const string Animals = "Animals";
            public const string Customers = "Customers";
            public const string Sales = "Sales";
            public const string Payments = "Payments";
            public const string CuttingEvents = "CuttingEvents";
            public const string SystemLogs = "SystemLogs";
        }

        public static class ValidationConstants
        {
            public const int MaxNameLength = 100;
            public const int MaxSurnameLength = 100;
            public const int MaxUsernameLength = 50;
            public const int MaxPasswordLength = 150;
            public const int MaxEmailLength = 150;
            public const int MaxPhoneLength = 20;
        }
    }
}
