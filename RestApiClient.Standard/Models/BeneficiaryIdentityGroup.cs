// <copyright file="BeneficiaryIdentityGroup.cs" company="APIMatic">
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
    /// BeneficiaryIdentityGroup.
    /// </summary>
    public class BeneficiaryIdentityGroup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryIdentityGroup"/> class.
        /// </summary>
        public BeneficiaryIdentityGroup()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryIdentityGroup"/> class.
        /// </summary>
        /// <param name="elementName">elementName.</param>
        /// <param name="groupLabel">groupLabel.</param>
        /// <param name="mandatory">mandatory.</param>
        /// <param name="beneficiaryIdentityFieldsList">beneficiaryIdentityFieldsList.</param>
        public BeneficiaryIdentityGroup(
            string elementName,
            string groupLabel,
            bool mandatory,
            Models.BeneficiaryIdentityFieldsList beneficiaryIdentityFieldsList)
        {
            this.ElementName = elementName;
            this.GroupLabel = groupLabel;
            this.Mandatory = mandatory;
            this.BeneficiaryIdentityFieldsList = beneficiaryIdentityFieldsList;
        }

        /// <summary>
        /// The name of the VPL element/enum in the addBeneficiaryBankAccount.
        /// </summary>
        [JsonProperty("elementName")]
        public string ElementName { get; set; }

        /// <summary>
        /// Displays a label for this group of identity fields.
        /// </summary>
        [JsonProperty("groupLabel")]
        public string GroupLabel { get; set; }

        /// <summary>
        /// Indicates that all the fields within the group are mandatory.
        /// </summary>
        [JsonProperty("mandatory")]
        public bool Mandatory { get; set; }

        /// <summary>
        /// This type defines a list of beneficiary identity fields.
        /// </summary>
        [JsonProperty("beneficiaryIdentityFieldsList")]
        public Models.BeneficiaryIdentityFieldsList BeneficiaryIdentityFieldsList { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BeneficiaryIdentityGroup : ({string.Join(", ", toStringOutput)})";
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

            return obj is BeneficiaryIdentityGroup other &&
                ((this.ElementName == null && other.ElementName == null) || (this.ElementName?.Equals(other.ElementName) == true)) &&
                ((this.GroupLabel == null && other.GroupLabel == null) || (this.GroupLabel?.Equals(other.GroupLabel) == true)) &&
                this.Mandatory.Equals(other.Mandatory) &&
                ((this.BeneficiaryIdentityFieldsList == null && other.BeneficiaryIdentityFieldsList == null) || (this.BeneficiaryIdentityFieldsList?.Equals(other.BeneficiaryIdentityFieldsList) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ElementName = {(this.ElementName == null ? "null" : this.ElementName == string.Empty ? "" : this.ElementName)}");
            toStringOutput.Add($"this.GroupLabel = {(this.GroupLabel == null ? "null" : this.GroupLabel == string.Empty ? "" : this.GroupLabel)}");
            toStringOutput.Add($"this.Mandatory = {this.Mandatory}");
            toStringOutput.Add($"this.BeneficiaryIdentityFieldsList = {(this.BeneficiaryIdentityFieldsList == null ? "null" : this.BeneficiaryIdentityFieldsList.ToString())}");
        }
    }
}