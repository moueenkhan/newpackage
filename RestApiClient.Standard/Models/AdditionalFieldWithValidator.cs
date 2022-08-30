// <copyright file="AdditionalFieldWithValidator.cs" company="APIMatic">
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
    /// AdditionalFieldWithValidator.
    /// </summary>
    public class AdditionalFieldWithValidator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionalFieldWithValidator"/> class.
        /// </summary>
        public AdditionalFieldWithValidator()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionalFieldWithValidator"/> class.
        /// </summary>
        /// <param name="key">key.</param>
        /// <param name="label">label.</param>
        /// <param name="mandatory">mandatory.</param>
        /// <param name="validation">validation.</param>
        public AdditionalFieldWithValidator(
            string key,
            string label,
            bool mandatory,
            string validation)
        {
            this.Key = key;
            this.Label = label;
            this.Mandatory = mandatory;
            this.Validation = validation;
        }

        /// <summary>
        /// Key for list option.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Label for list option.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// Indicates whether this additional payout details is mandatory.
        /// </summary>
        [JsonProperty("mandatory")]
        public bool Mandatory { get; set; }

        /// <summary>
        /// The validation expression that will be applied to the value. This is a regular expression, and may be blank if no validation will be applied.
        /// </summary>
        [JsonProperty("validation")]
        public string Validation { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AdditionalFieldWithValidator : ({string.Join(", ", toStringOutput)})";
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

            return obj is AdditionalFieldWithValidator other &&
                ((this.Key == null && other.Key == null) || (this.Key?.Equals(other.Key) == true)) &&
                ((this.Label == null && other.Label == null) || (this.Label?.Equals(other.Label) == true)) &&
                this.Mandatory.Equals(other.Mandatory) &&
                ((this.Validation == null && other.Validation == null) || (this.Validation?.Equals(other.Validation) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Key = {(this.Key == null ? "null" : this.Key == string.Empty ? "" : this.Key)}");
            toStringOutput.Add($"this.Label = {(this.Label == null ? "null" : this.Label == string.Empty ? "" : this.Label)}");
            toStringOutput.Add($"this.Mandatory = {this.Mandatory}");
            toStringOutput.Add($"this.Validation = {(this.Validation == null ? "null" : this.Validation == string.Empty ? "" : this.Validation)}");
        }
    }
}