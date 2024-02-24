using System.Net;

namespace Cine.Application.Common.Errors;
public interface IServiceException
{
    HttpStatusCode StatusCode { get; }
    string ErrorMessage { get; }
}