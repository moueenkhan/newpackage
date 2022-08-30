// <copyright file="SettlementCalendarsGetResponse.cs" company="APIMatic">
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
    /// SettlementCalendarsGetResponse.
    /// </summary>
    public class SettlementCalendarsGetResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettlementCalendarsGetResponse"/> class.
        /// </summary>
        public SettlementCalendarsGetResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SettlementCalendarsGetResponse"/> class.
        /// </summary>
        /// <param name="responseTimeStamp">responseTimeStamp.</param>
        /// <param name="settlementCalendar">settlementCalendar.</param>
        public SettlementCalendarsGetResponse(
            string responseTimeStamp,
            List<Models.SettlementCalendar> settlementCalendar)
        {
            this.ResponseTimeStamp = responseTimeStamp;
            this.SettlementCalendar = settlementCalendar;
        }

        /// <summary>
        /// A valid ISO 8601 timestamp, such as YYYY-MM-DDThh:mm:ss.sss±hh:mm. Represents the timestamp when the Settlement Calendar was generated.
        /// </summary>
        [JsonProperty("responseTimeStamp")]
        public string ResponseTimeStamp { get; set; }

        /// <summary>
        /// Represents a calander of settlement dates and the cut-off time for these settlement dates.
        /// </summary>
        [JsonProperty("settlementCalendar")]
        public List<Models.SettlementCalendar> SettlementCalendar { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SettlementCalendarsGetResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is SettlementCalendarsGetResponse other &&
                ((this.ResponseTimeStamp == null && other.ResponseTimeStamp == null) || (this.ResponseTimeStamp?.Equals(other.ResponseTimeStamp) == true)) &&
                ((this.SettlementCalendar == null && other.SettlementCalendar == null) || (this.SettlementCalendar?.Equals(other.SettlementCalendar) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ResponseTimeStamp = {(this.ResponseTimeStamp == null ? "null" : this.ResponseTimeStamp == string.Empty ? "" : this.ResponseTimeStamp)}");
            toStringOutput.Add($"this.SettlementCalendar = {(this.SettlementCalendar == null ? "null" : $"[{string.Join(", ", this.SettlementCalendar)} ]")}");
        }
    }
}