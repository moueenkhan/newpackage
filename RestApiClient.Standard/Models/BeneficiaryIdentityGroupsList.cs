// <copyright file="BeneficiaryIdentityGroupsList.cs" company="APIMatic">
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
    /// BeneficiaryIdentityGroupsList.
    /// </summary>
    public class BeneficiaryIdentityGroupsList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryIdentityGroupsList"/> class.
        /// </summary>
        public BeneficiaryIdentityGroupsList()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryIdentityGroupsList"/> class.
        /// </summary>
        /// <param name="groupLabel">groupLabel.</param>
        /// <param name="beneficiaryIdentityFieldGroup">beneficiaryIdentityFieldGroup.</param>
        /// <param name="beneficiaryIdentityFieldGroupChoice">beneficiaryIdentityFieldGroupChoice.</param>
        public BeneficiaryIdentityGroupsList(
            string groupLabel,
            List<Models.BeneficiaryIdentityGroup> beneficiaryIdentityFieldGroup = null,
            List<Models.BeneficiaryIdentityFieldGroupChoice> beneficiaryIdentityFieldGroupChoice = null)
        {
            this.GroupLabel = groupLabel;
            this.BeneficiaryIdentityFieldGroup = beneficiaryIdentityFieldGroup;
            this.BeneficiaryIdentityFieldGroupChoice = beneficiaryIdentityFieldGroupChoice;
        }

        /// <summary>
        /// Label for the beneficiary identity fields.
        /// </summary>
        [JsonProperty("groupLabel")]
        public string GroupLabel { get; set; }

        /// <summary>
        /// List of field groupings to define the beneficiary identity.
        /// </summary>
        [JsonProperty("beneficiaryIdentityFieldGroup", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.BeneficiaryIdentityGroup> BeneficiaryIdentityFieldGroup { get; set; }

        /// <summary>
        /// Conditional sets of field groupings to define the beneficiary identity. i.e. this could present a list of beneficiary identity fields for an individual and also the list of beneficiary identity fields for a legal entity.
        /// </summary>
        [JsonProperty("beneficiaryIdentityFieldGroupChoice", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.BeneficiaryIdentityFieldGroupChoice> BeneficiaryIdentityFieldGroupChoice { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BeneficiaryIdentityGroupsList : ({string.Join(", ", toStringOutput)})";
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

            return obj is BeneficiaryIdentityGroupsList other &&
                ((this.GroupLabel == null && other.GroupLabel == null) || (this.GroupLabel?.Equals(other.GroupLabel) == true)) &&
                ((this.BeneficiaryIdentityFieldGroup == null && other.BeneficiaryIdentityFieldGroup == null) || (this.BeneficiaryIdentityFieldGroup?.Equals(other.BeneficiaryIdentityFieldGroup) == true)) &&
                ((this.BeneficiaryIdentityFieldGroupChoice == null && other.BeneficiaryIdentityFieldGroupChoice == null) || (this.BeneficiaryIdentityFieldGroupChoice?.Equals(other.BeneficiaryIdentityFieldGroupChoice) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.GroupLabel = {(this.GroupLabel == null ? "null" : this.GroupLabel == string.Empty ? "" : this.GroupLabel)}");
            toStringOutput.Add($"this.BeneficiaryIdentityFieldGroup = {(this.BeneficiaryIdentityFieldGroup == null ? "null" : $"[{string.Join(", ", this.BeneficiaryIdentityFieldGroup)} ]")}");
            toStringOutput.Add($"this.BeneficiaryIdentityFieldGroupChoice = {(this.BeneficiaryIdentityFieldGroupChoice == null ? "null" : $"[{string.Join(", ", this.BeneficiaryIdentityFieldGroupChoice)} ]")}");
        }
    }
}