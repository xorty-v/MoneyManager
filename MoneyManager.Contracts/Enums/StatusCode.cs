namespace MoneyManager.Contracts.Enums;

public enum StatusCode
{
    //User
    UserNotFound = 11,
    //Category
    CategoryNotFound = 12,
    //Transaction

    //Other
    OK = 200,
    BadRequestError = 400,
    InternalServerError = 500
}