using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace golden_snitch.DTOs
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public bool IsSuccessful { get; set; } = true;
        public string Message { get; set; }
        public ErrorDetails? ErrorDetails { get; set; }
    }

    public class ErrorDetails
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class ErrorCodes
    {
        public const string ValidationError = "ValidationError";
        public const string EmptyField = "EmptyField";
        public const string AlreadyExists = "AlreadyExists";
        public const string CanNotFind = "CanNotFind";
        public const string OtherError = "OtherError";
        // Add other error codes as needed
    }

    public class ApiResponseMessage
    {
        public static string GetResponseErrorMessge(string errorCode, string entityName, string fieldName = "", string fieldValue = "", string actionName = "")
        {
            switch (errorCode)
            {
                case ErrorCodes.ValidationError:
                    return $"Invalid {fieldName} for table {entityName}";
                case ErrorCodes.EmptyField:
                    return $"Value of {fieldName} can not be empty";
                case ErrorCodes.CanNotFind:
                    return $"Cannot find {fieldName}: {fieldValue} for table {entityName}";
                case ErrorCodes.AlreadyExists:
                    return $"{fieldName}: {fieldValue} already in the table {entityName}";
                default:
                    return $"Something wrong with {actionName} for table {entityName}";
            }
        }

        public static string GetSuccessfulResponse(string actionName)
        {
            return $"Successfully {actionName}";
        }
    }

    public static class ApiResponseErrorResult
    {
        public static IActionResult Error<T>(ApiResponse<T> apiResponse, ModelStateDictionary serviceState)
        {
            serviceState.AddModelError(apiResponse.ErrorDetails.ErrorCode, apiResponse.Message);
            switch (apiResponse.ErrorDetails.ErrorCode)
            {
                case ErrorCodes.ValidationError:
                case ErrorCodes.EmptyField:
                case ErrorCodes.CanNotFind:
                    return new BadRequestObjectResult(serviceState);
                case ErrorCodes.AlreadyExists:
                    return new ConflictObjectResult(serviceState);
                default:
                    return new ObjectResult(serviceState)
                    {
                        StatusCode = 500
                    };
            }
        }
    }

    public static class ApiResponseError<T>
    {
        public static ApiResponse<T> GenerateResponseError(string errorCode, string entityName, string fieldName = "", string fieldValue = "", string actionName = "")
        {
            ErrorDetails details = new ErrorDetails()
            {
                ErrorCode = errorCode,
                ErrorMessage = ApiResponseMessage.GetResponseErrorMessge(errorCode, entityName, fieldName, fieldValue, actionName)
            };

            return new ApiResponse<T>
            {
                ErrorDetails = details,
                Message = "",
                IsSuccessful = false
            };
        }

        public static ApiResponse<T> GenerateUnknownError(string errorCode, string message)
        {
            ErrorDetails details = new ErrorDetails()
            {
                ErrorCode = errorCode,
                ErrorMessage = message
            };

            return new ApiResponse<T>
            {
                ErrorDetails = details,
                Message = "",
                IsSuccessful = false
            };
        }
    }
}
