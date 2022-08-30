// <copyright file="TransactionHold.cs" company="APIMatic">
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
    /// TransactionHold.
    /// </summary>
    public class TransactionHold
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionHold"/> class.
        /// </summary>
        public TransactionHold()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionHold"/> class.
        /// </summary>
        /// <param name="offsetMinutes">offsetMinutes.</param>
        /// <param name="releaseDateTime">releaseDateTime.</param>
        public TransactionHold(
            int? offsetMinutes = null,
            string releaseDateTime = null)
        {
            this.OffsetMinutes = offsetMinutes;
            this.ReleaseDateTime = releaseDateTime;
        }

        /// <summary>
        /// This is the time in minutes to hold the transaction until.
        /// </summary>
        [JsonProperty("offsetMinutes", NullValueHandling = NullValueHandling.Ignore)]
        public int? OffsetMinutes { get; set; }

        /// <summary>
        /// This is used when you want to provide a specific timestamp to hold the transaction until. A valid ISO 8601 timestamp, such as YYYY-MM-DDThh:mm:ss.sss±hh:mm.
        /// </summary>
        [JsonProperty("releaseDateTime", NullValueHandling = NullValueHandling.Ignore)]
        public string ReleaseDateTime { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TransactionHold : ({string.Join(", ", toStringOutput)})";
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

            return obj is TransactionHold other &&
                ((this.OffsetMinutes == null && other.OffsetMinutes == null) || (this.OffsetMinutes?.Equals(other.OffsetMinutes) == true)) &&
                ((this.ReleaseDateTime == null && other.ReleaseDateTime == null) || (this.ReleaseDateTime?.Equals(other.ReleaseDateTime) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.OffsetMinutes = {(this.OffsetMinutes == null ? "null" : this.OffsetMinutes.ToString())}");
            toStringOutput.Add($"this.ReleaseDateTime = {(this.ReleaseDateTime == null ? "null" : this.ReleaseDateTime == string.Empty ? "" : this.ReleaseDateTime)}");
        }
    }
}