using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace Nimbus.View.Api.ExceptionHandlers
{
    /// <summary>
    /// Implements <see cref="IExceptionHandler"/> to handle <see cref="InvalidOperationException"/>
    /// throughout the application by propogating errors up to the API response.
    /// </summary>
    public class InvalidOperationExceptionHandler : IExceptionHandler
    {
        /// <summary>
        /// Handles any <see cref="InvalidOperationException"/> that is thrown
        /// in the application by setting a <see cref="StatusCodes.Status400BadRequest"/>
        /// status code on the HTTP response, and propogating the exception's message.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="exception"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// <c>true</c> if the exception was handled, <c>false</c> otherwise.
        /// </returns>
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not InvalidOperationException)
            {
                return false;
            }

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            var problemDetails = CreateProblemDetails(httpContext, exception);
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }

        /// <summary>
        /// Creates an error response using the provided <paramref name="httpContext"/>
        /// and <paramref name="exception"/> to propogate to an HTTP response.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="exception"></param>
        /// <returns>
        /// A <see cref="ProblemDetails"/> filled with error information.
        /// </returns>
        private static ProblemDetails CreateProblemDetails(HttpContext httpContext, Exception exception)
        {
            var reasonPhrase = ReasonPhrases.GetReasonPhrase(httpContext.Response.StatusCode);
            if (string.IsNullOrEmpty(reasonPhrase))
            {
                reasonPhrase = "An invalid operation caused an error on the server.";
            }

            return new()
            {
                Status = httpContext.Response.StatusCode,
                Title = exception.Message ?? reasonPhrase,
            };
        }
    }
}
