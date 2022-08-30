// <copyright file="RefundTransaction.cs" company="APIMatic">
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
    /// RefundTransaction.
    /// </summary>
    public class RefundTransaction : FinancialTransaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RefundTransaction"/> class.
        /// </summary>
        public RefundTransaction()
        {
            this.TransactionType = "Refund";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RefundTransaction"/> class.
        /// </summary>
        /// <param name="transactionID">transactionID.</param>
        /// <param name="timestamp">timestamp.</param>
        /// <param name="amount">amount.</param>
        /// <param name="movementType">movementType.</param>
        /// <param name="userID">userID.</param>
        /// <param name="amountRefundedByBank">amountRefundedByBank.</param>
        /// <param name="amountRefundedToCustomer">amountRefundedToCustomer.</param>
        /// <param name="reason">reason.</param>
        /// <param name="originalPayoutTransaction">originalPayoutTransaction.</param>
        /// <param name="transactionType">transactionType.</param>
        /// <param name="transactionStatus">transactionStatus.</param>
        /// <param name="statementDetails">statementDetails.</param>
        /// <param name="fxExecutedDetail">fxExecutedDetail.</param>
        public RefundTransaction(
            Models.TransactionID transactionID,
            string timestamp,
            Models.MonetaryValue amount,
            Models.MoneyMovementTypeEnum movementType,
            Models.UserID userID,
            Models.MonetaryValue amountRefundedByBank,
            Models.MonetaryValue amountRefundedToCustomer,
            Models.Reason reason,
            Models.PayoutTransaction originalPayoutTransaction,
            string transactionType = "Refund",
            Models.FinancialTransactionStatus transactionStatus = null,
            List<Models.StatementDetail> statementDetails = null,
            Models.FXExecutedRate fxExecutedDetail = null)
            : base(
                transactionID,
                timestamp,
                amount,
                movementType,
                transactionType,
                transactionStatus,
                statementDetails)
        {
            this.UserID = userID;
            this.FxExecutedDetail = fxExecutedDetail;
            this.AmountRefundedByBank = amountRefundedByBank;
            this.AmountRefundedToCustomer = amountRefundedToCustomer;
            this.Reason = reason;
            this.OriginalPayoutTransaction = originalPayoutTransaction;
        }

        /// <summary>
        /// This group consists of all possible user identifier types. The 'epUserID' field is the VPL generated unique identifier for a User and is the equivalent of a Virtual Account Number (VAN). The 'merchantUserID' is a merchant specified identifier for the User. The 'epUserID', 'merchantUserID' or both 'epUserID' and 'merchantUserID' can be supplied. A mapping will be performed to retrieve the merchant user ID from the supplied EP user ID and vice versa. If both the 'epUserID' and 'merchantUserID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated.
        /// </summary>
        [JsonProperty("userID")]
        public Models.UserID UserID { get; set; }

        /// <summary>
        /// Holds details of an executed FX conversion that has occured as part of a financial transaction. The FX that occured was from the sellCurrency to the buyCurrency at a particular rate. The rate may have been requested via an FX Quote (fxTicketID). An FX conversion fee may have been applied to certain transaction types.
        /// </summary>
        [JsonProperty("fxExecutedDetail", NullValueHandling = NullValueHandling.Ignore)]
        public Models.FXExecutedRate FxExecutedDetail { get; set; }

        /// <summary>
        /// Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.
        /// </summary>
        [JsonProperty("amountRefundedByBank")]
        public Models.MonetaryValue AmountRefundedByBank { get; set; }

        /// <summary>
        /// Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.
        /// </summary>
        [JsonProperty("amountRefundedToCustomer")]
        public Models.MonetaryValue AmountRefundedToCustomer { get; set; }

        /// <summary>
        /// Reason for the refund as specified by the Business Banking Operations Department.
        /// </summary>
        [JsonProperty("reason")]
        public Models.Reason Reason { get; set; }

        /// <summary>
        /// A financial transaction representing a payout from an account held in the VPL system.
        /// </summary>
        [JsonProperty("originalPayoutTransaction")]
        public Models.PayoutTransaction OriginalPayoutTransaction { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RefundTransaction : ({string.Join(", ", toStringOutput)})";
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

            return obj is RefundTransaction other &&
                ((this.UserID == null && other.UserID == null) || (this.UserID?.Equals(other.UserID) == true)) &&
                ((this.FxExecutedDetail == null && other.FxExecutedDetail == null) || (this.FxExecutedDetail?.Equals(other.FxExecutedDetail) == true)) &&
                ((this.AmountRefundedByBank == null && other.AmountRefundedByBank == null) || (this.AmountRefundedByBank?.Equals(other.AmountRefundedByBank) == true)) &&
                ((this.AmountRefundedToCustomer == null && other.AmountRefundedToCustomer == null) || (this.AmountRefundedToCustomer?.Equals(other.AmountRefundedToCustomer) == true)) &&
                ((this.Reason == null && other.Reason == null) || (this.Reason?.Equals(other.Reason) == true)) &&
                ((this.OriginalPayoutTransaction == null && other.OriginalPayoutTransaction == null) || (this.OriginalPayoutTransaction?.Equals(other.OriginalPayoutTransaction) == true)) &&
                base.Equals(obj);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.UserID = {(this.UserID == null ? "null" : this.UserID.ToString())}");
            toStringOutput.Add($"this.FxExecutedDetail = {(this.FxExecutedDetail == null ? "null" : this.FxExecutedDetail.ToString())}");
            toStringOutput.Add($"this.AmountRefundedByBank = {(this.AmountRefundedByBank == null ? "null" : this.AmountRefundedByBank.ToString())}");
            toStringOutput.Add($"this.AmountRefundedToCustomer = {(this.AmountRefundedToCustomer == null ? "null" : this.AmountRefundedToCustomer.ToString())}");
            toStringOutput.Add($"this.Reason = {(this.Reason == null ? "null" : this.Reason.ToString())}");
            toStringOutput.Add($"this.OriginalPayoutTransaction = {(this.OriginalPayoutTransaction == null ? "null" : this.OriginalPayoutTransaction.ToString())}");

            base.ToString(toStringOutput);
        }
    }
}