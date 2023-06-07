namespace MoneyManager.Contracts.Enums;

public enum StatusCode
{
    //User
    
    //Category
    CategoryNotFound = 11,
    CategoryAlreadyExists = 12,
    //Transaction

    //Other
    OK = 200,
    BadRequestError = 400,
    InternalServerError = 500
}