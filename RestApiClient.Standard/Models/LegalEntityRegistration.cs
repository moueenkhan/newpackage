// <copyright file="LegalEntityRegistration.cs" company="APIMatic">
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
    /// LegalEntityRegistration.
    /// </summary>
    public class LegalEntityRegistration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LegalEntityRegistration"/> class.
        /// </summary>
        public LegalEntityRegistration()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegalEntityRegistration"/> class.
        /// </summary>
        /// <param name="legalEntityRegistrationCountry">legalEntityRegistrationCountry.</param>
        /// <param name="legalEntityRegistrationNumber">legalEntityRegistrationNumber.</param>
        /// <param name="legalEntityRegistrationProvince">legalEntityRegistrationProvince.</param>
        public LegalEntityRegistration(
            string legalEntityRegistrationCountry,
            string legalEntityRegistrationNumber,
            string legalEntityRegistrationProvince = null)
        {
            this.LegalEntityRegistrationCountry = legalEntityRegistrationCountry;
            this.LegalEntityRegistrationNumber = legalEntityRegistrationNumber;
            this.LegalEntityRegistrationProvince = legalEntityRegistrationProvince;
        }

        /// <summary>
        /// Valid supported ISO 3166 2-character country code. This represents Registration Country of the Legal Entity.
        /// </summary>
        [JsonProperty("legalEntityRegistrationCountry")]
        public string LegalEntityRegistrationCountry { get; set; }

        /// <summary>
        /// The registration number component of the legal entity. The length of this field is limited to 254 bytes. 254 bytes can hold 254 normal English characters. This value will be truncated if it is too long.
        /// </summary>
        [JsonProperty("legalEntityRegistrationNumber")]
        public string LegalEntityRegistrationNumber { get; set; }

        /// <summary>
        /// Optional province of the legal entity's address.
        /// </summary>
        [JsonProperty("legalEntityRegistrationProvince", NullValueHandling = NullValueHandling.Ignore)]
        public string LegalEntityRegistrationProvince { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LegalEntityRegistration : ({string.Join(", ", toStringOutput)})";
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

            return obj is LegalEntityRegistration other &&
                ((this.LegalEntityRegistrationCountry == null && other.LegalEntityRegistrationCountry == null) || (this.LegalEntityRegistrationCountry?.Equals(other.LegalEntityRegistrationCountry) == true)) &&
                ((this.LegalEntityRegistrationNumber == null && other.LegalEntityRegistrationNumber == null) || (this.LegalEntityRegistrationNumber?.Equals(other.LegalEntityRegistrationNumber) == true)) &&
                ((this.LegalEntityRegistrationProvince == null && other.LegalEntityRegistrationProvince == null) || (this.LegalEntityRegistrationProvince?.Equals(other.LegalEntityRegistrationProvince) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LegalEntityRegistrationCountry = {(this.LegalEntityRegistrationCountry == null ? "null" : this.LegalEntityRegistrationCountry == string.Empty ? "" : this.LegalEntityRegistrationCountry)}");
            toStringOutput.Add($"this.LegalEntityRegistrationNumber = {(this.LegalEntityRegistrationNumber == null ? "null" : this.LegalEntityRegistrationNumber == string.Empty ? "" : this.LegalEntityRegistrationNumber)}");
            toStringOutput.Add($"this.LegalEntityRegistrationProvince = {(this.LegalEntityRegistrationProvince == null ? "null" : this.LegalEntityRegistrationProvince == string.Empty ? "" : this.LegalEntityRegistrationProvince)}");
        }
    }
}