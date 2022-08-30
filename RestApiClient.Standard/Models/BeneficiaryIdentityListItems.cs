// <copyright file="BeneficiaryIdentityListItems.cs" company="APIMatic">
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
    /// BeneficiaryIdentityListItems.
    /// </summary>
    public class BeneficiaryIdentityListItems
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryIdentityListItems"/> class.
        /// </summary>
        public BeneficiaryIdentityListItems()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryIdentityListItems"/> class.
        /// </summary>
        /// <param name="beneficiaryIdentityField">beneficiaryIdentityField.</param>
        public BeneficiaryIdentityListItems(
            List<Models.BeneficiaryIdentityListItem> beneficiaryIdentityField)
        {
            this.BeneficiaryIdentityField = beneficiaryIdentityField;
        }

        /// <summary>
        /// List of beneficiary identity listItem sub-elements.
        /// </summary>
        [JsonProperty("beneficiaryIdentityField")]
        public List<Models.BeneficiaryIdentityListItem> BeneficiaryIdentityField { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BeneficiaryIdentityListItems : ({string.Join(", ", toStringOutput)})";
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

            return obj is BeneficiaryIdentityListItems other &&
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