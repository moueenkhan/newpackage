// <copyright file="BeneficiaryBankAccountValidateRequest.cs" company="APIMatic">
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
    /// BeneficiaryBankAccountValidateRequest.
    /// </summary>
    public class BeneficiaryBankAccountValidateRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryBankAccountValidateRequest"/> class.
        /// </summary>
        public BeneficiaryBankAccountValidateRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryBankAccountValidateRequest"/> class.
        /// </summary>
        /// <param name="beneficiaryIdentity">beneficiaryIdentity.</param>
        /// <param name="description">description.</param>
        /// <param name="countryCode">countryCode.</param>
        /// <param name="bankAccountDetails">bankAccountDetails.</param>
        /// <param name="currencyCode">currencyCode.</param>
        public BeneficiaryBankAccountValidateRequest(
            Models.Identity beneficiaryIdentity,
            string description,
            string countryCode,
            List<Models.BankAccountDetails> bankAccountDetails,
            string currencyCode = null)
        {
            this.BeneficiaryIdentity = beneficiaryIdentity;
            this.Description = description;
            this.CountryCode = countryCode;
            this.CurrencyCode = currencyCode;
            this.BankAccountDetails = bankAccountDetails;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BeneficiaryBankAccountValidateRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is BeneficiaryBankAccountValidateRequest other &&
                ((this.BeneficiaryIdentity == null && other.BeneficiaryIdentity == null) || (this.BeneficiaryIdentity?.Equals(other.BeneficiaryIdentity) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.CountryCode == null && other.CountryCode == null) || (this.CountryCode?.Equals(other.CountryCode) == true)) &&
                ((this.CurrencyCode == null && other.CurrencyCode == null) || (this.CurrencyCode?.Equals(other.CurrencyCode) == true)) &&
                ((this.BankAccountDetails == null && other.BankAccountDetails == null) || (this.BankAccountDetails?.Equals(other.BankAccountDetails) == true));
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
        }
    }
}