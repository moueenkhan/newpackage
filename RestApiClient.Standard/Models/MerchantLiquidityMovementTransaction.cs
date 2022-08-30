// <copyright file="MerchantLiquidityMovementTransaction.cs" company="APIMatic">
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
    /// MerchantLiquidityMovementTransaction.
    /// </summary>
    public class MerchantLiquidityMovementTransaction : FinancialTransaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MerchantLiquidityMovementTransaction"/> class.
        /// </summary>
        public MerchantLiquidityMovementTransaction()
        {
            this.TransactionType = "Merchant Liquidity Movement";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MerchantLiquidityMovementTransaction"/> class.
        /// </summary>
        /// <param name="transactionID">transactionID.</param>
        /// <param name="timestamp">timestamp.</param>
        /// <param name="amount">amount.</param>
        /// <param name="movementType">movementType.</param>
        /// <param name="transactionType">transactionType.</param>
        /// <param name="transactionStatus">transactionStatus.</param>
        /// <param name="statementDetails">statementDetails.</param>
        /// <param name="fxExecutedDetail">fxExecutedDetail.</param>
        /// <param name="description">description.</param>
        public MerchantLiquidityMovementTransaction(
            Models.TransactionID transactionID,
            string timestamp,
            Models.MonetaryValue amount,
            Models.MoneyMovementTypeEnum movementType,
            string transactionType = "Merchant Liquidity Movement",
            Models.FinancialTransactionStatus transactionStatus = null,
            List<Models.StatementDetail> statementDetails = null,
            Models.FXExecutedRate fxExecutedDetail = null,
            string description = null)
            : base(
                transactionID,
                timestamp,
                amount,
                movementType,
                transactionType,
                transactionStatus,
                statementDetails)
        {
            this.FxExecutedDetail = fxExecutedDetail;
            this.Description = description;
        }

        /// <summary>
        /// Holds details of an executed FX conversion that has occured as part of a financial transaction. The FX that occured was from the sellCurrency to the buyCurrency at a particular rate. The rate may have been requested via an FX Quote (fxTicketID). An FX conversion fee may have been applied to certain transaction types.
        /// </summary>
        [JsonProperty("fxExecutedDetail", NullValueHandling = NullValueHandling.Ignore)]
        public Models.FXExecutedRate FxExecutedDetail { get; set; }

        /// <summary>
        /// A reason or description or narrative as entered against the journal entry.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"MerchantLiquidityMovementTransaction : ({string.Join(", ", toStringOutput)})";
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

            return obj is MerchantLiquidityMovementTransaction other &&
                ((this.FxExecutedDetail == null && other.FxExecutedDetail == null) || (this.FxExecutedDetail?.Equals(other.FxExecutedDetail) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                base.Equals(obj);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.FxExecutedDetail = {(this.FxExecutedDetail == null ? "null" : this.FxExecutedDetail.ToString())}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");

            base.ToString(toStringOutput);
        }
    }
}