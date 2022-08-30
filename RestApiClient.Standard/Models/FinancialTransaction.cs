// <copyright file="FinancialTransaction.cs" company="APIMatic">
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
    /// FinancialTransaction.
    /// </summary>
    [JsonConverter(typeof(JsonSubtypes), "transactionType")]
    [JsonSubtypes.KnownSubType(typeof(RefundTransaction), "Refund")]
    [JsonSubtypes.KnownSubType(typeof(UserDepositTransaction), "User Deposit")]
    [JsonSubtypes.KnownSubType(typeof(PayoutTransaction), "Payout")]
    [JsonSubtypes.KnownSubType(typeof(JournalTransaction), "Journal")]
    [JsonSubtypes.KnownSubType(typeof(LiquidityDepositTransaction), "Merchant Liquidity Deposit")]
    [JsonSubtypes.KnownSubType(typeof(MerchantLiquidityMovementTransaction), "Merchant Liquidity Movement")]
    public class FinancialTransaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialTransaction"/> class.
        /// </summary>
        public FinancialTransaction()
        {
            this.TransactionType = "Transaction";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialTransaction"/> class.
        /// </summary>
        /// <param name="transactionID">transactionID.</param>
        /// <param name="timestamp">timestamp.</param>
        /// <param name="amount">amount.</param>
        /// <param name="movementType">movementType.</param>
        /// <param name="transactionType">transactionType.</param>
        /// <param name="transactionStatus">transactionStatus.</param>
        /// <param name="statementDetails">statementDetails.</param>
        public FinancialTransaction(
            Models.TransactionID transactionID,
            string timestamp,
            Models.MonetaryValue amount,
            Models.MoneyMovementTypeEnum movementType,
            string transactionType = "Transaction",
            Models.FinancialTransactionStatus transactionStatus = null,
            List<Models.StatementDetail> statementDetails = null)
        {
            this.TransactionID = transactionID;
            this.Timestamp = timestamp;
            this.TransactionStatus = transactionStatus;
            this.Amount = amount;
            this.MovementType = movementType;
            this.StatementDetails = statementDetails;
            this.TransactionType = transactionType;
        }

        /// <summary>
        /// Transaction ID type which contains both the unique VPL transaction ID and the merchant supplied transaction ID.
        /// </summary>
        [JsonProperty("transactionID")]
        public Models.TransactionID TransactionID { get; set; }

        /// <summary>
        /// A timestamp of the transaction. A valid ISO 8601 timestamp, such as YYYY-MM-DDThh:mm:ss.sss±hh:mm.
        /// </summary>
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// Additional important status information for specific transaction types.| code  | description  | Meaning || ----  | -----------  | ------- || 100   | Pending Processing | This is the initial state when VPL receives your payment instruction. || 200   | In Process         | This means the payment is being processed by VPL's payment platform. || 300   | With Partner Bank  | VPL has sent the payment onto our partner bank and we are awaiting an ACK. || 400   | Payment Sent       | VPL has sent the payment to the partner bank and has received an ACK.|| 500   | Rejected Payout    | A payment can be rejected when uploading to the partner bank's system or by VPL's compliance team. || 600   | Returned Payout    | A returned payment is when VPL processes the payment, sends on to our partner bank to be settled in the destination ACH but the beneficiary bank returns the payment. This could be because the bank account is closed.|| 700   | Insufficient Merchant liquidity | If you (VPL's client) is holding insufficient liquidity funding with VPL, then payments will appear in this state. VPL will not reject or fail the payments and will wait for you to provide funding before they can be processed. || 800   | Pending Cancellation            | A payment can be in this state, if you call the cancel payment API. |
        /// </summary>
        [JsonProperty("transactionStatus", NullValueHandling = NullValueHandling.Ignore)]
        public Models.FinancialTransactionStatus TransactionStatus { get; set; }

        /// <summary>
        /// Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.
        /// </summary>
        [JsonProperty("amount")]
        public Models.MonetaryValue Amount { get; set; }

        /// <summary>
        /// Specifies whether a money movement is a debit or credit.
        /// </summary>
        [JsonProperty("movementType", ItemConverterType = typeof(StringEnumConverter))]
        public Models.MoneyMovementTypeEnum MovementType { get; set; }

        /// <summary>
        /// Set of key value pairs that provide additional details about a money movement.
        /// </summary>
        [JsonProperty("statementDetails", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.StatementDetail> StatementDetails { get; set; }

        /// <summary>
        /// Gets or sets TransactionType.
        /// </summary>
        [JsonProperty("transactionType", NullValueHandling = NullValueHandling.Ignore)]
        public string TransactionType { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FinancialTransaction : ({string.Join(", ", toStringOutput)})";
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

            return obj is FinancialTransaction other &&
                ((this.TransactionID == null && other.TransactionID == null) || (this.TransactionID?.Equals(other.TransactionID) == true)) &&
                ((this.Timestamp == null && other.Timestamp == null) || (this.Timestamp?.Equals(other.Timestamp) == true)) &&
                ((this.TransactionStatus == null && other.TransactionStatus == null) || (this.TransactionStatus?.Equals(other.TransactionStatus) == true)) &&
                ((this.Amount == null && other.Amount == null) || (this.Amount?.Equals(other.Amount) == true)) &&
                this.MovementType.Equals(other.MovementType) &&
                ((this.StatementDetails == null && other.StatementDetails == null) || (this.StatementDetails?.Equals(other.StatementDetails) == true)) &&
                ((this.TransactionType == null && other.TransactionType == null) || (this.TransactionType?.Equals(other.TransactionType) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TransactionID = {(this.TransactionID == null ? "null" : this.TransactionID.ToString())}");
            toStringOutput.Add($"this.Timestamp = {(this.Timestamp == null ? "null" : this.Timestamp == string.Empty ? "" : this.Timestamp)}");
            toStringOutput.Add($"this.TransactionStatus = {(this.TransactionStatus == null ? "null" : this.TransactionStatus.ToString())}");
            toStringOutput.Add($"this.Amount = {(this.Amount == null ? "null" : this.Amount.ToString())}");
            toStringOutput.Add($"this.MovementType = {this.MovementType}");
            toStringOutput.Add($"this.StatementDetails = {(this.StatementDetails == null ? "null" : $"[{string.Join(", ", this.StatementDetails)} ]")}");
            toStringOutput.Add($"this.TransactionType = {(this.TransactionType == null ? "null" : this.TransactionType == string.Empty ? "" : this.TransactionType)}");
        }
    }
}