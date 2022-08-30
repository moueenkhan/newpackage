// <copyright file="QuotesBulkRequest.cs" company="APIMatic">
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
    /// QuotesBulkRequest.
    /// </summary>
    public class QuotesBulkRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuotesBulkRequest"/> class.
        /// </summary>
        public QuotesBulkRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuotesBulkRequest"/> class.
        /// </summary>
        /// <param name="sellCurrency">sellCurrency.</param>
        /// <param name="buyCurrency">buyCurrency.</param>
        /// <param name="buyCountry">buyCountry.</param>
        /// <param name="serviceLevel">serviceLevel.</param>
        public QuotesBulkRequest(
            string sellCurrency,
            string buyCurrency = null,
            string buyCountry = null,
            Models.ServiceLevelEnum? serviceLevel = null)
        {
            this.SellCurrency = sellCurrency;
            this.BuyCurrency = buyCurrency;
            this.BuyCountry = buyCountry;
            this.ServiceLevel = serviceLevel;
        }

        /// <summary>
        /// Valid supported ISO 4217 3-character currency code. Sell Currency is the currency the merchant wishes to be debited in.
        /// </summary>
        [JsonProperty("sellCurrency")]
        public string SellCurrency { get; set; }

        /// <summary>
        /// Valid supported ISO 4217 3-character currency code. Buy Currency is the currency the merchant wishes to buy or convert the sell currency into. For a Payment Request this must be one of the currencies registered for a Beneficiary Bank Account, otherwise the VPL system will throw a validation error.
        /// </summary>
        [JsonProperty("buyCurrency", NullValueHandling = NullValueHandling.Ignore)]
        public string BuyCurrency { get; set; }

        /// <summary>
        /// Valid supported ISO 3166 2-character country code. Represents Buy Country for which FxRate was found.
        /// </summary>
        [JsonProperty("buyCountry", NullValueHandling = NullValueHandling.Ignore)]
        public string BuyCountry { get; set; }

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

            return $"QuotesBulkRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is QuotesBulkRequest other &&
                ((this.SellCurrency == null && other.SellCurrency == null) || (this.SellCurrency?.Equals(other.SellCurrency) == true)) &&
                ((this.BuyCurrency == null && other.BuyCurrency == null) || (this.BuyCurrency?.Equals(other.BuyCurrency) == true)) &&
                ((this.BuyCountry == null && other.BuyCountry == null) || (this.BuyCountry?.Equals(other.BuyCountry) == true)) &&
                ((this.ServiceLevel == null && other.ServiceLevel == null) || (this.ServiceLevel?.Equals(other.ServiceLevel) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.SellCurrency = {(this.SellCurrency == null ? "null" : this.SellCurrency == string.Empty ? "" : this.SellCurrency)}");
            toStringOutput.Add($"this.BuyCurrency = {(this.BuyCurrency == null ? "null" : this.BuyCurrency == string.Empty ? "" : this.BuyCurrency)}");
            toStringOutput.Add($"this.BuyCountry = {(this.BuyCountry == null ? "null" : this.BuyCountry == string.Empty ? "" : this.BuyCountry)}");
            toStringOutput.Add($"this.ServiceLevel = {(this.ServiceLevel == null ? "null" : this.ServiceLevel.ToString())}");
        }
    }
}