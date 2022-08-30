// <copyright file="BeneficiaryBankAccountListItems.cs" company="APIMatic">
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
    /// BeneficiaryBankAccountListItems.
    /// </summary>
    public class BeneficiaryBankAccountListItems
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryBankAccountListItems"/> class.
        /// </summary>
        public BeneficiaryBankAccountListItems()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryBankAccountListItems"/> class.
        /// </summary>
        /// <param name="beneficiaryBankAccountField">beneficiaryBankAccountField.</param>
        public BeneficiaryBankAccountListItems(
            List<Models.BeneficiaryBankAccountListItem> beneficiaryBankAccountField)
        {
            this.BeneficiaryBankAccountField = beneficiaryBankAccountField;
        }

        /// <summary>
        /// List of beneficiary Bank Account Field values
        /// </summary>
        [JsonProperty("beneficiaryBankAccountField")]
        public List<Models.BeneficiaryBankAccountListItem> BeneficiaryBankAccountField { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BeneficiaryBankAccountListItems : ({string.Join(", ", toStringOutput)})";
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

            return obj is BeneficiaryBankAccountListItems other &&
                ((this.BeneficiaryBankAccountField == null && other.BeneficiaryBankAccountField == null) || (this.BeneficiaryBankAccountField?.Equals(other.BeneficiaryBankAccountField) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BeneficiaryBankAccountField = {(this.BeneficiaryBankAccountField == null ? "null" : $"[{string.Join(", ", this.BeneficiaryBankAccountField)} ]")}");
        }
    }
}