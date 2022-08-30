// <copyright file="Payment.cs" company="APIMatic">
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
    /// Payment.
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Payment"/> class.
        /// </summary>
        public Payment()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Payment"/> class.
        /// </summary>
        /// <param name="transactionID">transactionID.</param>
        /// <param name="payoutRequestAmount">payoutRequestAmount.</param>
        /// <param name="beneficiaryAmountInformation">beneficiaryAmountInformation.</param>
        /// <param name="serviceLevel">serviceLevel.</param>
        /// <param name="beneficiaryStatementNarrative">beneficiaryStatementNarrative.</param>
        /// <param name="fxTicketID">fxTicketID.</param>
        /// <param name="requestedFX">requestedFX.</param>
        /// <param name="payerType">payerType.</param>
        /// <param name="payoutType">payoutType.</param>
        /// <param name="payoutDetails">payoutDetails.</param>
        /// <param name="transactionHold">transactionHold.</param>
        public Payment(
            Models.TransactionIDMerchant transactionID,
            Models.MonetaryValue payoutRequestAmount = null,
            Models.BeneficiaryAmountInformation beneficiaryAmountInformation = null,
            Models.ServiceLevelEnum? serviceLevel = null,
            string beneficiaryStatementNarrative = null,
            int? fxTicketID = null,
            Models.RequestedFXEnum? requestedFX = null,
            Models.PayerTypeEnum? payerType = null,
            string payoutType = null,
            List<Models.PayoutDetails> payoutDetails = null,
            Models.TransactionHold transactionHold = null)
        {
            this.TransactionID = transactionID;
            this.PayoutRequestAmount = payoutRequestAmount;
            this.BeneficiaryAmountInformation = beneficiaryAmountInformation;
            this.ServiceLevel = serviceLevel;
            this.BeneficiaryStatementNarrative = beneficiaryStatementNarrative;
            this.FxTicketID = fxTicketID;
            this.RequestedFX = requestedFX;
            this.PayerType = payerType;
            this.PayoutType = payoutType;
            this.PayoutDetails = payoutDetails;
            this.TransactionHold = transactionHold;
        }

        /// <summary>
        /// This group consists of merchant transaction reference only.
        /// </summary>
        [JsonProperty("transactionID")]
        public Models.TransactionIDMerchant TransactionID { get; set; }

        /// <summary>
        /// Represents a monetary value containing a decimal amount value along with a currency code. The currency code is a three letter ISO 4217 code. E.g. GBP for British sterling pounds.
        /// </summary>
        [JsonProperty("payoutRequestAmount", NullValueHandling = NullValueHandling.Ignore)]
        public Models.MonetaryValue PayoutRequestAmount { get; set; }

        /// <summary>
        /// Used to specify the beneficiary amount and the payout currency.
        /// </summary>
        [JsonProperty("beneficiaryAmountInformation", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BeneficiaryAmountInformation BeneficiaryAmountInformation { get; set; }

        /// <summary>
        /// Supported service levels for a payout request (standard or express).
        /// </summary>
        [JsonProperty("serviceLevel", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.ServiceLevelEnum? ServiceLevel { get; set; }

        /// <summary>
        /// Narrative text to be displayed on the beneficiary bank accounts statement, where the banking network supports this.
        /// </summary>
        [JsonProperty("beneficiaryStatementNarrative", NullValueHandling = NullValueHandling.Ignore)]
        public string BeneficiaryStatementNarrative { get; set; }

        /// <summary>
        /// Optional FxTicket Id to be used. This is a unique reference sent back to the Merchant as a response to getFXQuote as UID. If specified, the system will honour the rate specified in the FX Ticket for the Payment. The VPL System will validate the specified FX Ticket including TTL on the Ticket. If the TTL has expired, the VPL system will throw an error.
        /// </summary>
        [JsonProperty("fxTicketID", NullValueHandling = NullValueHandling.Ignore)]
        public int? FxTicketID { get; set; }

        /// <summary>
        /// Method of FX that is requested by the merchant and for which EPS2 will attempt to use in order to settle the payout request.
        /// </summary>
        [JsonProperty("requestedFX", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.RequestedFXEnum? RequestedFX { get; set; }

        /// <summary>
        /// The type of Payer making the payment. This determines which identity details are used as the payer identity.
        /// </summary>
        [JsonProperty("payerType", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.PayerTypeEnum? PayerType { get; set; }

        /// <summary>
        /// Reserved for future use. Will be used to state the Payout type.
        /// </summary>
        [JsonProperty("payoutType", NullValueHandling = NullValueHandling.Ignore)]
        public string PayoutType { get; set; }

        /// <summary>
        /// Additional information related to the payment such as Purpose of Payment
        /// </summary>
        [JsonProperty("payoutDetails", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.PayoutDetails> PayoutDetails { get; set; }

        /// <summary>
        /// Parameter to prevent transactions from being processed until the desired time has been reached. Note releaseDateTime must be in UTC format.
        /// </summary>
        [JsonProperty("transactionHold", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TransactionHold TransactionHold { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Payment : ({string.Join(", ", toStringOutput)})";
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

            return obj is Payment other &&
                ((this.TransactionID == null && other.TransactionID == null) || (this.TransactionID?.Equals(other.TransactionID) == true)) &&
                ((this.PayoutRequestAmount == null && other.PayoutRequestAmount == null) || (this.PayoutRequestAmount?.Equals(other.PayoutRequestAmount) == true)) &&
                ((this.BeneficiaryAmountInformation == null && other.BeneficiaryAmountInformation == null) || (this.BeneficiaryAmountInformation?.Equals(other.BeneficiaryAmountInformation) == true)) &&
                ((this.ServiceLevel == null && other.ServiceLevel == null) || (this.ServiceLevel?.Equals(other.ServiceLevel) == true)) &&
                ((this.BeneficiaryStatementNarrative == null && other.BeneficiaryStatementNarrative == null) || (this.BeneficiaryStatementNarrative?.Equals(other.BeneficiaryStatementNarrative) == true)) &&
                ((this.FxTicketID == null && other.FxTicketID == null) || (this.FxTicketID?.Equals(other.FxTicketID) == true)) &&
                ((this.RequestedFX == null && other.RequestedFX == null) || (this.RequestedFX?.Equals(other.RequestedFX) == true)) &&
                ((this.PayerType == null && other.PayerType == null) || (this.PayerType?.Equals(other.PayerType) == true)) &&
                ((this.PayoutType == null && other.PayoutType == null) || (this.PayoutType?.Equals(other.PayoutType) == true)) &&
                ((this.PayoutDetails == null && other.PayoutDetails == null) || (this.PayoutDetails?.Equals(other.PayoutDetails) == true)) &&
                ((this.TransactionHold == null && other.TransactionHold == null) || (this.TransactionHold?.Equals(other.TransactionHold) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TransactionID = {(this.TransactionID == null ? "null" : this.TransactionID.ToString())}");
            toStringOutput.Add($"this.PayoutRequestAmount = {(this.PayoutRequestAmount == null ? "null" : this.PayoutRequestAmount.ToString())}");
            toStringOutput.Add($"this.BeneficiaryAmountInformation = {(this.BeneficiaryAmountInformation == null ? "null" : this.BeneficiaryAmountInformation.ToString())}");
            toStringOutput.Add($"this.ServiceLevel = {(this.ServiceLevel == null ? "null" : this.ServiceLevel.ToString())}");
            toStringOutput.Add($"this.BeneficiaryStatementNarrative = {(this.BeneficiaryStatementNarrative == null ? "null" : this.BeneficiaryStatementNarrative == string.Empty ? "" : this.BeneficiaryStatementNarrative)}");
            toStringOutput.Add($"this.FxTicketID = {(this.FxTicketID == null ? "null" : this.FxTicketID.ToString())}");
            toStringOutput.Add($"this.RequestedFX = {(this.RequestedFX == null ? "null" : this.RequestedFX.ToString())}");
            toStringOutput.Add($"this.PayerType = {(this.PayerType == null ? "null" : this.PayerType.ToString())}");
            toStringOutput.Add($"this.PayoutType = {(this.PayoutType == null ? "null" : this.PayoutType == string.Empty ? "" : this.PayoutType)}");
            toStringOutput.Add($"this.PayoutDetails = {(this.PayoutDetails == null ? "null" : $"[{string.Join(", ", this.PayoutDetails)} ]")}");
            toStringOutput.Add($"this.TransactionHold = {(this.TransactionHold == null ? "null" : this.TransactionHold.ToString())}");
        }
    }
}