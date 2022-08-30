// <copyright file="UserDepositTransaction.cs" company="APIMatic">
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
    /// UserDepositTransaction.
    /// </summary>
    public class UserDepositTransaction : FinancialTransaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserDepositTransaction"/> class.
        /// </summary>
        public UserDepositTransaction()
        {
            this.TransactionType = "User Deposit";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDepositTransaction"/> class.
        /// </summary>
        /// <param name="transactionID">transactionID.</param>
        /// <param name="timestamp">timestamp.</param>
        /// <param name="amount">amount.</param>
        /// <param name="movementType">movementType.</param>
        /// <param name="userID">userID.</param>
        /// <param name="depositDate">depositDate.</param>
        /// <param name="depositCountry">depositCountry.</param>
        /// <param name="amountDepositedByUser">amountDepositedByUser.</param>
        /// <param name="amountDepositedToMerchant">amountDepositedToMerchant.</param>
        /// <param name="transactionType">transactionType.</param>
        /// <param name="transactionStatus">transactionStatus.</param>
        /// <param name="statementDetails">statementDetails.</param>
        /// <param name="depositReference">depositReference.</param>
        /// <param name="fxExecutedDetail">fxExecutedDetail.</param>
        /// <param name="unappliedReason">unappliedReason.</param>
        public UserDepositTransaction(
            Models.TransactionID transactionID,
            string timestamp,
            Models.MonetaryValue amount,
            Models.MoneyMovementTypeEnum movementType,
            Models.UserID userID,
            string depositDate,
            string depositCountry,
            Models.MonetaryValue amountDepositedByUser,
            Models.MonetaryValue amountDepositedToMerchant,
            string transactionType = "User Deposit",
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
            this.UserID = userID;
            this.DepositDate = depositDate;
            this.DepositReference = depositReference;
            this.DepositCountry = depositCountry;
            this.AmountDepositedByUser = amountDepositedByUser;
            this.AmountDepositedToMerchant = amountDepositedToMerchant;
            this.FxExecutedDetail = fxExecutedDetail;
            this.UnappliedReason = unappliedReason;
        }

        /// <summary>
        /// This group consists of all possible user identifier types. The 'epUserID' field is the VPL generated unique identifier for a User and is the equivalent of a Virtual Account Number (VAN). The 'merchantUserID' is a merchant specified identifier for the User. The 'epUserID', 'merchantUserID' or both 'epUserID' and 'merchantUserID' can be supplied. A mapping will be performed to retrieve the merchant user ID from the supplied EP user ID and vice versa. If both the 'epUserID' and 'merchantUserID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated.
        /// </summary>
        [JsonProperty("userID")]
        public Models.UserID UserID { get; set; }

        /// <summary>
        /// Valid ISO 8601 date format YYYY-MM-DD.
        /// </summary>
        [JsonProperty("depositDate")]
        public string DepositDate { get; set; }

        /// <summary>
        /// A Merchant User Deposit Reference.
        /// </summary>
        [JsonProperty("depositReference", NullValueHandling = NullValueHandling.Ignore)]
        public string DepositReference { get; set; }

        /// <summary>
        /// Valid supported ISO 3166 2-character country code.
        /// </summary>
        [JsonProperty("depositCountry")]
        public string DepositCountry { get; set; }

        /// <summary>
        /// Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.
        /// </summary>
        [JsonProperty("amountDepositedByUser")]
        public Models.MonetaryValue AmountDepositedByUser { get; set; }

        /// <summary>
        /// Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.
        /// </summary>
        [JsonProperty("amountDepositedToMerchant")]
        public Models.MonetaryValue AmountDepositedToMerchant { get; set; }

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

            return $"UserDepositTransaction : ({string.Join(", ", toStringOutput)})";
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

            return obj is UserDepositTransaction other &&
                ((this.UserID == null && other.UserID == null) || (this.UserID?.Equals(other.UserID) == true)) &&
                ((this.DepositDate == null && other.DepositDate == null) || (this.DepositDate?.Equals(other.DepositDate) == true)) &&
                ((this.DepositReference == null && other.DepositReference == null) || (this.DepositReference?.Equals(other.DepositReference) == true)) &&
                ((this.DepositCountry == null && other.DepositCountry == null) || (this.DepositCountry?.Equals(other.DepositCountry) == true)) &&
                ((this.AmountDepositedByUser == null && other.AmountDepositedByUser == null) || (this.AmountDepositedByUser?.Equals(other.AmountDepositedByUser) == true)) &&
                ((this.AmountDepositedToMerchant == null && other.AmountDepositedToMerchant == null) || (this.AmountDepositedToMerchant?.Equals(other.AmountDepositedToMerchant) == true)) &&
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
            toStringOutput.Add($"this.UserID = {(this.UserID == null ? "null" : this.UserID.ToString())}");
            toStringOutput.Add($"this.DepositDate = {(this.DepositDate == null ? "null" : this.DepositDate == string.Empty ? "" : this.DepositDate)}");
            toStringOutput.Add($"this.DepositReference = {(this.DepositReference == null ? "null" : this.DepositReference == string.Empty ? "" : this.DepositReference)}");
            toStringOutput.Add($"this.DepositCountry = {(this.DepositCountry == null ? "null" : this.DepositCountry == string.Empty ? "" : this.DepositCountry)}");
            toStringOutput.Add($"this.AmountDepositedByUser = {(this.AmountDepositedByUser == null ? "null" : this.AmountDepositedByUser.ToString())}");
            toStringOutput.Add($"this.AmountDepositedToMerchant = {(this.AmountDepositedToMerchant == null ? "null" : this.AmountDepositedToMerchant.ToString())}");
            toStringOutput.Add($"this.FxExecutedDetail = {(this.FxExecutedDetail == null ? "null" : this.FxExecutedDetail.ToString())}");
            toStringOutput.Add($"this.UnappliedReason = {(this.UnappliedReason == null ? "null" : this.UnappliedReason == string.Empty ? "" : this.UnappliedReason)}");

            base.ToString(toStringOutput);
        }
    }
}