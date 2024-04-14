using System.Collections.Generic;
using CarModelManagement_CommonServices.Model;

namespace CarModelManagement_CommonServices.API.Helpers
{
    /// Global Response
    public class ResponseHelper
    {
           public static ResponseViewModel GetReponseForError(System.Exception exception, int errorCode = 400)
        {
            return new ResponseViewModel
            {
                data = null,
                errorMsg = exception.Message,
                errorID = errorCode,
                errorCode = exception.Data.Values.Count == 1 ? exception.Data["ErrorCode"].ToString() : "E0000",
                error = true
            };
        }
    }
}