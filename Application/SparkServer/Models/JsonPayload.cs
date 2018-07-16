using SparkServer.Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.Models
{
    public class JsonPayload
    {
        public JsonStatus Status { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }

        public JsonPayload()
        {
            Data = new List<dynamic>();
        }
    }
}