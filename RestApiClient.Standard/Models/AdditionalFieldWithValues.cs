// <copyright file="AdditionalFieldWithValues.cs" company="APIMatic">
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
    /// AdditionalFieldWithValues.
    /// </summary>
    public class AdditionalFieldWithValues
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionalFieldWithValues"/> class.
        /// </summary>
        public AdditionalFieldWithValues()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionalFieldWithValues"/> class.
        /// </summary>
        /// <param name="key">key.</param>
        /// <param name="label">label.</param>
        /// <param name="mandatory">mandatory.</param>
        /// <param name="fieldValue">fieldValue.</param>
        public AdditionalFieldWithValues(
            string key,
            string label,
            bool mandatory,
            List<Models.FieldValue> fieldValue)
        {
            this.Key = key;
            this.Label = label;
            this.Mandatory = mandatory;
            this.FieldValue = fieldValue;
        }

        /// <summary>
        /// Key for the 'additionalFieldWithValues' data field.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// Label for the 'additionalFieldWithValues' data field.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// Is the 'additionalFieldWithValues' data field?
        /// </summary>
        [JsonProperty("mandatory")]
        public bool Mandatory { get; set; }

        /// <summary>
        /// Value for the 'additionalFieldWithValues' data field.
        /// </summary>
        [JsonProperty("fieldValue")]
        public List<Models.FieldValue> FieldValue { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AdditionalFieldWithValues : ({string.Join(", ", toStringOutput)})";
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

            return obj is AdditionalFieldWithValues other &&
                ((this.Key == null && other.Key == null) || (this.Key?.Equals(other.Key) == true)) &&
                ((this.Label == null && other.Label == null) || (this.Label?.Equals(other.Label) == true)) &&
                this.Mandatory.Equals(other.Mandatory) &&
                ((this.FieldValue == null && other.FieldValue == null) || (this.FieldValue?.Equals(other.FieldValue) == true));
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
            toStringOutput.Add($"this.FieldValue = {(this.FieldValue == null ? "null" : $"[{string.Join(", ", this.FieldValue)} ]")}");
        }
    }
}