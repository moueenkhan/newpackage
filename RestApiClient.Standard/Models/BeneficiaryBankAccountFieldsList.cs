// <copyright file="BeneficiaryBankAccountFieldsList.cs" company="APIMatic">
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
    /// BeneficiaryBankAccountFieldsList.
    /// </summary>
    public class BeneficiaryBankAccountFieldsList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryBankAccountFieldsList"/> class.
        /// </summary>
        public BeneficiaryBankAccountFieldsList()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryBankAccountFieldsList"/> class.
        /// </summary>
        /// <param name="beneficiaryBankAccountField">beneficiaryBankAccountField.</param>
        public BeneficiaryBankAccountFieldsList(
            List<Models.BeneficiaryBankAccountField> beneficiaryBankAccountField = null)
        {
            this.BeneficiaryBankAccountField = beneficiaryBankAccountField;
        }

        /// <summary>
        /// List of beneficiary bank account fields.
        /// </summary>
        [JsonProperty("beneficiaryBankAccountField", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.BeneficiaryBankAccountField> BeneficiaryBankAccountField { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BeneficiaryBankAccountFieldsList : ({string.Join(", ", toStringOutput)})";
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

            return obj is BeneficiaryBankAccountFieldsList other &&
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