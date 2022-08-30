// <copyright file="BeneficiaryBankAccountListResponse.cs" company="APIMatic">
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
    /// BeneficiaryBankAccountListResponse.
    /// </summary>
    public class BeneficiaryBankAccountListResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryBankAccountListResponse"/> class.
        /// </summary>
        public BeneficiaryBankAccountListResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryBankAccountListResponse"/> class.
        /// </summary>
        /// <param name="beneficiaryBankAccountSummary">beneficiaryBankAccountSummary.</param>
        /// <param name="userID">userID.</param>
        /// <param name="paginationResult">paginationResult.</param>
        public BeneficiaryBankAccountListResponse(
            List<Models.BeneficiaryBankAccountSummary> beneficiaryBankAccountSummary,
            Models.UserID userID,
            Models.PaginationResult paginationResult)
        {
            this.BeneficiaryBankAccountSummary = beneficiaryBankAccountSummary;
            this.UserID = userID;
            this.PaginationResult = paginationResult;
        }

        /// <summary>
        /// Bank account summary returned in the list beneficiary bank accounts service. The summary version of a bank account does not include the beneficiary identity details. It also masks or obfuscates sensitive data such as account numbers.
        /// </summary>
        [JsonProperty("beneficiaryBankAccountSummary")]
        public List<Models.BeneficiaryBankAccountSummary> BeneficiaryBankAccountSummary { get; set; }

        /// <summary>
        /// This group consists of all possible user identifier types. The 'epUserID' field is the VPL generated unique identifier for a User and is the equivalent of a Virtual Account Number (VAN). The 'merchantUserID' is a merchant specified identifier for the User. The 'epUserID', 'merchantUserID' or both 'epUserID' and 'merchantUserID' can be supplied. A mapping will be performed to retrieve the merchant user ID from the supplied EP user ID and vice versa. If both the 'epUserID' and 'merchantUserID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated.
        /// </summary>
        [JsonProperty("userID")]
        public Models.UserID UserID { get; set; }

        /// <summary>
        /// This returns a paged set of results rather than the full result set.
        /// </summary>
        [JsonProperty("paginationResult")]
        public Models.PaginationResult PaginationResult { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BeneficiaryBankAccountListResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is BeneficiaryBankAccountListResponse other &&
                ((this.BeneficiaryBankAccountSummary == null && other.BeneficiaryBankAccountSummary == null) || (this.BeneficiaryBankAccountSummary?.Equals(other.BeneficiaryBankAccountSummary) == true)) &&
                ((this.UserID == null && other.UserID == null) || (this.UserID?.Equals(other.UserID) == true)) &&
                ((this.PaginationResult == null && other.PaginationResult == null) || (this.PaginationResult?.Equals(other.PaginationResult) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BeneficiaryBankAccountSummary = {(this.BeneficiaryBankAccountSummary == null ? "null" : $"[{string.Join(", ", this.BeneficiaryBankAccountSummary)} ]")}");
            toStringOutput.Add($"this.UserID = {(this.UserID == null ? "null" : this.UserID.ToString())}");
            toStringOutput.Add($"this.PaginationResult = {(this.PaginationResult == null ? "null" : this.PaginationResult.ToString())}");
        }
    }
}