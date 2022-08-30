// <copyright file="QuotesRequest.cs" company="APIMatic">
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
    /// QuotesRequest.
    /// </summary>
    public class QuotesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuotesRequest"/> class.
        /// </summary>
        public QuotesRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuotesRequest"/> class.
        /// </summary>
        /// <param name="sellAmount">sellAmount.</param>
        /// <param name="buyCurrency">buyCurrency.</param>
        /// <param name="buyAmount">buyAmount.</param>
        /// <param name="sellCurrency">sellCurrency.</param>
        /// <param name="serviceLevel">serviceLevel.</param>
        public QuotesRequest(
            Models.MonetaryValue sellAmount = null,
            string buyCurrency = null,
            Models.MonetaryValue buyAmount = null,
            string sellCurrency = null,
            Models.ServiceLevelEnum? serviceLevel = null)
        {
            this.SellAmount = sellAmount;
            this.BuyCurrency = buyCurrency;
            this.BuyAmount = buyAmount;
            this.SellCurrency = sellCurrency;
            this.ServiceLevel = serviceLevel;
        }

        /// <summary>
        /// Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.
        /// </summary>
        [JsonProperty("sellAmount", NullValueHandling = NullValueHandling.Ignore)]
        public Models.MonetaryValue SellAmount { get; set; }

        /// <summary>
        /// Valid supported ISO 4217 3-character currency code. Buy Currency is the currency the merchant wishes to buy or convert the sell currency into. For a Payment Request this must be one of the currencies registered for a Beneficiary Bank Account or Beneficiary Wallet, otherwise the VPL system will throw a validation error.
        /// </summary>
        [JsonProperty("buyCurrency", NullValueHandling = NullValueHandling.Ignore)]
        public string BuyCurrency { get; set; }

        /// <summary>
        /// Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.
        /// </summary>
        [JsonProperty("buyAmount", NullValueHandling = NullValueHandling.Ignore)]
        public Models.MonetaryValue BuyAmount { get; set; }

        /// <summary>
        /// Valid supported ISO 4217 3-character currency code. Sell Currency is the currency the merchant wishes to be debited in, in order to buy the Buy Amount.
        /// </summary>
        [JsonProperty("sellCurrency", NullValueHandling = NullValueHandling.Ignore)]
        public string SellCurrency { get; set; }

        /// <summary>
        /// Supported service levels for a payout request (standard or express).
        /// </summary>
        [JsonProperty("serviceLevel", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.ServiceLevelEnum? ServiceLevel { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"QuotesRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is QuotesRequest other &&
                ((this.SellAmount == null && other.SellAmount == null) || (this.SellAmount?.Equals(other.SellAmount) == true)) &&
                ((this.BuyCurrency == null && other.BuyCurrency == null) || (this.BuyCurrency?.Equals(other.BuyCurrency) == true)) &&
                ((this.BuyAmount == null && other.BuyAmount == null) || (this.BuyAmount?.Equals(other.BuyAmount) == true)) &&
                ((this.SellCurrency == null && other.SellCurrency == null) || (this.SellCurrency?.Equals(other.SellCurrency) == true)) &&
                ((this.ServiceLevel == null && other.ServiceLevel == null) || (this.ServiceLevel?.Equals(other.ServiceLevel) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.SellAmount = {(this.SellAmount == null ? "null" : this.SellAmount.ToString())}");
            toStringOutput.Add($"this.BuyCurrency = {(this.BuyCurrency == null ? "null" : this.BuyCurrency == string.Empty ? "" : this.BuyCurrency)}");
            toStringOutput.Add($"this.BuyAmount = {(this.BuyAmount == null ? "null" : this.BuyAmount.ToString())}");
            toStringOutput.Add($"this.SellCurrency = {(this.SellCurrency == null ? "null" : this.SellCurrency == string.Empty ? "" : this.SellCurrency)}");
            toStringOutput.Add($"this.ServiceLevel = {(this.ServiceLevel == null ? "null" : this.ServiceLevel.ToString())}");
        }
    }
}