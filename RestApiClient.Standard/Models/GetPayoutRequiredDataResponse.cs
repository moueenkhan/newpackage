// <copyright file="GetPayoutRequiredDataResponse.cs" company="APIMatic">
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
    /// GetPayoutRequiredDataResponse.
    /// </summary>
    public class GetPayoutRequiredDataResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetPayoutRequiredDataResponse"/> class.
        /// </summary>
        public GetPayoutRequiredDataResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPayoutRequiredDataResponse"/> class.
        /// </summary>
        /// <param name="purposeOfPaymentFieldGroupsList">purposeOfPaymentFieldGroupsList.</param>
        /// <param name="beneficiaryBankAccountFieldGroupsList">beneficiaryBankAccountFieldGroupsList.</param>
        /// <param name="beneficiaryIdentityFieldGroupsList">beneficiaryIdentityFieldGroupsList.</param>
        public GetPayoutRequiredDataResponse(
            Models.PurposeOfPaymentFieldGroupsList purposeOfPaymentFieldGroupsList,
            Models.BeneficiaryBankAccountGroupsList beneficiaryBankAccountFieldGroupsList = null,
            Models.BeneficiaryIdentityGroupsList beneficiaryIdentityFieldGroupsList = null)
        {
            this.BeneficiaryBankAccountFieldGroupsList = beneficiaryBankAccountFieldGroupsList;
            this.BeneficiaryIdentityFieldGroupsList = beneficiaryIdentityFieldGroupsList;
            this.PurposeOfPaymentFieldGroupsList = purposeOfPaymentFieldGroupsList;
        }

        /// <summary>
        /// This type defines a list of bank account data groups. Each group is normally represented as a row on the UI.
        /// </summary>
        [JsonProperty("beneficiaryBankAccountFieldGroupsList", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BeneficiaryBankAccountGroupsList BeneficiaryBankAccountFieldGroupsList { get; set; }

        /// <summary>
        /// This type defines a list of identity data groups. Each group is normally represented as a section of fields on the UI.
        /// </summary>
        [JsonProperty("beneficiaryIdentityFieldGroupsList", NullValueHandling = NullValueHandling.Ignore)]
        public Models.BeneficiaryIdentityGroupsList BeneficiaryIdentityFieldGroupsList { get; set; }

        /// <summary>
        /// This group contains all configuration information for Purpose of Payment options. The 'mandatory' attribute indicates whether provision of Purpose of Payment data is required for the Payout to be accepted.
        /// </summary>
        [JsonProperty("purposeOfPaymentFieldGroupsList")]
        public Models.PurposeOfPaymentFieldGroupsList PurposeOfPaymentFieldGroupsList { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"GetPayoutRequiredDataResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is GetPayoutRequiredDataResponse other &&
                ((this.BeneficiaryBankAccountFieldGroupsList == null && other.BeneficiaryBankAccountFieldGroupsList == null) || (this.BeneficiaryBankAccountFieldGroupsList?.Equals(other.BeneficiaryBankAccountFieldGroupsList) == true)) &&
                ((this.BeneficiaryIdentityFieldGroupsList == null && other.BeneficiaryIdentityFieldGroupsList == null) || (this.BeneficiaryIdentityFieldGroupsList?.Equals(other.BeneficiaryIdentityFieldGroupsList) == true)) &&
                ((this.PurposeOfPaymentFieldGroupsList == null && other.PurposeOfPaymentFieldGroupsList == null) || (this.PurposeOfPaymentFieldGroupsList?.Equals(other.PurposeOfPaymentFieldGroupsList) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BeneficiaryBankAccountFieldGroupsList = {(this.BeneficiaryBankAccountFieldGroupsList == null ? "null" : this.BeneficiaryBankAccountFieldGroupsList.ToString())}");
            toStringOutput.Add($"this.BeneficiaryIdentityFieldGroupsList = {(this.BeneficiaryIdentityFieldGroupsList == null ? "null" : this.BeneficiaryIdentityFieldGroupsList.ToString())}");
            toStringOutput.Add($"this.PurposeOfPaymentFieldGroupsList = {(this.PurposeOfPaymentFieldGroupsList == null ? "null" : this.PurposeOfPaymentFieldGroupsList.ToString())}");
        }
    }
}