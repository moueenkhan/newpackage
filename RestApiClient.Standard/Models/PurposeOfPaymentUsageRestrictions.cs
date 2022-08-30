// <copyright file="PurposeOfPaymentUsageRestrictions.cs" company="APIMatic">
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
    /// PurposeOfPaymentUsageRestrictions.
    /// </summary>
    public class PurposeOfPaymentUsageRestrictions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PurposeOfPaymentUsageRestrictions"/> class.
        /// </summary>
        public PurposeOfPaymentUsageRestrictions()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PurposeOfPaymentUsageRestrictions"/> class.
        /// </summary>
        /// <param name="beneficiaryType">beneficiaryType.</param>
        /// <param name="originatorType">originatorType.</param>
        /// <param name="additionalFieldsList">additionalFieldsList.</param>
        public PurposeOfPaymentUsageRestrictions(
            Models.IdentityRestriction beneficiaryType,
            Models.IdentityRestriction originatorType,
            Models.AdditionalFieldsList additionalFieldsList = null)
        {
            this.AdditionalFieldsList = additionalFieldsList;
            this.BeneficiaryType = beneficiaryType;
            this.OriginatorType = originatorType;
        }

        /// <summary>
        /// This optionally contains a list of additional data that may be required if the associated purpose of payment is selected. This section will list a selection of 'additionalFieldWithValues' and/or 'additionalFieldWithValidator':   'additionalFieldWithValues' indicates the additional key that can be provided in the payoutDetails section of a payout request along with an indication of whether this additional payout details entry is mandatory. 'additionalFieldWithValues' will also be followed by a series of 'fieldValues' that list the valid codes and descriptions that can be submitted as the value of the payoutDetail entry in the payout request. 'additionalFieldWithValidator' indicates an additional key that can be provided in the payoutDetails section of a payout request, along with an indication of whether this additional payout details is mandatory 'additionalFieldWithValidator' also includes the validation expression that will be applied to the value. This is a regular expression, and may be blank if no validation will be applied.
        /// </summary>
        [JsonProperty("additionalFieldsList", NullValueHandling = NullValueHandling.Ignore)]
        public Models.AdditionalFieldsList AdditionalFieldsList { get; set; }

        /// <summary>
        /// Indicates whether a purpose of payment code is valid if the beneficiary is an individual or legal entity.
        /// </summary>
        [JsonProperty("beneficiaryType")]
        public Models.IdentityRestriction BeneficiaryType { get; set; }

        /// <summary>
        /// Indicates whether a purpose of payment code is valid if the beneficiary is an individual or legal entity.
        /// </summary>
        [JsonProperty("originatorType")]
        public Models.IdentityRestriction OriginatorType { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PurposeOfPaymentUsageRestrictions : ({string.Join(", ", toStringOutput)})";
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

            return obj is PurposeOfPaymentUsageRestrictions other &&
                ((this.AdditionalFieldsList == null && other.AdditionalFieldsList == null) || (this.AdditionalFieldsList?.Equals(other.AdditionalFieldsList) == true)) &&
                ((this.BeneficiaryType == null && other.BeneficiaryType == null) || (this.BeneficiaryType?.Equals(other.BeneficiaryType) == true)) &&
                ((this.OriginatorType == null && other.OriginatorType == null) || (this.OriginatorType?.Equals(other.OriginatorType) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AdditionalFieldsList = {(this.AdditionalFieldsList == null ? "null" : this.AdditionalFieldsList.ToString())}");
            toStringOutput.Add($"this.BeneficiaryType = {(this.BeneficiaryType == null ? "null" : this.BeneficiaryType.ToString())}");
            toStringOutput.Add($"this.OriginatorType = {(this.OriginatorType == null ? "null" : this.OriginatorType.ToString())}");
        }
    }
}