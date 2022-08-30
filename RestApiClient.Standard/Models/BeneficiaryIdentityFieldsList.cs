// <copyright file="BeneficiaryIdentityFieldsList.cs" company="APIMatic">
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
    /// BeneficiaryIdentityFieldsList.
    /// </summary>
    public class BeneficiaryIdentityFieldsList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryIdentityFieldsList"/> class.
        /// </summary>
        public BeneficiaryIdentityFieldsList()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryIdentityFieldsList"/> class.
        /// </summary>
        /// <param name="beneficiaryIdentityField">beneficiaryIdentityField.</param>
        public BeneficiaryIdentityFieldsList(
            List<Models.BeneficiaryIdentityField> beneficiaryIdentityField = null)
        {
            this.BeneficiaryIdentityField = beneficiaryIdentityField;
        }

        /// <summary>
        /// List of beneficiary identity fields.
        /// </summary>
        [JsonProperty("beneficiaryIdentityField", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.BeneficiaryIdentityField> BeneficiaryIdentityField { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BeneficiaryIdentityFieldsList : ({string.Join(", ", toStringOutput)})";
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

            return obj is BeneficiaryIdentityFieldsList other &&
                ((this.BeneficiaryIdentityField == null && other.BeneficiaryIdentityField == null) || (this.BeneficiaryIdentityField?.Equals(other.BeneficiaryIdentityField) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BeneficiaryIdentityField = {(this.BeneficiaryIdentityField == null ? "null" : $"[{string.Join(", ", this.BeneficiaryIdentityField)} ]")}");
        }
    }
}