using System.Net;
using CodeMasterDev.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeMasterDev.Api.Controllers
{
    public class ControllerSuper : ControllerBase
    {
        public static ActionResult CustomResponse(
            HttpStatusCode statusCode,
            bool success,
            string? message = null,
            object? data = null
            )
        {
            var objeto = new ObjectResponse()
            {
                Success = success,
                Message = message,
                Data = data
            };

            return new ObjectResult(objeto) { StatusCode = (int)statusCode };
        }

        public static ActionResult ResponseOk(object data)
        {
            return CustomResponse(HttpStatusCode.OK, true, null, data);
        }

        public static ActionResult ResponseServerError(Exception ex)
        {
            return CustomResponse(HttpStatusCode.InternalServerError, false, ex.Message);
        }

        public static ActionResult ResponseBadRequest(string message)
        {
            return CustomResponse(HttpStatusCode.BadRequest, false, message);
        }
    }
}
