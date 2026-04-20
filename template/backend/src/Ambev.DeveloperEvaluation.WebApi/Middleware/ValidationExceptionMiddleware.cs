using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.WebApi.Common;
using FluentValidation;
using System.Text.Json;

namespace Ambev.DeveloperEvaluation.WebApi.Middleware
{
    public class ValidationExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                await HandleValidationExceptionAsync(context, ex);
            }
            catch (KeyNotFoundException ex)
            {
                await HandleNotFoundExceptionAsync(context, ex);
            }
            catch (InvalidOperationException ex)
            {
                await HandleBusinessExceptionAsync(context, ex);
            }
        }

        private static Task HandleValidationExceptionAsync(
            HttpContext context,
            ValidationException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var response = new ApiResponse
            {
                Success = false,
                Message = "Validation failed",
                Errors = exception.Errors
                    .Select(error => (ValidationErrorDetail)error)
            };

            return WriteResponseAsync(context, response);
        }

        private static Task HandleNotFoundExceptionAsync(
            HttpContext context,
            KeyNotFoundException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status404NotFound;

            var response = new ApiResponse
            {
                Success = false,
                Message = "Resource not found",
                Errors = new[]
                {
                    new ValidationErrorDetail
                    {
                        Error = "ResourceNotFound",
                        Detail = exception.Message
                    }
                }
            };

            return WriteResponseAsync(context, response);
        }

        private static Task HandleBusinessExceptionAsync(
            HttpContext context,
            InvalidOperationException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var response = new ApiResponse
            {
                Success = false,
                Message = "Business rule violation",
                Errors = new[]
                {
                    new ValidationErrorDetail
                    {
                        Error = "BusinessRuleViolation",
                        Detail = exception.Message
                    }
                }
            };

            return WriteResponseAsync(context, response);
        }

        private static Task WriteResponseAsync(
            HttpContext context,
            ApiResponse response)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return context.Response.WriteAsync(
                JsonSerializer.Serialize(response, jsonOptions));
        }
    }
}