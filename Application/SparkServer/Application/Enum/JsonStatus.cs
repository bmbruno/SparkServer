using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.Application.Enum
{
    /// <summary>
    /// Identifies the status of a JSON payload.
    /// </summary>
    public enum JsonStatus
    {
        /// <summary>
        /// A program/code exception occurred.
        /// </summary>
        EXCEPTION = -1,

        /// <summary>
        /// A logic error occurred.
        /// </summary>
        ERROR = 0,

        /// <summary>
        /// Json is okay; normal processing can proceed.
        /// </summary>
        OK = 1
    }
}