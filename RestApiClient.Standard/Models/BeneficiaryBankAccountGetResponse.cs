// <copyright file="BeneficiaryBankAccountGetResponse.cs" company="APIMatic">
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
    /// BeneficiaryBankAccountGetResponse.
    /// </summary>
    public class BeneficiaryBankAccountGetResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryBankAccountGetResponse"/> class.
        /// </summary>
        public BeneficiaryBankAccountGetResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryBankAccountGetResponse"/> class.
        /// </summary>
        /// <param name="userID">userID.</param>
        /// <param name="benBankID">benBankID.</param>
        /// <param name="beneficiaryIdentity">beneficiaryIdentity.</param>
        /// <param name="description">description.</param>
        /// <param name="countryCode">countryCode.</param>
        /// <param name="currencyCode">currencyCode.</param>
        /// <param name="isActive">isActive.</param>
        /// <param name="bankAccountDetails">bankAccountDetails.</param>
        public BeneficiaryBankAccountGetResponse(
            Models.UserID userID,
            Models.BenBankID benBankID,
            Models.Identity beneficiaryIdentity,
            string description,
            string countryCode,
            string currencyCode,
            bool isActive,
            List<Models.BankAccountDetails> bankAccountDetails)
        {
            this.UserID = userID;
            this.BenBankID = benBankID;
            this.BeneficiaryIdentity = beneficiaryIdentity;
            this.Description = description;
            this.CountryCode = countryCode;
            this.CurrencyCode = currencyCode;
            this.IsActive = isActive;
            this.BankAccountDetails = bankAccountDetails;
        }

        /// <summary>
        /// This group consists of all possible user identifier types. The 'epUserID' field is the VPL generated unique identifier for a User and is the equivalent of a Virtual Account Number (VAN). The 'merchantUserID' is a merchant specified identifier for the User. The 'epUserID', 'merchantUserID' or both 'epUserID' and 'merchantUserID' can be supplied. A mapping will be performed to retrieve the merchant user ID from the supplied EP user ID and vice versa. If both the 'epUserID' and 'merchantUserID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated.
        /// </summary>
        [JsonProperty("userID")]
        public Models.UserID UserID { get; set; }

        /// <summary>
        /// This group consists of all possible beneficiary bank identifier types. The 'epBankID' field is a unique identifier for a beneficiary bank account. The 'merchantBankID' is an optional merchant specified identifier for the beneficiary bank account. The 'epBankID', 'merchantBankID' or both 'epBankID' and 'merchantBankID' can be supplied. A mapping will be performed to retrieve the merchant bank ID from the supplied EP bank ID and vice versa. If both the 'epBankID' and 'merchantBankID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated.
        /// </summary>
        [JsonProperty("benBankID")]
        public Models.BenBankID BenBankID { get; set; }

        /// <summary>
        /// Represents the identity of an individual or legal entity. You must specify one of either an individual identity or legal entity identity or unstructured identity.
        /// </summary>
        [JsonProperty("beneficiaryIdentity")]
        public Models.Identity BeneficiaryIdentity { get; set; }

        /// <summary>
        /// Type which defines a beneficiary bank account description. Each bank account must be given a description therefore this is a mandatory component of the BeneficiaryBankAccount.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Valid supported ISO 3166 2-character country code. It is the territory in which this bank account is domiciled.
        /// </summary>
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Valid supported ISO 4217 3-character currency code. The currency held in this bank account may optionally be supplied in this field.
        /// </summary>
        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Return true if the bank account is active
        /// </summary>
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        /// <summary>
        /// This is a group of sub-elements which collectively identify both the bank and the account within the bank
        /// </summary>
        [JsonProperty("bankAccountDetails")]
        public List<Models.BankAccountDetails> BankAccountDetails { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BeneficiaryBankAccountGetResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is BeneficiaryBankAccountGetResponse other &&
                ((this.UserID == null && other.UserID == null) || (this.UserID?.Equals(other.UserID) == true)) &&
                ((this.BenBankID == null && other.BenBankID == null) || (this.BenBankID?.Equals(other.BenBankID) == true)) &&
                ((this.BeneficiaryIdentity == null && other.BeneficiaryIdentity == null) || (this.BeneficiaryIdentity?.Equals(other.BeneficiaryIdentity) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.CountryCode == null && other.CountryCode == null) || (this.CountryCode?.Equals(other.CountryCode) == true)) &&
                ((this.CurrencyCode == null && other.CurrencyCode == null) || (this.CurrencyCode?.Equals(other.CurrencyCode) == true)) &&
                this.IsActive.Equals(other.IsActive) &&
                ((this.BankAccountDetails == null && other.BankAccountDetails == null) || (this.BankAccountDetails?.Equals(other.BankAccountDetails) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.UserID = {(this.UserID == null ? "null" : this.UserID.ToString())}");
            toStringOutput.Add($"this.BenBankID = {(this.BenBankID == null ? "null" : this.BenBankID.ToString())}");
            toStringOutput.Add($"this.BeneficiaryIdentity = {(this.BeneficiaryIdentity == null ? "null" : this.BeneficiaryIdentity.ToString())}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.CountryCode = {(this.CountryCode == null ? "null" : this.CountryCode == string.Empty ? "" : this.CountryCode)}");
            toStringOutput.Add($"this.CurrencyCode = {(this.CurrencyCode == null ? "null" : this.CurrencyCode == string.Empty ? "" : this.CurrencyCode)}");
            toStringOutput.Add($"this.IsActive = {this.IsActive}");
            toStringOutput.Add($"this.BankAccountDetails = {(this.BankAccountDetails == null ? "null" : $"[{string.Join(", ", this.BankAccountDetails)} ]")}");
        }
    }
}