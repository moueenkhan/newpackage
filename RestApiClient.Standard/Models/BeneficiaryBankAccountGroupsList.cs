// <copyright file="BeneficiaryBankAccountGroupsList.cs" company="APIMatic">
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
    /// BeneficiaryBankAccountGroupsList.
    /// </summary>
    public class BeneficiaryBankAccountGroupsList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryBankAccountGroupsList"/> class.
        /// </summary>
        public BeneficiaryBankAccountGroupsList()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryBankAccountGroupsList"/> class.
        /// </summary>
        /// <param name="beneficiaryBankAccountFieldGroup">beneficiaryBankAccountFieldGroup.</param>
        public BeneficiaryBankAccountGroupsList(
            List<Models.BeneficiaryBankAccountGroup> beneficiaryBankAccountFieldGroup)
        {
            this.BeneficiaryBankAccountFieldGroup = beneficiaryBankAccountFieldGroup;
        }

        /// <summary>
        /// List of beneficiary bank account groups.
        /// </summary>
        [JsonProperty("beneficiaryBankAccountFieldGroup")]
        public List<Models.BeneficiaryBankAccountGroup> BeneficiaryBankAccountFieldGroup { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BeneficiaryBankAccountGroupsList : ({string.Join(", ", toStringOutput)})";
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

            return obj is BeneficiaryBankAccountGroupsList other &&
                ((this.BeneficiaryBankAccountFieldGroup == null && other.BeneficiaryBankAccountFieldGroup == null) || (this.BeneficiaryBankAccountFieldGroup?.Equals(other.BeneficiaryBankAccountFieldGroup) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BeneficiaryBankAccountFieldGroup = {(this.BeneficiaryBankAccountFieldGroup == null ? "null" : $"[{string.Join(", ", this.BeneficiaryBankAccountFieldGroup)} ]")}");
        }
    }
}