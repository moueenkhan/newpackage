// <copyright file="LegalEntityIdentity.cs" company="APIMatic">
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
    /// LegalEntityIdentity.
    /// </summary>
    public class LegalEntityIdentity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LegalEntityIdentity"/> class.
        /// </summary>
        public LegalEntityIdentity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegalEntityIdentity"/> class.
        /// </summary>
        /// <param name="legalEntityName">legalEntityName.</param>
        /// <param name="legalEntityRegistration">legalEntityRegistration.</param>
        /// <param name="address">address.</param>
        public LegalEntityIdentity(
            string legalEntityName,
            Models.LegalEntityRegistration legalEntityRegistration = null,
            Models.Address address = null)
        {
            this.LegalEntityName = legalEntityName;
            this.LegalEntityRegistration = legalEntityRegistration;
            this.Address = address;
        }

        /// <summary>
        /// The name component of the legal entity. The length of this field is limited to 1024 bytes. 1024 bytes can hold 1024 normal English characters.
        /// </summary>
        [JsonProperty("legalEntityName")]
        public string LegalEntityName { get; set; }

        /// <summary>
        /// This group consists of a legal entity registration number type and the country that the legal entity is registered in. Legal Entity Registration Number is mandatory, Legal Entity Registration Country is mandatory and Legal Entity Registration Province is optional.
        /// </summary>
        [JsonProperty("legalEntityRegistration", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LegalEntityRegistration LegalEntityRegistration { get; set; }

        /// <summary>
        /// Represents an address. Mandatory attributes are 'addressLine1', 'city' and 'country'. All other attributes are optional.
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Address Address { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LegalEntityIdentity : ({string.Join(", ", toStringOutput)})";
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

            return obj is LegalEntityIdentity other &&
                ((this.LegalEntityName == null && other.LegalEntityName == null) || (this.LegalEntityName?.Equals(other.LegalEntityName) == true)) &&
                ((this.LegalEntityRegistration == null && other.LegalEntityRegistration == null) || (this.LegalEntityRegistration?.Equals(other.LegalEntityRegistration) == true)) &&
                ((this.Address == null && other.Address == null) || (this.Address?.Equals(other.Address) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LegalEntityName = {(this.LegalEntityName == null ? "null" : this.LegalEntityName == string.Empty ? "" : this.LegalEntityName)}");
            toStringOutput.Add($"this.LegalEntityRegistration = {(this.LegalEntityRegistration == null ? "null" : this.LegalEntityRegistration.ToString())}");
            toStringOutput.Add($"this.Address = {(this.Address == null ? "null" : this.Address.ToString())}");
        }
    }
}