// <copyright file="GetPayoutRequiredDataForBank.cs" company="APIMatic">
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
    /// GetPayoutRequiredDataForBank.
    /// </summary>
    public class GetPayoutRequiredDataForBank
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetPayoutRequiredDataForBank"/> class.
        /// </summary>
        public GetPayoutRequiredDataForBank()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPayoutRequiredDataForBank"/> class.
        /// </summary>
        /// <param name="usersBankID">usersBankID.</param>
        /// <param name="amount">amount.</param>
        /// <param name="payer">payer.</param>
        /// <param name="serviceLevel">serviceLevel.</param>
        public GetPayoutRequiredDataForBank(
            Models.UsersBankID usersBankID,
            Models.MonetaryValue amount = null,
            Models.PayerTypeEnum? payer = null,
            Models.ServiceLevelEnum? serviceLevel = null)
        {
            this.Amount = amount;
            this.Payer = payer;
            this.ServiceLevel = serviceLevel;
            this.UsersBankID = usersBankID;
        }

        /// <summary>
        /// Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.
        /// </summary>
        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public Models.MonetaryValue Amount { get; set; }

        /// <summary>
        /// The type of Payer making the payment. This determines which identity details are used as the payer identity.
        /// </summary>
        [JsonProperty("payer", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.PayerTypeEnum? Payer { get; set; }

        /// <summary>
        /// Supported service levels for a payout request (standard or express).
        /// </summary>
        [JsonProperty("serviceLevel", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.ServiceLevelEnum? ServiceLevel { get; set; }

        /// <summary>
        /// This group consists of a collection of both the user ID group and beneficiary bank ID group. The 'userID' is a collection of user identifier types. The 'benBankID' is a collection of account identifier types. Both the 'userID' and 'benBankID' fields are mandatory.
        /// </summary>
        [JsonProperty("usersBankID")]
        public Models.UsersBankID UsersBankID { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"GetPayoutRequiredDataForBank : ({string.Join(", ", toStringOutput)})";
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

            return obj is GetPayoutRequiredDataForBank other &&
                ((this.Amount == null && other.Amount == null) || (this.Amount?.Equals(other.Amount) == true)) &&
                ((this.Payer == null && other.Payer == null) || (this.Payer?.Equals(other.Payer) == true)) &&
                ((this.ServiceLevel == null && other.ServiceLevel == null) || (this.ServiceLevel?.Equals(other.ServiceLevel) == true)) &&
                ((this.UsersBankID == null && other.UsersBankID == null) || (this.UsersBankID?.Equals(other.UsersBankID) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Amount = {(this.Amount == null ? "null" : this.Amount.ToString())}");
            toStringOutput.Add($"this.Payer = {(this.Payer == null ? "null" : this.Payer.ToString())}");
            toStringOutput.Add($"this.ServiceLevel = {(this.ServiceLevel == null ? "null" : this.ServiceLevel.ToString())}");
            toStringOutput.Add($"this.UsersBankID = {(this.UsersBankID == null ? "null" : this.UsersBankID.ToString())}");
        }
    }
}