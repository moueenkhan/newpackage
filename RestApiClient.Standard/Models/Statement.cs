// <copyright file="Statement.cs" company="APIMatic">
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
    /// Statement.
    /// </summary>
    public class Statement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Statement"/> class.
        /// </summary>
        public Statement()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Statement"/> class.
        /// </summary>
        /// <param name="statementLineItems">statementLineItems.</param>
        /// <param name="openingBalance">openingBalance.</param>
        /// <param name="closingBalance">closingBalance.</param>
        /// <param name="paginationResult">paginationResult.</param>
        public Statement(
            List<Models.StatementLineItem> statementLineItems,
            Models.AccountBalance openingBalance,
            Models.AccountBalance closingBalance,
            Models.PaginationResult paginationResult)
        {
            this.StatementLineItems = statementLineItems;
            this.OpeningBalance = openingBalance;
            this.ClosingBalance = closingBalance;
            this.PaginationResult = paginationResult;
        }

        /// <summary>
        /// List of 0 or more statement line item objects matching the request parameters. Each statement line item represents a financial transaction and an account balance resulting from the transaction.
        /// </summary>
        [JsonProperty("statementLineItems")]
        public List<Models.StatementLineItem> StatementLineItems { get; set; }

        /// <summary>
        /// This element represents the balance of a merchant account or a managed merchant account in a currency registered with the merchant's central virtual account.
        /// </summary>
        [JsonProperty("openingBalance")]
        public Models.AccountBalance OpeningBalance { get; set; }

        /// <summary>
        /// This element represents the balance of a merchant account or a managed merchant account in a currency registered with the merchant's central virtual account.
        /// </summary>
        [JsonProperty("closingBalance")]
        public Models.AccountBalance ClosingBalance { get; set; }

        /// <summary>
        /// This returns a paged set of results rather than the full result set.
        /// </summary>
        [JsonProperty("paginationResult")]
        public Models.PaginationResult PaginationResult { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Statement : ({string.Join(", ", toStringOutput)})";
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

            return obj is Statement other &&
                ((this.StatementLineItems == null && other.StatementLineItems == null) || (this.StatementLineItems?.Equals(other.StatementLineItems) == true)) &&
                ((this.OpeningBalance == null && other.OpeningBalance == null) || (this.OpeningBalance?.Equals(other.OpeningBalance) == true)) &&
                ((this.ClosingBalance == null && other.ClosingBalance == null) || (this.ClosingBalance?.Equals(other.ClosingBalance) == true)) &&
                ((this.PaginationResult == null && other.PaginationResult == null) || (this.PaginationResult?.Equals(other.PaginationResult) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.StatementLineItems = {(this.StatementLineItems == null ? "null" : $"[{string.Join(", ", this.StatementLineItems)} ]")}");
            toStringOutput.Add($"this.OpeningBalance = {(this.OpeningBalance == null ? "null" : this.OpeningBalance.ToString())}");
            toStringOutput.Add($"this.ClosingBalance = {(this.ClosingBalance == null ? "null" : this.ClosingBalance.ToString())}");
            toStringOutput.Add($"this.PaginationResult = {(this.PaginationResult == null ? "null" : this.PaginationResult.ToString())}");
        }
    }
}