// <copyright file="Identity.cs" company="APIMatic">
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
    /// Identity.
    /// </summary>
    public class Identity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Identity"/> class.
        /// </summary>
        public Identity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Identity"/> class.
        /// </summary>
        /// <param name="individualIdentity">individualIdentity.</param>
        /// <param name="legalEntityIdentity">legalEntityIdentity.</param>
        /// <param name="unstructuredIdentity">unstructuredIdentity.</param>
        /// <param name="additionalData">additionalData.</param>
        public Identity(
            Models.IndividualIdentity individualIdentity = null,
            Models.LegalEntityIdentity legalEntityIdentity = null,
            List<Models.UnstructuredIdentity> unstructuredIdentity = null,
            List<Models.AdditionalData> additionalData = null)
        {
            this.IndividualIdentity = individualIdentity;
            this.LegalEntityIdentity = legalEntityIdentity;
            this.UnstructuredIdentity = unstructuredIdentity;
            this.AdditionalData = additionalData;
        }

        /// <summary>
        /// The identity of an individual. The 'name' attribute is mandatory for an individual. You must supply at least identification entry or one birth information entry or one address entry.
        /// </summary>
        [JsonProperty("individualIdentity", NullValueHandling = NullValueHandling.Ignore)]
        public Models.IndividualIdentity IndividualIdentity { get; set; }

        /// <summary>
        /// The identity of a legal entity. The 'legalEntityName' is mandatory. You must supply one of 'legalEntityRegistration' or 'address'.
        /// </summary>
        [JsonProperty("legalEntityIdentity", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LegalEntityIdentity LegalEntityIdentity { get; set; }

        /// <summary>
        /// Represents a set of name value pairs that can be supplied as the Identity information. The keys will be validated on the server side against a list of valid types that are accepted.
        /// </summary>
        [JsonProperty("unstructuredIdentity", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.UnstructuredIdentity> UnstructuredIdentity { get; set; }

        /// <summary>
        /// Represents a set of name value pairs that can be supplied with the Identity information.
        /// </summary>
        [JsonProperty("additionalData", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.AdditionalData> AdditionalData { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Identity : ({string.Join(", ", toStringOutput)})";
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

            return obj is Identity other &&
                ((this.IndividualIdentity == null && other.IndividualIdentity == null) || (this.IndividualIdentity?.Equals(other.IndividualIdentity) == true)) &&
                ((this.LegalEntityIdentity == null && other.LegalEntityIdentity == null) || (this.LegalEntityIdentity?.Equals(other.LegalEntityIdentity) == true)) &&
                ((this.UnstructuredIdentity == null && other.UnstructuredIdentity == null) || (this.UnstructuredIdentity?.Equals(other.UnstructuredIdentity) == true)) &&
                ((this.AdditionalData == null && other.AdditionalData == null) || (this.AdditionalData?.Equals(other.AdditionalData) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IndividualIdentity = {(this.IndividualIdentity == null ? "null" : this.IndividualIdentity.ToString())}");
            toStringOutput.Add($"this.LegalEntityIdentity = {(this.LegalEntityIdentity == null ? "null" : this.LegalEntityIdentity.ToString())}");
            toStringOutput.Add($"this.UnstructuredIdentity = {(this.UnstructuredIdentity == null ? "null" : $"[{string.Join(", ", this.UnstructuredIdentity)} ]")}");
            toStringOutput.Add($"this.AdditionalData = {(this.AdditionalData == null ? "null" : $"[{string.Join(", ", this.AdditionalData)} ]")}");
        }
    }
}