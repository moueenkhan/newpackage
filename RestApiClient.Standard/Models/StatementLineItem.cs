// <copyright file="StatementLineItem.cs" company="APIMatic">
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
    /// StatementLineItem.
    /// </summary>
    public class StatementLineItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatementLineItem"/> class.
        /// </summary>
        public StatementLineItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatementLineItem"/> class.
        /// </summary>
        /// <param name="transaction">transaction.</param>
        /// <param name="balance">balance.</param>
        public StatementLineItem(
            Models.FinancialTransaction transaction,
            double balance)
        {
            this.Transaction = transaction;
            this.Balance = balance;
        }

        /// <summary>
        /// Minimum set of data that constitutes a financial transaction. Here are the list of all the Transaction Types; [Payout](#/http/models/structures/payout-transaction), [Refund](#/http/models/structures/refund-transaction), [User Deposit](#/http/models/structures/user-deposit-transaction), [Merchant Liquidity Deposit](#/http/models/structures/liquidity-deposit-transaction), [Journal](#/http/models/structures/journal-transaction), [Merchant Liquidity Movement](#/http/models/structures/merchant-liquidity-movement-transaction), [Earthport Merchant Liquidity Transfer](#/http/models/structures/earthport-merchant-liquidity-transfer), [Transaction](#/http/models/structures/transaction-id).
        /// </summary>
        [JsonProperty("transaction")]
        public Models.FinancialTransaction Transaction { get; set; }

        /// <summary>
        /// Decimal amount value. The number of decimal places is defined by the currency.
        /// </summary>
        [JsonProperty("balance")]
        public double Balance { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"StatementLineItem : ({string.Join(", ", toStringOutput)})";
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

            return obj is StatementLineItem other &&
                ((this.Transaction == null && other.Transaction == null) || (this.Transaction?.Equals(other.Transaction) == true)) &&
                this.Balance.Equals(other.Balance);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Transaction = {(this.Transaction == null ? "null" : this.Transaction.ToString())}");
            toStringOutput.Add($"this.Balance = {this.Balance}");
        }
    }
}