using System.Collections.Generic;
using System;

public class ApiResponse<T>
{
    public string Status { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public object Metadata { get; set; }
    public List<string> Errors { get; set; }

    private ApiResponse() { }

    public static ApiResponse<T> Success(T data, string message = "Operation completed successfully.", object metadata = null)
    {
        return new ApiResponse<T>
        {
            Status = "Success",
            Message = message,
            Data = data,
            Metadata = metadata
        };
    }

    public static ApiResponse<string> Error(string message, string details = null, List<string> errors = null)
    {
        return new ApiResponse<string>
        {
            Status = "Error",
            Message = message,
            Data = details,
            Errors = errors
        };
    }

    public static ApiResponse<string> FromException(Exception ex)
    {
        var errors = new List<string>();
        var currentException = ex;

        while (currentException != null)
        {
            errors.Add(currentException.Message);
            currentException = currentException.InnerException;
        }

        return new ApiResponse<string>
        {
            Status = "Error",
            Message = ex.Message,
            Data = ex.StackTrace ?? string.Empty,
            Errors = errors
        };
    }

    public bool IsSuccess()
    {
        return Status == "Success";
    }

    public bool IsError()
    {
        return Status == "Error";
    }

    public override string ToString()
    {
        return $"Status: {Status}, Message: {Message}, Data: {Data}, Metadata: {Metadata}";
    }
}