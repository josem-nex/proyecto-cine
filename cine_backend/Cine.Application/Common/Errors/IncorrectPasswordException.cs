using System.Net;

namespace Cine.Application.Common.Errors;
public class IncorrectPasswordException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "Incorrect password.";
}