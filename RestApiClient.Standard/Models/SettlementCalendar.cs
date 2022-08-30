// <copyright file="SettlementCalendar.cs" company="APIMatic">
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
    /// SettlementCalendar.
    /// </summary>
    public class SettlementCalendar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettlementCalendar"/> class.
        /// </summary>
        public SettlementCalendar()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SettlementCalendar"/> class.
        /// </summary>
        /// <param name="submitBy">submitBy.</param>
        /// <param name="forValueOn">forValueOn.</param>
        public SettlementCalendar(
            string submitBy,
            string forValueOn)
        {
            this.SubmitBy = submitBy;
            this.ForValueOn = forValueOn;
        }

        /// <summary>
        /// A valid ISO 8601 timestamp, such as YYYY-MM-DDThh:mm:ss.sss±hh:mm. Represents settlement cut-off time.
        /// </summary>
        [JsonProperty("submitBy")]
        public string SubmitBy { get; set; }

        /// <summary>
        /// Valid ISO 8601 date format YYYY-MM-DD. Represents settlement date.
        /// </summary>
        [JsonProperty("forValueOn")]
        public string ForValueOn { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SettlementCalendar : ({string.Join(", ", toStringOutput)})";
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

            return obj is SettlementCalendar other &&
                ((this.SubmitBy == null && other.SubmitBy == null) || (this.SubmitBy?.Equals(other.SubmitBy) == true)) &&
                ((this.ForValueOn == null && other.ForValueOn == null) || (this.ForValueOn?.Equals(other.ForValueOn) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.SubmitBy = {(this.SubmitBy == null ? "null" : this.SubmitBy == string.Empty ? "" : this.SubmitBy)}");
            toStringOutput.Add($"this.ForValueOn = {(this.ForValueOn == null ? "null" : this.ForValueOn == string.Empty ? "" : this.ForValueOn)}");
        }
    }
}