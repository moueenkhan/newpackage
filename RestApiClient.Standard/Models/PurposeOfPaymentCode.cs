// <copyright file="PurposeOfPaymentCode.cs" company="APIMatic">
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
    /// PurposeOfPaymentCode.
    /// </summary>
    public class PurposeOfPaymentCode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PurposeOfPaymentCode"/> class.
        /// </summary>
        public PurposeOfPaymentCode()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PurposeOfPaymentCode"/> class.
        /// </summary>
        /// <param name="code">code.</param>
        /// <param name="description">description.</param>
        /// <param name="purposeOfPaymentUsageRestrictions">purposeOfPaymentUsageRestrictions.</param>
        public PurposeOfPaymentCode(
            string code,
            string description,
            Models.PurposeOfPaymentUsageRestrictions purposeOfPaymentUsageRestrictions)
        {
            this.Code = code;
            this.Description = description;
            this.PurposeOfPaymentUsageRestrictions = purposeOfPaymentUsageRestrictions;
        }

        /// <summary>
        /// VPL purpose of payment code.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Description of purpose of payment code.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Usage restrictions apply where a specified code is only acceptable for a given type of payer or beneficiary. This attribute indicates whether the code can be used for Individuals and/or Legal Entities, for both payer and beneficiary parties. Additional field specifications identify further data that is required, given the chosen Purpose of Payment.
        /// </summary>
        [JsonProperty("purposeOfPaymentUsageRestrictions")]
        public Models.PurposeOfPaymentUsageRestrictions PurposeOfPaymentUsageRestrictions { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PurposeOfPaymentCode : ({string.Join(", ", toStringOutput)})";
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

            return obj is PurposeOfPaymentCode other &&
                ((this.Code == null && other.Code == null) || (this.Code?.Equals(other.Code) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.PurposeOfPaymentUsageRestrictions == null && other.PurposeOfPaymentUsageRestrictions == null) || (this.PurposeOfPaymentUsageRestrictions?.Equals(other.PurposeOfPaymentUsageRestrictions) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Code = {(this.Code == null ? "null" : this.Code == string.Empty ? "" : this.Code)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.PurposeOfPaymentUsageRestrictions = {(this.PurposeOfPaymentUsageRestrictions == null ? "null" : this.PurposeOfPaymentUsageRestrictions.ToString())}");
        }
    }
}