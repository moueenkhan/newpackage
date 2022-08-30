// <copyright file="PurposeOfPaymentFieldGroupsList.cs" company="APIMatic">
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
    /// PurposeOfPaymentFieldGroupsList.
    /// </summary>
    public class PurposeOfPaymentFieldGroupsList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PurposeOfPaymentFieldGroupsList"/> class.
        /// </summary>
        public PurposeOfPaymentFieldGroupsList()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PurposeOfPaymentFieldGroupsList"/> class.
        /// </summary>
        /// <param name="mandatory">mandatory.</param>
        /// <param name="purposeOfPaymentCode">purposeOfPaymentCode.</param>
        public PurposeOfPaymentFieldGroupsList(
            bool mandatory,
            List<Models.PurposeOfPaymentCode> purposeOfPaymentCode = null)
        {
            this.Mandatory = mandatory;
            this.PurposeOfPaymentCode = purposeOfPaymentCode;
        }

        /// <summary>
        /// Whether the purpose of payment is mandatory.
        /// </summary>
        [JsonProperty("mandatory")]
        public bool Mandatory { get; set; }

        /// <summary>
        /// List of valid purpose of payment codes.
        /// </summary>
        [JsonProperty("purposeOfPaymentCode", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.PurposeOfPaymentCode> PurposeOfPaymentCode { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PurposeOfPaymentFieldGroupsList : ({string.Join(", ", toStringOutput)})";
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

            return obj is PurposeOfPaymentFieldGroupsList other &&
                this.Mandatory.Equals(other.Mandatory) &&
                ((this.PurposeOfPaymentCode == null && other.PurposeOfPaymentCode == null) || (this.PurposeOfPaymentCode?.Equals(other.PurposeOfPaymentCode) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Mandatory = {this.Mandatory}");
            toStringOutput.Add($"this.PurposeOfPaymentCode = {(this.PurposeOfPaymentCode == null ? "null" : $"[{string.Join(", ", this.PurposeOfPaymentCode)} ]")}");
        }
    }
}