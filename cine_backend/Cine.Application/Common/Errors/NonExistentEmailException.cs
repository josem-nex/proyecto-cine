using System.Net;

namespace Cine.Application.Common.Errors;
public class NonExistentEmailException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "Email does not exist.";
}