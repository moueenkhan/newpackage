// <copyright file="BeneficiaryAdditionalData.cs" company="APIMatic">
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
    /// BeneficiaryAdditionalData.
    /// </summary>
    public class BeneficiaryAdditionalData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryAdditionalData"/> class.
        /// </summary>
        public BeneficiaryAdditionalData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BeneficiaryAdditionalData"/> class.
        /// </summary>
        /// <param name="additionalDataKey">additionalDataKey.</param>
        /// <param name="additionalDataValue">additionalDataValue.</param>
        public BeneficiaryAdditionalData(
            string additionalDataKey,
            string additionalDataValue)
        {
            this.AdditionalDataKey = additionalDataKey;
            this.AdditionalDataValue = additionalDataValue;
        }

        /// <summary>
        /// The length of the additionalDataKey field is currently restricted to 50 bytes.
        /// </summary>
        [JsonProperty("additionalDataKey")]
        public string AdditionalDataKey { get; set; }

        /// <summary>
        /// The length of the additionalDataValue field is currently restricted to 1024.
        /// </summary>
        [JsonProperty("additionalDataValue")]
        public string AdditionalDataValue { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BeneficiaryAdditionalData : ({string.Join(", ", toStringOutput)})";
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

            return obj is BeneficiaryAdditionalData other &&
                ((this.AdditionalDataKey == null && other.AdditionalDataKey == null) || (this.AdditionalDataKey?.Equals(other.AdditionalDataKey) == true)) &&
                ((this.AdditionalDataValue == null && other.AdditionalDataValue == null) || (this.AdditionalDataValue?.Equals(other.AdditionalDataValue) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AdditionalDataKey = {(this.AdditionalDataKey == null ? "null" : this.AdditionalDataKey == string.Empty ? "" : this.AdditionalDataKey)}");
            toStringOutput.Add($"this.AdditionalDataValue = {(this.AdditionalDataValue == null ? "null" : this.AdditionalDataValue == string.Empty ? "" : this.AdditionalDataValue)}");
        }
    }
}