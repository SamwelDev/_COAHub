using COAHub.Application.Application_Enums;
using COAHub.Application.Application_Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COAHub.Application.Application_Helpers
{
    public  class ResponseHelper
    {
        public static ResponseMapper<T> SetSuccess<T>(T? data = default, string? message = "Success!", string? description = "Success!", string? token = null, int CurrentPage = 1, int TotalCount = 1, int PageSize = 500)
        {
            return CreateResponse(SignalStatus.Success, data, message, description, token, CurrentPage, TotalCount, PageSize);
        }

        public static ResponseMapper<T> SetBadResponse<T>(T? data = default, string? message = "Bad Request", string? description = "Bad Request")
        {
            return CreateResponse(SignalStatus.BadRequest, data, message, description);
        }

        public static ResponseMapper<T> SetBadRequest<T>(T? data = default, string message = "Invalid request")
        {
            return CreateResponse(SignalStatus.BadRequest, data, message);
        }

        public static ResponseMapper<T> SetNoContent<T>(T? data = default, string message = "No Content")
        {
            return CreateResponse(SignalStatus.NoContent, data, message);
        }

        public static ResponseMapper<T> SetUnauthorized<T>(T? data = default, string message = "Unauthorized access")
        {
            return CreateResponse(SignalStatus.Unauthorized, data, message);
        }

        public static ResponseMapper<T> SetNotFound<T>(T? data = default, string message = "Not found")
        {
            return CreateResponse(SignalStatus.NotFound, data, message);
        }

        public static ResponseMapper<T> SetInternalServerError<T>(T? data = default, string message = "Unexpected error, contact admin")
        {
            return CreateResponse(SignalStatus.InternalServerError, data, message);
        }

        private static ResponseMapper<T> CreateResponse<T>(SignalStatus status, T? data = default, string? message = null, string? description = null, string? token = null, int CurrentPage = 1, int TotalCount = 1, int PageSize = 500)
        {
            return new ResponseMapper<T>
            {
                Status = (int)status,
                Message = message,
                Description = description,
                Data = data,
                Token = token,
                CurrentPage = CurrentPage,
                PageSize = PageSize,
                TotalCount = TotalCount,
            };
        }
    }

}
