// <copyright file="TransactionsCancelResponse.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RestApiClient.Standard.Models
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
    using RestApiClient.Standard.Utilities;

    /// <summary>
    /// TransactionsCancelResponse.
    /// </summary>
    public class TransactionsCancelResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionsCancelResponse"/> class.
        /// </summary>
        public TransactionsCancelResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionsCancelResponse"/> class.
        /// </summary>
        /// <param name="status">status.</param>
        /// <param name="statusDescription">statusDescription.</param>
        /// <param name="timestamp">timestamp.</param>
        public TransactionsCancelResponse(
            string status = null,
            string statusDescription = null,
            string timestamp = null)
        {
            this.Status = status;
            this.StatusDescription = statusDescription;
            this.Timestamp = timestamp;
        }

        /// <summary>
        /// Specifies the status of the associated transaction for the cancellation request.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        /// <summary>
        /// Description associated with the cancellation status.
        /// </summary>
        [JsonProperty("statusDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string StatusDescription { get; set; }

        /// <summary>
        /// A valid ISO 8601 timestamp, such as YYYY-MM-DDThh:mm:ss.sss±hh:mm. This represents the cancellation request timestamp.
        /// </summary>
        [JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public string Timestamp { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TransactionsCancelResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is TransactionsCancelResponse other &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.StatusDescription == null && other.StatusDescription == null) || (this.StatusDescription?.Equals(other.StatusDescription) == true)) &&
                ((this.Timestamp == null && other.Timestamp == null) || (this.Timestamp?.Equals(other.Timestamp) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status == string.Empty ? "" : this.Status)}");
            toStringOutput.Add($"this.StatusDescription = {(this.StatusDescription == null ? "null" : this.StatusDescription == string.Empty ? "" : this.StatusDescription)}");
            toStringOutput.Add($"this.Timestamp = {(this.Timestamp == null ? "null" : this.Timestamp == string.Empty ? "" : this.Timestamp)}");
        }
    }
}