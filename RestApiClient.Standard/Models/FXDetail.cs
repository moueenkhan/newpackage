// <copyright file="FXDetail.cs" company="APIMatic">
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
    /// FXDetail.
    /// </summary>
    public class FXDetail
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FXDetail"/> class.
        /// </summary>
        public FXDetail()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FXDetail"/> class.
        /// </summary>
        /// <param name="buyAmount">buyAmount.</param>
        /// <param name="fxRate">fxRate.</param>
        /// <param name="sellAmount">sellAmount.</param>
        public FXDetail(
            Models.MonetaryValue buyAmount,
            Models.FXRate fxRate,
            Models.MonetaryValue sellAmount)
        {
            this.BuyAmount = buyAmount;
            this.FxRate = fxRate;
            this.SellAmount = sellAmount;
        }

        /// <summary>
        /// Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.
        /// </summary>
        [JsonProperty("buyAmount")]
        public Models.MonetaryValue BuyAmount { get; set; }

        /// <summary>
        /// Represents an FX rate between two currencies, the rate is restricted to 6 decimal places. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.
        /// </summary>
        [JsonProperty("fxRate")]
        public Models.FXRate FxRate { get; set; }

        /// <summary>
        /// Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.
        /// </summary>
        [JsonProperty("sellAmount")]
        public Models.MonetaryValue SellAmount { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FXDetail : ({string.Join(", ", toStringOutput)})";
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

            return obj is FXDetail other &&
                ((this.BuyAmount == null && other.BuyAmount == null) || (this.BuyAmount?.Equals(other.BuyAmount) == true)) &&
                ((this.FxRate == null && other.FxRate == null) || (this.FxRate?.Equals(other.FxRate) == true)) &&
                ((this.SellAmount == null && other.SellAmount == null) || (this.SellAmount?.Equals(other.SellAmount) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BuyAmount = {(this.BuyAmount == null ? "null" : this.BuyAmount.ToString())}");
            toStringOutput.Add($"this.FxRate = {(this.FxRate == null ? "null" : this.FxRate.ToString())}");
            toStringOutput.Add($"this.SellAmount = {(this.SellAmount == null ? "null" : this.SellAmount.ToString())}");
        }
    }
}