// <copyright file="BankAccountExpectedSettlementResponse.cs" company="APIMatic">
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
    /// BankAccountExpectedSettlementResponse.
    /// </summary>
    public class BankAccountExpectedSettlementResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountExpectedSettlementResponse"/> class.
        /// </summary>
        public BankAccountExpectedSettlementResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountExpectedSettlementResponse"/> class.
        /// </summary>
        /// <param name="isBankAccountValid">isBankAccountValid.</param>
        /// <param name="anticipatedPayoutRequestTime">anticipatedPayoutRequestTime.</param>
        /// <param name="serviceLevel">serviceLevel.</param>
        /// <param name="expectedSettlementDate">expectedSettlementDate.</param>
        public BankAccountExpectedSettlementResponse(
            bool isBankAccountValid,
            string anticipatedPayoutRequestTime = null,
            Models.ServiceLevelEnum? serviceLevel = null,
            string expectedSettlementDate = null)
        {
            this.IsBankAccountValid = isBankAccountValid;
            this.AnticipatedPayoutRequestTime = anticipatedPayoutRequestTime;
            this.ServiceLevel = serviceLevel;
            this.ExpectedSettlementDate = expectedSettlementDate;
        }

        /// <summary>
        /// Returns true if bank details have passed validation checks. In this case, the other response attributes of anticipatedPayoutRequestTime, serviceLevel and expectedSettlementDate are returned.
        /// </summary>
        [JsonProperty("isBankAccountValid")]
        public bool IsBankAccountValid { get; set; }

        /// <summary>
        /// A valid ISO 8601 timestamp, such as YYYY-MM-DDThh:mm:ss.sss±hh:mm. This is the timestamp when the payout is anticipated to be sent to Earthport. This matches the supplied anticipatedPayoutRequestTime request attribute but the value returned will be in UTC (zero offset) dateTime. Therefore, a value supplied as 2013-01-20T12:30:00-05:00 will be returned as the UTC equivalent of 2013-01-20T17:30:00+00:00.
        /// </summary>
        [JsonProperty("anticipatedPayoutRequestTime", NullValueHandling = NullValueHandling.Ignore)]
        public string AnticipatedPayoutRequestTime { get; set; }

        /// <summary>
        /// Supported service levels for a payout request (standard or express).
        /// </summary>
        [JsonProperty("serviceLevel", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.ServiceLevelEnum? ServiceLevel { get; set; }

        /// <summary>
        /// Valid ISO 8601 date format YYYY-MM-DD. This is an indicative date when the payout instruction is expected to be settled to the bank.
        /// </summary>
        [JsonProperty("expectedSettlementDate", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpectedSettlementDate { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BankAccountExpectedSettlementResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is BankAccountExpectedSettlementResponse other &&
                this.IsBankAccountValid.Equals(other.IsBankAccountValid) &&
                ((this.AnticipatedPayoutRequestTime == null && other.AnticipatedPayoutRequestTime == null) || (this.AnticipatedPayoutRequestTime?.Equals(other.AnticipatedPayoutRequestTime) == true)) &&
                ((this.ServiceLevel == null && other.ServiceLevel == null) || (this.ServiceLevel?.Equals(other.ServiceLevel) == true)) &&
                ((this.ExpectedSettlementDate == null && other.ExpectedSettlementDate == null) || (this.ExpectedSettlementDate?.Equals(other.ExpectedSettlementDate) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IsBankAccountValid = {this.IsBankAccountValid}");
            toStringOutput.Add($"this.AnticipatedPayoutRequestTime = {(this.AnticipatedPayoutRequestTime == null ? "null" : this.AnticipatedPayoutRequestTime == string.Empty ? "" : this.AnticipatedPayoutRequestTime)}");
            toStringOutput.Add($"this.ServiceLevel = {(this.ServiceLevel == null ? "null" : this.ServiceLevel.ToString())}");
            toStringOutput.Add($"this.ExpectedSettlementDate = {(this.ExpectedSettlementDate == null ? "null" : this.ExpectedSettlementDate == string.Empty ? "" : this.ExpectedSettlementDate)}");
        }
    }
}