// <copyright file="BeneficiaryBankAccountValidateResponse.cs" company="APIMatic">
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
    /// BeneficiaryBankAccountValidateResponse.
    /// </summary>
    public class BeneficiaryBankAccountValidateResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryBankAccountValidateResponse"/> class.
        /// </summary>
        public BeneficiaryBankAccountValidateResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryBankAccountValidateResponse"/> class.
        /// </summary>
        /// <param name="isBankAccountValid">isBankAccountValid.</param>
        public BeneficiaryBankAccountValidateResponse(
            bool isBankAccountValid)
        {
            this.IsBankAccountValid = isBankAccountValid;
        }

        /// <summary>
        /// This is a boolean field that represents if the specified beneficiary bank account is valid.
        /// </summary>
        [JsonProperty("isBankAccountValid")]
        public bool IsBankAccountValid { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BeneficiaryBankAccountValidateResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is BeneficiaryBankAccountValidateResponse other &&
                this.IsBankAccountValid.Equals(other.IsBankAccountValid);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IsBankAccountValid = {this.IsBankAccountValid}");
        }
    }
}