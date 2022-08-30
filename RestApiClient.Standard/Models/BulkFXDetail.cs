// <copyright file="BulkFXDetail.cs" company="APIMatic">
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
    /// BulkFXDetail.
    /// </summary>
    public class BulkFXDetail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkFXDetail"/> class.
        /// </summary>
        public BulkFXDetail()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BulkFXDetail"/> class.
        /// </summary>
        /// <param name="sellCurrency">sellCurrency.</param>
        /// <param name="buyCurrency">buyCurrency.</param>
        /// <param name="buyCountry">buyCountry.</param>
        /// <param name="serviceLevel">serviceLevel.</param>
        /// <param name="buyFxRate">buyFxRate.</param>
        /// <param name="sellFxRate">sellFxRate.</param>
        public BulkFXDetail(
            string sellCurrency,
            string buyCurrency = null,
            string buyCountry = null,
            Models.ServiceLevelEnum? serviceLevel = null,
            double? buyFxRate = null,
            double? sellFxRate = null)
        {
            this.SellCurrency = sellCurrency;
            this.BuyCurrency = buyCurrency;
            this.BuyCountry = buyCountry;
            this.ServiceLevel = serviceLevel;
            this.BuyFxRate = buyFxRate;
            this.SellFxRate = sellFxRate;
        }

        /// <summary>
        /// Valid supported ISO 4217 3-character currency code. Represents Sell Currency for which FxRate was found.
        /// </summary>
        [JsonProperty("sellCurrency")]
        public string SellCurrency { get; set; }

        /// <summary>
        /// Valid supported ISO 4217 3-character currency code. Represents Buy Currency for which FxRate was found.
        /// </summary>
        [JsonProperty("buyCurrency", NullValueHandling = NullValueHandling.Ignore)]
        public string BuyCurrency { get; set; }

        /// <summary>
        /// Valid supported ISO 3166 2-character country code. Buy Country is the country of the Beneficiary Bank where the merchant wishes to buy or convert the sell currency.
        /// </summary>
        [JsonProperty("buyCountry", NullValueHandling = NullValueHandling.Ignore)]
        public string BuyCountry { get; set; }

        /// <summary>
        /// Supported service levels for a payout request (standard or express).
        /// </summary>
        [JsonProperty("serviceLevel", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.ServiceLevelEnum? ServiceLevel { get; set; }

        /// <summary>
        /// Represents the FX rate between two currencies that will be applied during a buy direction trade – buying x amount of beneficiary currency (buyCurrency). The rate is restricted to 6 decimal places.
        /// </summary>
        [JsonProperty("buyFxRate", NullValueHandling = NullValueHandling.Ignore)]
        public double? BuyFxRate { get; set; }

        /// <summary>
        /// Represents the FX rate between two currencies that will be effective during a sell direction trade – selling x amount of payout instruction currency (sellCurrency). The rate is restricted to 6 decimal places.
        /// </summary>
        [JsonProperty("sellFxRate", NullValueHandling = NullValueHandling.Ignore)]
        public double? SellFxRate { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BulkFXDetail : ({string.Join(", ", toStringOutput)})";
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

            return obj is BulkFXDetail other &&
                ((this.SellCurrency == null && other.SellCurrency == null) || (this.SellCurrency?.Equals(other.SellCurrency) == true)) &&
                ((this.BuyCurrency == null && other.BuyCurrency == null) || (this.BuyCurrency?.Equals(other.BuyCurrency) == true)) &&
                ((this.BuyCountry == null && other.BuyCountry == null) || (this.BuyCountry?.Equals(other.BuyCountry) == true)) &&
                ((this.ServiceLevel == null && other.ServiceLevel == null) || (this.ServiceLevel?.Equals(other.ServiceLevel) == true)) &&
                ((this.BuyFxRate == null && other.BuyFxRate == null) || (this.BuyFxRate?.Equals(other.BuyFxRate) == true)) &&
                ((this.SellFxRate == null && other.SellFxRate == null) || (this.SellFxRate?.Equals(other.SellFxRate) == true));
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
            toStringOutput.Add($"this.BuyFxRate = {(this.BuyFxRate == null ? "null" : this.BuyFxRate.ToString())}");
            toStringOutput.Add($"this.SellFxRate = {(this.SellFxRate == null ? "null" : this.SellFxRate.ToString())}");
        }
    }
}