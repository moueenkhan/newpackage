// <copyright file="BeneficiaryAmountInformation.cs" company="APIMatic">
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
    /// BeneficiaryAmountInformation.
    /// </summary>
    public class BeneficiaryAmountInformation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryAmountInformation"/> class.
        /// </summary>
        public BeneficiaryAmountInformation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryAmountInformation"/> class.
        /// </summary>
        /// <param name="beneficiaryAmount">beneficiaryAmount.</param>
        /// <param name="payoutCurrency">payoutCurrency.</param>
        public BeneficiaryAmountInformation(
            Models.MonetaryValue beneficiaryAmount = null,
            string payoutCurrency = null)
        {
            this.BeneficiaryAmount = beneficiaryAmount;
            this.PayoutCurrency = payoutCurrency;
        }

        /// <summary>
        /// Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.
        /// </summary>
        [JsonProperty("beneficiaryAmount", NullValueHandling = NullValueHandling.Ignore)]
        public Models.MonetaryValue BeneficiaryAmount { get; set; }

        /// <summary>
        /// Valid supported ISO 4217 3-character currency code.
        /// </summary>
        [JsonProperty("payoutCurrency", NullValueHandling = NullValueHandling.Ignore)]
        public string PayoutCurrency { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BeneficiaryAmountInformation : ({string.Join(", ", toStringOutput)})";
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

            return obj is BeneficiaryAmountInformation other &&
                ((this.BeneficiaryAmount == null && other.BeneficiaryAmount == null) || (this.BeneficiaryAmount?.Equals(other.BeneficiaryAmount) == true)) &&
                ((this.PayoutCurrency == null && other.PayoutCurrency == null) || (this.PayoutCurrency?.Equals(other.PayoutCurrency) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BeneficiaryAmount = {(this.BeneficiaryAmount == null ? "null" : this.BeneficiaryAmount.ToString())}");
            toStringOutput.Add($"this.PayoutCurrency = {(this.PayoutCurrency == null ? "null" : this.PayoutCurrency == string.Empty ? "" : this.PayoutCurrency)}");
        }
    }
}