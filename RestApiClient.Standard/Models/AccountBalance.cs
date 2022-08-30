// <copyright file="AccountBalance.cs" company="APIMatic">
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
    /// AccountBalance.
    /// </summary>
    public class AccountBalance
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountBalance"/> class.
        /// </summary>
        public AccountBalance()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountBalance"/> class.
        /// </summary>
        /// <param name="balance">balance.</param>
        /// <param name="balanceTimestamp">balanceTimestamp.</param>
        /// <param name="lastMovementTimestamp">lastMovementTimestamp.</param>
        public AccountBalance(
            Models.MonetaryValue balance,
            string balanceTimestamp = null,
            string lastMovementTimestamp = null)
        {
            this.Balance = balance;
            this.BalanceTimestamp = balanceTimestamp;
            this.LastMovementTimestamp = lastMovementTimestamp;
        }

        /// <summary>
        /// Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.
        /// </summary>
        [JsonProperty("balance")]
        public Models.MonetaryValue Balance { get; set; }

        /// <summary>
        /// The timestamp of when this balance was current at (This is most likely to be within milliseconds of the request time). This is a valid ISO 8601 timestamp, such as YYYY-MM-DDThh:mm:ss.sss±hh:mm.
        /// </summary>
        [JsonProperty("balanceTimestamp", NullValueHandling = NullValueHandling.Ignore)]
        public string BalanceTimestamp { get; set; }

        /// <summary>
        /// The timestamp of the last money movement on the customer’s account.This is a valid ISO 8601 timestamp, such as YYYY-MM-DDThh:mm:ss.sss±hh:mm.
        /// </summary>
        [JsonProperty("lastMovementTimestamp", NullValueHandling = NullValueHandling.Ignore)]
        public string LastMovementTimestamp { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AccountBalance : ({string.Join(", ", toStringOutput)})";
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

            return obj is AccountBalance other &&
                ((this.Balance == null && other.Balance == null) || (this.Balance?.Equals(other.Balance) == true)) &&
                ((this.BalanceTimestamp == null && other.BalanceTimestamp == null) || (this.BalanceTimestamp?.Equals(other.BalanceTimestamp) == true)) &&
                ((this.LastMovementTimestamp == null && other.LastMovementTimestamp == null) || (this.LastMovementTimestamp?.Equals(other.LastMovementTimestamp) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Balance = {(this.Balance == null ? "null" : this.Balance.ToString())}");
            toStringOutput.Add($"this.BalanceTimestamp = {(this.BalanceTimestamp == null ? "null" : this.BalanceTimestamp == string.Empty ? "" : this.BalanceTimestamp)}");
            toStringOutput.Add($"this.LastMovementTimestamp = {(this.LastMovementTimestamp == null ? "null" : this.LastMovementTimestamp == string.Empty ? "" : this.LastMovementTimestamp)}");
        }
    }
}