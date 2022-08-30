// <copyright file="TransactionsSearchResponse.cs" company="APIMatic">
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
    /// TransactionsSearchResponse.
    /// </summary>
    public class TransactionsSearchResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionsSearchResponse"/> class.
        /// </summary>
        public TransactionsSearchResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionsSearchResponse"/> class.
        /// </summary>
        /// <param name="transactions">transactions.</param>
        /// <param name="paginationResult">paginationResult.</param>
        public TransactionsSearchResponse(
            List<Models.FinancialTransaction> transactions = null,
            Models.PaginationResult paginationResult = null)
        {
            this.Transactions = transactions;
            this.PaginationResult = paginationResult;
        }

        /// <summary>
        /// Represents a transaction. This can any type of transaction among Payout transaction, Refund transaction, User deposit, Liquidity deposit, Journal transaction, Merchant liquidity movement and VPL Merchant Liquidity Transfer.
        /// </summary>
        [JsonProperty("transactions", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.FinancialTransaction> Transactions { get; set; }

        /// <summary>
        /// This returns a paged set of results rather than the full result set.
        /// </summary>
        [JsonProperty("paginationResult", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PaginationResult PaginationResult { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TransactionsSearchResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is TransactionsSearchResponse other &&
                ((this.Transactions == null && other.Transactions == null) || (this.Transactions?.Equals(other.Transactions) == true)) &&
                ((this.PaginationResult == null && other.PaginationResult == null) || (this.PaginationResult?.Equals(other.PaginationResult) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Transactions = {(this.Transactions == null ? "null" : $"[{string.Join(", ", this.Transactions)} ]")}");
            toStringOutput.Add($"this.PaginationResult = {(this.PaginationResult == null ? "null" : this.PaginationResult.ToString())}");
        }
    }
}