// <copyright file="AdditionalFieldsList.cs" company="APIMatic">
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
    /// AdditionalFieldsList.
    /// </summary>
    public class AdditionalFieldsList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionalFieldsList"/> class.
        /// </summary>
        public AdditionalFieldsList()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionalFieldsList"/> class.
        /// </summary>
        /// <param name="additionalFieldWithValidator">additionalFieldWithValidator.</param>
        /// <param name="additionalFieldWithValues">additionalFieldWithValues.</param>
        public AdditionalFieldsList(
            List<Models.AdditionalFieldWithValidator> additionalFieldWithValidator = null,
            List<Models.AdditionalFieldWithValues> additionalFieldWithValues = null)
        {
            this.AdditionalFieldWithValidator = additionalFieldWithValidator;
            this.AdditionalFieldWithValues = additionalFieldWithValues;
        }

        /// <summary>
        /// Indicates an additional key that can be provided in the payoutDetails section of a payout request, along with an indication of whether this additional payout details is mandatory.
        /// </summary>
        [JsonProperty("additionalFieldWithValidator", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.AdditionalFieldWithValidator> AdditionalFieldWithValidator { get; set; }

        /// <summary>
        /// Indicates the additional key that can be provided in the payoutDetails section of a payout request along with an indication of whether this additional payout details entry is mandatory.
        /// </summary>
        [JsonProperty("additionalFieldWithValues", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.AdditionalFieldWithValues> AdditionalFieldWithValues { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AdditionalFieldsList : ({string.Join(", ", toStringOutput)})";
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

            return obj is AdditionalFieldsList other &&
                ((this.AdditionalFieldWithValidator == null && other.AdditionalFieldWithValidator == null) || (this.AdditionalFieldWithValidator?.Equals(other.AdditionalFieldWithValidator) == true)) &&
                ((this.AdditionalFieldWithValues == null && other.AdditionalFieldWithValues == null) || (this.AdditionalFieldWithValues?.Equals(other.AdditionalFieldWithValues) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AdditionalFieldWithValidator = {(this.AdditionalFieldWithValidator == null ? "null" : $"[{string.Join(", ", this.AdditionalFieldWithValidator)} ]")}");
            toStringOutput.Add($"this.AdditionalFieldWithValues = {(this.AdditionalFieldWithValues == null ? "null" : $"[{string.Join(", ", this.AdditionalFieldWithValues)} ]")}");
        }
    }
}