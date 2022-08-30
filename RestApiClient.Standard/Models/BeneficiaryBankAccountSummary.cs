// <copyright file="BeneficiaryBankAccountSummary.cs" company="APIMatic">
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
    /// BeneficiaryBankAccountSummary.
    /// </summary>
    public class BeneficiaryBankAccountSummary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryBankAccountSummary"/> class.
        /// </summary>
        public BeneficiaryBankAccountSummary()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryBankAccountSummary"/> class.
        /// </summary>
        /// <param name="benBankID">benBankID.</param>
        /// <param name="description">description.</param>
        /// <param name="countryCode">countryCode.</param>
        /// <param name="bankAccountDetails">bankAccountDetails.</param>
        /// <param name="status">status.</param>
        public BeneficiaryBankAccountSummary(
            Models.BenBankID benBankID = null,
            string description = null,
            string countryCode = null,
            List<Models.BankAccountDetails> bankAccountDetails = null,
            string status = null)
        {
            this.BenBankID = benBankID;
            this.Description = description;
            this.CountryCode = countryCode;
            this.BankAccountDetails = bankAccountDetails;
            this.Status = status;
        }

        /// <summary>
        /// This group consists of all possible beneficiary bank identifier types. The 'epBankID' field is a unique identifier for a beneficiary bank account. The 'merchantBankID' is an optional merchant specified identifier for the beneficiary bank account. The 'epBankID', 'merchantBankID' or both 'epBankID' and 'merchantBankID' can be supplied. A mapping will be performed to retrieve the merchant bank ID from the supplied EP bank ID and vice versa. If both the 'epBankID' and 'merchantBankID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated.
        /// </summary>
        [JsonProperty("benBankID", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BenBankID BenBankID { get; set; }

        /// <summary>
        /// Type which defines a beneficiary bank account description. Each bank account must be given a description therefore this is a mandatory component of the BeneficiaryBankAccount complex type.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// Valid supported ISO 3166 2-character country code.
        /// </summary>
        [JsonProperty("countryCode", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryCode { get; set; }

        /// <summary>
        /// The bank account details such as accountName, bankName, accountNumber etc...The list of bank account fields vary by country.
        /// </summary>
        [JsonProperty("bankAccountDetails", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.BankAccountDetails> BankAccountDetails { get; set; }

        /// <summary>
        /// Status of the bank account.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BeneficiaryBankAccountSummary : ({string.Join(", ", toStringOutput)})";
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

            return obj is BeneficiaryBankAccountSummary other &&
                ((this.BenBankID == null && other.BenBankID == null) || (this.BenBankID?.Equals(other.BenBankID) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.CountryCode == null && other.CountryCode == null) || (this.CountryCode?.Equals(other.CountryCode) == true)) &&
                ((this.BankAccountDetails == null && other.BankAccountDetails == null) || (this.BankAccountDetails?.Equals(other.BankAccountDetails) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BenBankID = {(this.BenBankID == null ? "null" : this.BenBankID.ToString())}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.CountryCode = {(this.CountryCode == null ? "null" : this.CountryCode == string.Empty ? "" : this.CountryCode)}");
            toStringOutput.Add($"this.BankAccountDetails = {(this.BankAccountDetails == null ? "null" : $"[{string.Join(", ", this.BankAccountDetails)} ]")}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status == string.Empty ? "" : this.Status)}");
        }
    }
}