// <copyright file="ValidationException.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RestApiClient.Standard.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using JsonSubTypes;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using RestApiClient.Standard;
    using RestApiClient.Standard.Http.Client;
    using RestApiClient.Standard.Models;
    using RestApiClient.Standard.Utilities;

    /// <summary>
    /// ValidationException.
    /// </summary>
    public class ValidationException : ApiException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="reason"> The reason for throwing exception.</param>
        /// <param name="context"> The HTTP context that encapsulates request and response objects.</param>
        public ValidationException(string reason, HttpContext context)
            : base(reason, context)
        {
        }

        /// <summary>
        /// Timestamp of the failure.
        /// </summary>
        [JsonProperty("timeOfFailure")]
        public string TimeOfFailure { get; set; }

        /// <summary>
        /// Type of failure - will always be validation.
        /// </summary>
        [JsonProperty("failureType")]
        public string FailureType { get; set; }

        /// <summary>
        /// Short descriptive message of the error.
        /// </summary>
        [JsonProperty("shortMsg")]
        public string ShortMsg { get; set; }

        /// <summary>
        /// More descriptive message of the error.
        /// </summary>
        [JsonProperty("longMsg")]
        public string LongMsg { get; set; }

        /// <summary>
        /// An VPL specific error code.
        /// </summary>
        [JsonProperty("code")]
        public long Code { get; set; }

        /// <summary>
        /// A VPL generated unique error ID.
        /// </summary>
        [JsonProperty("uniqueErrorID")]
        public string UniqueErrorID { get; set; }

        /// <summary>
        /// An array of validation failures. For instance, if this error is during the creation or validation of a bank account, then each failure could relate to each individual bank account field validation error.
        /// </summary>
        [JsonProperty("failures")]
        public List<Models.Failure> Failures { get; set; }
    }
}