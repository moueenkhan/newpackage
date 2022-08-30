// <copyright file="PayoutTransaction.cs" company="APIMatic">
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
    /// PayoutTransaction.
    /// </summary>
    public class PayoutTransaction : FinancialTransaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PayoutTransaction"/> class.
        /// </summary>
        public PayoutTransaction()
        {
            this.TransactionType = "Payout";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PayoutTransaction"/> class.
        /// </summary>
        /// <param name="transactionID">transactionID.</param>
        /// <param name="timestamp">timestamp.</param>
        /// <param name="amount">amount.</param>
        /// <param name="movementType">movementType.</param>
        /// <param name="usersBankID">usersBankID.</param>
        /// <param name="payoutRequestAmount">payoutRequestAmount.</param>
        /// <param name="settlementInstructionAmount">settlementInstructionAmount.</param>
        /// <param name="beneficiaryStatementNarrative">beneficiaryStatementNarrative.</param>
        /// <param name="expectedSettlementDate">expectedSettlementDate.</param>
        /// <param name="beneficiaryBankCountry">beneficiaryBankCountry.</param>
        /// <param name="beneficiaryBankCurrency">beneficiaryBankCurrency.</param>
        /// <param name="debitValueDate">debitValueDate.</param>
        /// <param name="payerIdentity">payerIdentity.</param>
        /// <param name="payerCreatedDate">payerCreatedDate.</param>
        /// <param name="transactionType">transactionType.</param>
        /// <param name="transactionStatus">transactionStatus.</param>
        /// <param name="statementDetails">statementDetails.</param>
        /// <param name="payoutDetails">payoutDetails.</param>
        /// <param name="fxExecutedDetail">fxExecutedDetail.</param>
        /// <param name="refundPayoutID">refundPayoutID.</param>
        /// <param name="dateSentToBank">dateSentToBank.</param>
        public PayoutTransaction(
            Models.TransactionID transactionID,
            string timestamp,
            Models.MonetaryValue amount,
            Models.MoneyMovementTypeEnum movementType,
            Models.UsersBankID usersBankID,
            Models.MonetaryValue payoutRequestAmount,
            Models.MonetaryValue settlementInstructionAmount,
            string beneficiaryStatementNarrative,
            string expectedSettlementDate,
            string beneficiaryBankCountry,
            string beneficiaryBankCurrency,
            string debitValueDate,
            Models.Identity payerIdentity,
            string payerCreatedDate,
            string transactionType = "Payout",
            Models.FinancialTransactionStatus transactionStatus = null,
            List<Models.StatementDetail> statementDetails = null,
            List<Models.PayoutDetails> payoutDetails = null,
            Models.FXExecutedRate fxExecutedDetail = null,
            Models.RefundPayoutID refundPayoutID = null,
            string dateSentToBank = null)
            : base(
                transactionID,
                timestamp,
                amount,
                movementType,
                transactionType,
                transactionStatus,
                statementDetails)
        {
            this.UsersBankID = usersBankID;
            this.PayoutRequestAmount = payoutRequestAmount;
            this.SettlementInstructionAmount = settlementInstructionAmount;
            this.BeneficiaryStatementNarrative = beneficiaryStatementNarrative;
            this.PayoutDetails = payoutDetails;
            this.ExpectedSettlementDate = expectedSettlementDate;
            this.BeneficiaryBankCountry = beneficiaryBankCountry;
            this.BeneficiaryBankCurrency = beneficiaryBankCurrency;
            this.DebitValueDate = debitValueDate;
            this.PayerIdentity = payerIdentity;
            this.PayerCreatedDate = payerCreatedDate;
            this.FxExecutedDetail = fxExecutedDetail;
            this.RefundPayoutID = refundPayoutID;
            this.DateSentToBank = dateSentToBank;
        }

        /// <summary>
        /// This group consists of a collection of both the user ID group and beneficiary bank ID group. The 'userID' is a collection of user identifier types. The 'benBankID' is a collection of account identifier types. Both the 'userID' and 'benBankID' fields are mandatory.
        /// </summary>
        [JsonProperty("usersBankID")]
        public Models.UsersBankID UsersBankID { get; set; }

        /// <summary>
        /// Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.
        /// </summary>
        [JsonProperty("payoutRequestAmount")]
        public Models.MonetaryValue PayoutRequestAmount { get; set; }

        /// <summary>
        /// Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.
        /// </summary>
        [JsonProperty("settlementInstructionAmount")]
        public Models.MonetaryValue SettlementInstructionAmount { get; set; }

        /// <summary>
        /// Narrative text to be displayed on the beneficiary bank accounts statement, where the banking network supports this.
        /// </summary>
        [JsonProperty("beneficiaryStatementNarrative")]
        public string BeneficiaryStatementNarrative { get; set; }

        /// <summary>
        /// Allows additional data to be supplied with a payout. Refer to documentation for valid keys.
        /// </summary>
        [JsonProperty("payoutDetails", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.PayoutDetails> PayoutDetails { get; set; }

        /// <summary>
        /// Indicative date when the payout instruction is expected to be settled to the bank. This is calculated taking into account such things as acceptedDate, the settlement agreement cut-off time and period, etc. It currently does not take into account individual countries' banking calendars.
        /// </summary>
        [JsonProperty("expectedSettlementDate")]
        public string ExpectedSettlementDate { get; set; }

        /// <summary>
        /// Country of the target beneficiary bank.
        /// </summary>
        [JsonProperty("beneficiaryBankCountry")]
        public string BeneficiaryBankCountry { get; set; }

        /// <summary>
        /// Currency of the target beneficiary bank account.
        /// </summary>
        [JsonProperty("beneficiaryBankCurrency")]
        public string BeneficiaryBankCurrency { get; set; }

        /// <summary>
        /// Timestamp when the payout instruction was accepted by the Earthport payment system.
        /// </summary>
        [JsonProperty("debitValueDate")]
        public string DebitValueDate { get; set; }

        /// <summary>
        /// Represents the identity of an individual or legal entity. You must specify one of either an individual identity or legal entity identity or unstructured identity.
        /// </summary>
        [JsonProperty("payerIdentity")]
        public Models.Identity PayerIdentity { get; set; }

        /// <summary>
        /// Date payer was created.
        /// </summary>
        [JsonProperty("payerCreatedDate")]
        public string PayerCreatedDate { get; set; }

        /// <summary>
        /// Holds details of an executed FX conversion that has occured as part of a financial transaction. The FX that occured was from the sellCurrency to the buyCurrency at a particular rate. The rate may have been requested via an FX Quote (fxTicketID). An FX conversion fee may have been applied to certain transaction types.
        /// </summary>
        [JsonProperty("fxExecutedDetail", NullValueHandling = NullValueHandling.Ignore)]
        public Models.FXExecutedRate FxExecutedDetail { get; set; }

        /// <summary>
        /// Used within Payout Transaction (Returned) only when the payout is refunded.
        /// </summary>
        [JsonProperty("refundPayoutID", NullValueHandling = NullValueHandling.Ignore)]
        public Models.RefundPayoutID RefundPayoutID { get; set; }

        /// <summary>
        /// Valid ISO 8601 date format YYYY-MM-DD. Date of when the payment was actually sent to the bank.
        /// </summary>
        [JsonProperty("dateSentToBank", NullValueHandling = NullValueHandling.Ignore)]
        public string DateSentToBank { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PayoutTransaction : ({string.Join(", ", toStringOutput)})";
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

            return obj is PayoutTransaction other &&
                ((this.UsersBankID == null && other.UsersBankID == null) || (this.UsersBankID?.Equals(other.UsersBankID) == true)) &&
                ((this.PayoutRequestAmount == null && other.PayoutRequestAmount == null) || (this.PayoutRequestAmount?.Equals(other.PayoutRequestAmount) == true)) &&
                ((this.SettlementInstructionAmount == null && other.SettlementInstructionAmount == null) || (this.SettlementInstructionAmount?.Equals(other.SettlementInstructionAmount) == true)) &&
                ((this.BeneficiaryStatementNarrative == null && other.BeneficiaryStatementNarrative == null) || (this.BeneficiaryStatementNarrative?.Equals(other.BeneficiaryStatementNarrative) == true)) &&
                ((this.PayoutDetails == null && other.PayoutDetails == null) || (this.PayoutDetails?.Equals(other.PayoutDetails) == true)) &&
                ((this.ExpectedSettlementDate == null && other.ExpectedSettlementDate == null) || (this.ExpectedSettlementDate?.Equals(other.ExpectedSettlementDate) == true)) &&
                ((this.BeneficiaryBankCountry == null && other.BeneficiaryBankCountry == null) || (this.BeneficiaryBankCountry?.Equals(other.BeneficiaryBankCountry) == true)) &&
                ((this.BeneficiaryBankCurrency == null && other.BeneficiaryBankCurrency == null) || (this.BeneficiaryBankCurrency?.Equals(other.BeneficiaryBankCurrency) == true)) &&
                ((this.DebitValueDate == null && other.DebitValueDate == null) || (this.DebitValueDate?.Equals(other.DebitValueDate) == true)) &&
                ((this.PayerIdentity == null && other.PayerIdentity == null) || (this.PayerIdentity?.Equals(other.PayerIdentity) == true)) &&
                ((this.PayerCreatedDate == null && other.PayerCreatedDate == null) || (this.PayerCreatedDate?.Equals(other.PayerCreatedDate) == true)) &&
                ((this.FxExecutedDetail == null && other.FxExecutedDetail == null) || (this.FxExecutedDetail?.Equals(other.FxExecutedDetail) == true)) &&
                ((this.RefundPayoutID == null && other.RefundPayoutID == null) || (this.RefundPayoutID?.Equals(other.RefundPayoutID) == true)) &&
                ((this.DateSentToBank == null && other.DateSentToBank == null) || (this.DateSentToBank?.Equals(other.DateSentToBank) == true)) &&
                base.Equals(obj);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.UsersBankID = {(this.UsersBankID == null ? "null" : this.UsersBankID.ToString())}");
            toStringOutput.Add($"this.PayoutRequestAmount = {(this.PayoutRequestAmount == null ? "null" : this.PayoutRequestAmount.ToString())}");
            toStringOutput.Add($"this.SettlementInstructionAmount = {(this.SettlementInstructionAmount == null ? "null" : this.SettlementInstructionAmount.ToString())}");
            toStringOutput.Add($"this.BeneficiaryStatementNarrative = {(this.BeneficiaryStatementNarrative == null ? "null" : this.BeneficiaryStatementNarrative == string.Empty ? "" : this.BeneficiaryStatementNarrative)}");
            toStringOutput.Add($"this.PayoutDetails = {(this.PayoutDetails == null ? "null" : $"[{string.Join(", ", this.PayoutDetails)} ]")}");
            toStringOutput.Add($"this.ExpectedSettlementDate = {(this.ExpectedSettlementDate == null ? "null" : this.ExpectedSettlementDate == string.Empty ? "" : this.ExpectedSettlementDate)}");
            toStringOutput.Add($"this.BeneficiaryBankCountry = {(this.BeneficiaryBankCountry == null ? "null" : this.BeneficiaryBankCountry == string.Empty ? "" : this.BeneficiaryBankCountry)}");
            toStringOutput.Add($"this.BeneficiaryBankCurrency = {(this.BeneficiaryBankCurrency == null ? "null" : this.BeneficiaryBankCurrency == string.Empty ? "" : this.BeneficiaryBankCurrency)}");
            toStringOutput.Add($"this.DebitValueDate = {(this.DebitValueDate == null ? "null" : this.DebitValueDate == string.Empty ? "" : this.DebitValueDate)}");
            toStringOutput.Add($"this.PayerIdentity = {(this.PayerIdentity == null ? "null" : this.PayerIdentity.ToString())}");
            toStringOutput.Add($"this.PayerCreatedDate = {(this.PayerCreatedDate == null ? "null" : this.PayerCreatedDate == string.Empty ? "" : this.PayerCreatedDate)}");
            toStringOutput.Add($"this.FxExecutedDetail = {(this.FxExecutedDetail == null ? "null" : this.FxExecutedDetail.ToString())}");
            toStringOutput.Add($"this.RefundPayoutID = {(this.RefundPayoutID == null ? "null" : this.RefundPayoutID.ToString())}");
            toStringOutput.Add($"this.DateSentToBank = {(this.DateSentToBank == null ? "null" : this.DateSentToBank == string.Empty ? "" : this.DateSentToBank)}");

            base.ToString(toStringOutput);
        }
    }
}