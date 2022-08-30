// <copyright file="BeneficiaryBankAccountGroup.cs" company="APIMatic">
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
    /// BeneficiaryBankAccountGroup.
    /// </summary>
    public class BeneficiaryBankAccountGroup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryBankAccountGroup"/> class.
        /// </summary>
        public BeneficiaryBankAccountGroup()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryBankAccountGroup"/> class.
        /// </summary>
        /// <param name="groupLabel">groupLabel.</param>
        /// <param name="mandatory">mandatory.</param>
        /// <param name="beneficiaryBankAccountFieldsList">beneficiaryBankAccountFieldsList.</param>
        public BeneficiaryBankAccountGroup(
            string groupLabel,
            bool mandatory,
            Models.BeneficiaryBankAccountFieldsList beneficiaryBankAccountFieldsList)
        {
            this.GroupLabel = groupLabel;
            this.Mandatory = mandatory;
            this.BeneficiaryBankAccountFieldsList = beneficiaryBankAccountFieldsList;
        }

        /// <summary>
        /// The UI text to display as a name for this row.
        /// </summary>
        [JsonProperty("groupLabel")]
        public string GroupLabel { get; set; }

        /// <summary>
        /// Indicates whether values must be supplied in the fields of this group.
        /// </summary>
        [JsonProperty("mandatory")]
        public bool Mandatory { get; set; }

        /// <summary>
        /// This type defines a bank account field.
        /// </summary>
        [JsonProperty("beneficiaryBankAccountFieldsList")]
        public Models.BeneficiaryBankAccountFieldsList BeneficiaryBankAccountFieldsList { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BeneficiaryBankAccountGroup : ({string.Join(", ", toStringOutput)})";
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

            return obj is BeneficiaryBankAccountGroup other &&
                ((this.GroupLabel == null && other.GroupLabel == null) || (this.GroupLabel?.Equals(other.GroupLabel) == true)) &&
                this.Mandatory.Equals(other.Mandatory) &&
                ((this.BeneficiaryBankAccountFieldsList == null && other.BeneficiaryBankAccountFieldsList == null) || (this.BeneficiaryBankAccountFieldsList?.Equals(other.BeneficiaryBankAccountFieldsList) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.GroupLabel = {(this.GroupLabel == null ? "null" : this.GroupLabel == string.Empty ? "" : this.GroupLabel)}");
            toStringOutput.Add($"this.Mandatory = {this.Mandatory}");
            toStringOutput.Add($"this.BeneficiaryBankAccountFieldsList = {(this.BeneficiaryBankAccountFieldsList == null ? "null" : this.BeneficiaryBankAccountFieldsList.ToString())}");
        }
    }
}