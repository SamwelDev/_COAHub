using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COAHub.Application.Application_Enums
{
    public  enum SignalStatus
    {
        MultiStatus = 207,
        Success = 200,
        Created = 201,
        Accept = 202,
        PartialInformation = 203,
        NoContent = 204,
        ResetContent = 205,
        PartialContent = 206,
        AlreadyReported = 208,
        BadRequest = 400,
        Unauthorized = 401,
        NotFound = 404,
        InternalServerError = 500,
    }
}
