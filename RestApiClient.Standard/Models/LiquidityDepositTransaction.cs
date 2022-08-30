// <copyright file="LiquidityDepositTransaction.cs" company="APIMatic">
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
    /// LiquidityDepositTransaction.
    /// </summary>
    public class LiquidityDepositTransaction : FinancialTransaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LiquidityDepositTransaction"/> class.
        /// </summary>
        public LiquidityDepositTransaction()
        {
            this.TransactionType = "Merchant Liquidity Deposit";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LiquidityDepositTransaction"/> class.
        /// </summary>
        /// <param name="transactionID">transactionID.</param>
        /// <param name="timestamp">timestamp.</param>
        /// <param name="amount">amount.</param>
        /// <param name="movementType">movementType.</param>
        /// <param name="amountCreditedToMerchantAccount">amountCreditedToMerchantAccount.</param>
        /// <param name="amountReceivedAtBank">amountReceivedAtBank.</param>
        /// <param name="depositCountry">depositCountry.</param>
        /// <param name="depositDate">depositDate.</param>
        /// <param name="transactionType">transactionType.</param>
        /// <param name="transactionStatus">transactionStatus.</param>
        /// <param name="statementDetails">statementDetails.</param>
        /// <param name="depositReference">depositReference.</param>
        /// <param name="fxExecutedDetail">fxExecutedDetail.</param>
        /// <param name="unappliedReason">unappliedReason.</param>
        public LiquidityDepositTransaction(
            Models.TransactionID transactionID,
            string timestamp,
            Models.MonetaryValue amount,
            Models.MoneyMovementTypeEnum movementType,
            Models.MonetaryValue amountCreditedToMerchantAccount,
            Models.MonetaryValue amountReceivedAtBank,
            string depositCountry,
            string depositDate,
            string transactionType = "Merchant Liquidity Deposit",
            Models.FinancialTransactionStatus transactionStatus = null,
            List<Models.StatementDetail> statementDetails = null,
            string depositReference = null,
            Models.FXExecutedRate fxExecutedDetail = null,
            string unappliedReason = null)
            : base(
                transactionID,
                timestamp,
                amount,
                movementType,
                transactionType,
                transactionStatus,
                statementDetails)
        {
            this.AmountCreditedToMerchantAccount = amountCreditedToMerchantAccount;
            this.AmountReceivedAtBank = amountReceivedAtBank;
            this.DepositCountry = depositCountry;
            this.DepositDate = depositDate;
            this.DepositReference = depositReference;
            this.FxExecutedDetail = fxExecutedDetail;
            this.UnappliedReason = unappliedReason;
        }

        /// <summary>
        /// Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.
        /// </summary>
        [JsonProperty("amountCreditedToMerchantAccount")]
        public Models.MonetaryValue AmountCreditedToMerchantAccount { get; set; }

        /// <summary>
        /// Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.
        /// </summary>
        [JsonProperty("amountReceivedAtBank")]
        public Models.MonetaryValue AmountReceivedAtBank { get; set; }

        /// <summary>
        /// Valid supported ISO 3166 2-character country code. This represents the Country of liquidity deposit.
        /// </summary>
        [JsonProperty("depositCountry")]
        public string DepositCountry { get; set; }

        /// <summary>
        /// Valid ISO 8601 date format YYYY-MM-DD. This represents the date of liquidity deposit.
        /// </summary>
        [JsonProperty("depositDate")]
        public string DepositDate { get; set; }

        /// <summary>
        /// A Merchant User Deposit Reference.
        /// </summary>
        [JsonProperty("depositReference", NullValueHandling = NullValueHandling.Ignore)]
        public string DepositReference { get; set; }

        /// <summary>
        /// Holds details of an executed FX conversion that has occured as part of a financial transaction. The FX that occured was from the sellCurrency to the buyCurrency at a particular rate. The rate may have been requested via an FX Quote (fxTicketID). An FX conversion fee may have been applied to certain transaction types.
        /// </summary>
        [JsonProperty("fxExecutedDetail", NullValueHandling = NullValueHandling.Ignore)]
        public Models.FXExecutedRate FxExecutedDetail { get; set; }

        /// <summary>
        /// The reason the deposit was not applied to the merchant's virtual account.
        /// </summary>
        [JsonProperty("unappliedReason", NullValueHandling = NullValueHandling.Ignore)]
        public string UnappliedReason { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LiquidityDepositTransaction : ({string.Join(", ", toStringOutput)})";
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

            return obj is LiquidityDepositTransaction other &&
                ((this.AmountCreditedToMerchantAccount == null && other.AmountCreditedToMerchantAccount == null) || (this.AmountCreditedToMerchantAccount?.Equals(other.AmountCreditedToMerchantAccount) == true)) &&
                ((this.AmountReceivedAtBank == null && other.AmountReceivedAtBank == null) || (this.AmountReceivedAtBank?.Equals(other.AmountReceivedAtBank) == true)) &&
                ((this.DepositCountry == null && other.DepositCountry == null) || (this.DepositCountry?.Equals(other.DepositCountry) == true)) &&
                ((this.DepositDate == null && other.DepositDate == null) || (this.DepositDate?.Equals(other.DepositDate) == true)) &&
                ((this.DepositReference == null && other.DepositReference == null) || (this.DepositReference?.Equals(other.DepositReference) == true)) &&
                ((this.FxExecutedDetail == null && other.FxExecutedDetail == null) || (this.FxExecutedDetail?.Equals(other.FxExecutedDetail) == true)) &&
                ((this.UnappliedReason == null && other.UnappliedReason == null) || (this.UnappliedReason?.Equals(other.UnappliedReason) == true)) &&
                base.Equals(obj);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AmountCreditedToMerchantAccount = {(this.AmountCreditedToMerchantAccount == null ? "null" : this.AmountCreditedToMerchantAccount.ToString())}");
            toStringOutput.Add($"this.AmountReceivedAtBank = {(this.AmountReceivedAtBank == null ? "null" : this.AmountReceivedAtBank.ToString())}");
            toStringOutput.Add($"this.DepositCountry = {(this.DepositCountry == null ? "null" : this.DepositCountry == string.Empty ? "" : this.DepositCountry)}");
            toStringOutput.Add($"this.DepositDate = {(this.DepositDate == null ? "null" : this.DepositDate == string.Empty ? "" : this.DepositDate)}");
            toStringOutput.Add($"this.DepositReference = {(this.DepositReference == null ? "null" : this.DepositReference == string.Empty ? "" : this.DepositReference)}");
            toStringOutput.Add($"this.FxExecutedDetail = {(this.FxExecutedDetail == null ? "null" : this.FxExecutedDetail.ToString())}");
            toStringOutput.Add($"this.UnappliedReason = {(this.UnappliedReason == null ? "null" : this.UnappliedReason == string.Empty ? "" : this.UnappliedReason)}");

            base.ToString(toStringOutput);
        }
    }
}