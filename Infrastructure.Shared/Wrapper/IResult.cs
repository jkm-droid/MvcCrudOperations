using System.Collections.Generic;
using System.Net;

namespace Infrastructure.Shared.Wrapper
{
  public interface IResult
  {
    List<string> Messages { get; set; }

    bool Succeeded { get; set; }
    HttpStatusCode StatusCode { get; set; }
  }

  public interface IResult<out T> : IResult
  {
    T Data { get; }
  }
}
