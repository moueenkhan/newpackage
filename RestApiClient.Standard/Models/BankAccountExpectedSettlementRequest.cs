// <copyright file="BankAccountExpectedSettlementRequest.cs" company="APIMatic">
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
    /// BankAccountExpectedSettlementRequest.
    /// </summary>
    public class BankAccountExpectedSettlementRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountExpectedSettlementRequest"/> class.
        /// </summary>
        public BankAccountExpectedSettlementRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountExpectedSettlementRequest"/> class.
        /// </summary>
        /// <param name="beneficiaryIdentity">beneficiaryIdentity.</param>
        /// <param name="description">description.</param>
        /// <param name="countryCode">countryCode.</param>
        /// <param name="bankAccountDetails">bankAccountDetails.</param>
        /// <param name="anticipatedPayoutRequestTime">anticipatedPayoutRequestTime.</param>
        /// <param name="payerIdentity">payerIdentity.</param>
        /// <param name="currencyCode">currencyCode.</param>
        /// <param name="payoutRequestCurrency">payoutRequestCurrency.</param>
        /// <param name="serviceLevel">serviceLevel.</param>
        /// <param name="payerType">payerType.</param>
        /// <param name="payoutDetails">payoutDetails.</param>
        /// <param name="transactionHold">transactionHold.</param>
        public BankAccountExpectedSettlementRequest(
            Models.Identity beneficiaryIdentity,
            string description,
            string countryCode,
            List<Models.BankAccountDetails> bankAccountDetails,
            string anticipatedPayoutRequestTime,
            Models.Identity payerIdentity,
            string currencyCode = null,
            string payoutRequestCurrency = null,
            Models.ServiceLevelEnum? serviceLevel = null,
            Models.PayerTypeEnum? payerType = null,
            List<Models.PayoutDetails> payoutDetails = null,
            Models.TransactionHold transactionHold = null)
        {
            this.BeneficiaryIdentity = beneficiaryIdentity;
            this.Description = description;
            this.CountryCode = countryCode;
            this.CurrencyCode = currencyCode;
            this.BankAccountDetails = bankAccountDetails;
            this.PayoutRequestCurrency = payoutRequestCurrency;
            this.AnticipatedPayoutRequestTime = anticipatedPayoutRequestTime;
            this.PayerIdentity = payerIdentity;
            this.ServiceLevel = serviceLevel;
            this.PayerType = payerType;
            this.PayoutDetails = payoutDetails;
            this.TransactionHold = transactionHold;
        }

        /// <summary>
        /// Represents the identity of an individual or legal entity. You must specify one of either an individual identity or legal entity identity or unstructured identity.
        /// </summary>
        [JsonProperty("beneficiaryIdentity")]
        public Models.Identity BeneficiaryIdentity { get; set; }

        /// <summary>
        /// Type which defines a beneficiary bank account description. Each bank account must be given a description therefore this is a mandatory component.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The territory in which this bank account is domiciled is mandatory and must be supplied in the 'countryCode' field as a valid supported ISO 3166 2-character country code.
        /// </summary>
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// The currency held in this bank account may optionally be supplied in the 'currencyCode' field as a valid supported ISO 4217 3-character currency code. If not supplied it will assume the default currency of the 'countryCode' parameter.
        /// </summary>
        [JsonProperty("currencyCode", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// This is a group of sub-elements which collectively identify both the bank and the account within the bank.
        /// </summary>
        [JsonProperty("bankAccountDetails")]
        public List<Models.BankAccountDetails> BankAccountDetails { get; set; }

        /// <summary>
        /// Valid supported ISO 4217 3-character currency code of the payout request. Will default to the beneficiary bank currency if not supplied.
        /// </summary>
        [JsonProperty("payoutRequestCurrency", NullValueHandling = NullValueHandling.Ignore)]
        public string PayoutRequestCurrency { get; set; }

        /// <summary>
        /// A valid ISO 8601 timestamp(YYYY-MM-DDThh:mm:ss.sss±hh:mm). This represents the timestamp when the payout is anticipated to be requested. This cannot be a time in the past. Recommendation is to supply the dateTime in UTC timezone or +0000 offset. Non zero offset times will be converted to UTC by the service. In this case, the client should ensure the supplied time is that intended for the supplied timezone or offset, and be aware this dateTime will be converted to UTC prior to expected settlement date calculation.
        /// </summary>
        [JsonProperty("anticipatedPayoutRequestTime")]
        public string AnticipatedPayoutRequestTime { get; set; }

        /// <summary>
        /// Represents the identity of an individual or legal entity. You must specify one of either an individual identity or legal entity identity or unstructured identity.
        /// </summary>
        [JsonProperty("payerIdentity")]
        public Models.Identity PayerIdentity { get; set; }

        /// <summary>
        /// Supported service levels for a payout request (standard or express).
        /// </summary>
        [JsonProperty("serviceLevel", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.ServiceLevelEnum? ServiceLevel { get; set; }

        /// <summary>
        /// The type of Payer making the payment. This determines which identity details are used as the payer identity.
        /// </summary>
        [JsonProperty("payerType", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.PayerTypeEnum? PayerType { get; set; }

        /// <summary>
        /// PayoutDetails are used for key-value pairs of details supported by payouts. Refer to client guides for detailed list of valid keys.
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

            return $"BankAccountExpectedSettlementRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is BankAccountExpectedSettlementRequest other &&
                ((this.BeneficiaryIdentity == null && other.BeneficiaryIdentity == null) || (this.BeneficiaryIdentity?.Equals(other.BeneficiaryIdentity) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.CountryCode == null && other.CountryCode == null) || (this.CountryCode?.Equals(other.CountryCode) == true)) &&
                ((this.CurrencyCode == null && other.CurrencyCode == null) || (this.CurrencyCode?.Equals(other.CurrencyCode) == true)) &&
                ((this.BankAccountDetails == null && other.BankAccountDetails == null) || (this.BankAccountDetails?.Equals(other.BankAccountDetails) == true)) &&
                ((this.PayoutRequestCurrency == null && other.PayoutRequestCurrency == null) || (this.PayoutRequestCurrency?.Equals(other.PayoutRequestCurrency) == true)) &&
                ((this.AnticipatedPayoutRequestTime == null && other.AnticipatedPayoutRequestTime == null) || (this.AnticipatedPayoutRequestTime?.Equals(other.AnticipatedPayoutRequestTime) == true)) &&
                ((this.PayerIdentity == null && other.PayerIdentity == null) || (this.PayerIdentity?.Equals(other.PayerIdentity) == true)) &&
                ((this.ServiceLevel == null && other.ServiceLevel == null) || (this.ServiceLevel?.Equals(other.ServiceLevel) == true)) &&
                ((this.PayerType == null && other.PayerType == null) || (this.PayerType?.Equals(other.PayerType) == true)) &&
                ((this.PayoutDetails == null && other.PayoutDetails == null) || (this.PayoutDetails?.Equals(other.PayoutDetails) == true)) &&
                ((this.TransactionHold == null && other.TransactionHold == null) || (this.TransactionHold?.Equals(other.TransactionHold) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BeneficiaryIdentity = {(this.BeneficiaryIdentity == null ? "null" : this.BeneficiaryIdentity.ToString())}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.CountryCode = {(this.CountryCode == null ? "null" : this.CountryCode == string.Empty ? "" : this.CountryCode)}");
            toStringOutput.Add($"this.CurrencyCode = {(this.CurrencyCode == null ? "null" : this.CurrencyCode == string.Empty ? "" : this.CurrencyCode)}");
            toStringOutput.Add($"this.BankAccountDetails = {(this.BankAccountDetails == null ? "null" : $"[{string.Join(", ", this.BankAccountDetails)} ]")}");
            toStringOutput.Add($"this.PayoutRequestCurrency = {(this.PayoutRequestCurrency == null ? "null" : this.PayoutRequestCurrency == string.Empty ? "" : this.PayoutRequestCurrency)}");
            toStringOutput.Add($"this.AnticipatedPayoutRequestTime = {(this.AnticipatedPayoutRequestTime == null ? "null" : this.AnticipatedPayoutRequestTime == string.Empty ? "" : this.AnticipatedPayoutRequestTime)}");
            toStringOutput.Add($"this.PayerIdentity = {(this.PayerIdentity == null ? "null" : this.PayerIdentity.ToString())}");
            toStringOutput.Add($"this.ServiceLevel = {(this.ServiceLevel == null ? "null" : this.ServiceLevel.ToString())}");
            toStringOutput.Add($"this.PayerType = {(this.PayerType == null ? "null" : this.PayerType.ToString())}");
            toStringOutput.Add($"this.PayoutDetails = {(this.PayoutDetails == null ? "null" : $"[{string.Join(", ", this.PayoutDetails)} ]")}");
            toStringOutput.Add($"this.TransactionHold = {(this.TransactionHold == null ? "null" : this.TransactionHold.ToString())}");
        }
    }
}