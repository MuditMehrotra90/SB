using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SB.Application
{
    [Serializable]
    [DataContract]
    public class ApiResponse
    {
        [DataMember(Name = "result")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Result { get; }
        [DataMember(Name = "statusCode")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int StatusCode { get; }
        [DataMember(Name = "status")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool Status { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "message")]
        public string Message { get; }

       
        [DataMember(Name = "errorMessage")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage { get; set; } = "";

     

        public ApiResponse(int statusCode, bool succeeded, object result = null, string message="", string errorMessage="")
        {
            StatusCode = statusCode;
            Status = succeeded;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            Result = result;
            ErrorMessage = errorMessage;
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {

                case 404:
                    return "Resource not found";
                case 500:
                    return "An unhandled error occurred";
                default:
                    return null;
            }
        }
    }

    public class ApiOkResponse : ApiResponse
    {

        public ApiOkResponse(object result, string message = "Data is successffully returned.")
            : base(200, true, message)
        {

        }
    }

    public class ApiBadRequestResponse : ApiResponse
    {
        public object result { get; }

        public ApiBadRequestResponse(ModelStateDictionary modelState, string message = "Bad Request Error.")
            : base(400, false, message)
        {

            result = modelState.SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage).ToArray();
        }
    }
}
