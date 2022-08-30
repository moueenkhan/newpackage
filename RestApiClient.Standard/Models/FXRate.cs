// <copyright file="FXRate.cs" company="APIMatic">
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
    /// FXRate.
    /// </summary>
    public class FXRate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FXRate"/> class.
        /// </summary>
        public FXRate()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FXRate"/> class.
        /// </summary>
        /// <param name="buyCurrency">buyCurrency.</param>
        /// <param name="rate">rate.</param>
        /// <param name="sellCurrency">sellCurrency.</param>
        public FXRate(
            string buyCurrency,
            double rate,
            string sellCurrency)
        {
            this.BuyCurrency = buyCurrency;
            this.Rate = rate;
            this.SellCurrency = sellCurrency;
        }

        /// <summary>
        /// Valid supported ISO 4217 3-character currency code.
        /// </summary>
        [JsonProperty("buyCurrency")]
        public string BuyCurrency { get; set; }

        /// <summary>
        /// It is the exchange rate at which the buy currency is exchanged into the sell currency. In other words it is the buyCurrency:SellCurrency conversation ratio.
        /// </summary>
        [JsonProperty("rate")]
        public double Rate { get; set; }

        /// <summary>
        /// Valid supported ISO 4217 3-character currency code.
        /// </summary>
        [JsonProperty("sellCurrency")]
        public string SellCurrency { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FXRate : ({string.Join(", ", toStringOutput)})";
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

            return obj is FXRate other &&
                ((this.BuyCurrency == null && other.BuyCurrency == null) || (this.BuyCurrency?.Equals(other.BuyCurrency) == true)) &&
                this.Rate.Equals(other.Rate) &&
                ((this.SellCurrency == null && other.SellCurrency == null) || (this.SellCurrency?.Equals(other.SellCurrency) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BuyCurrency = {(this.BuyCurrency == null ? "null" : this.BuyCurrency == string.Empty ? "" : this.BuyCurrency)}");
            toStringOutput.Add($"this.Rate = {this.Rate}");
            toStringOutput.Add($"this.SellCurrency = {(this.SellCurrency == null ? "null" : this.SellCurrency == string.Empty ? "" : this.SellCurrency)}");
        }
    }
}