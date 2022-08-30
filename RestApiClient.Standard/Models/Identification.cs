// <copyright file="Identification.cs" company="APIMatic">
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
    /// Identification.
    /// </summary>
    public class Identification
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Identification"/> class.
        /// </summary>
        public Identification()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Identification"/> class.
        /// </summary>
        /// <param name="idType">idType.</param>
        /// <param name="identificationCountry">identificationCountry.</param>
        /// <param name="identificationNumber">identificationNumber.</param>
        /// <param name="validFromDate">validFromDate.</param>
        /// <param name="validToDate">validToDate.</param>
        public Identification(
            string idType,
            string identificationCountry,
            string identificationNumber,
            string validFromDate = null,
            string validToDate = null)
        {
            this.IdType = idType;
            this.IdentificationCountry = identificationCountry;
            this.IdentificationNumber = identificationNumber;
            this.ValidFromDate = validFromDate;
            this.ValidToDate = validToDate;
        }

        /// <summary>
        /// Enumeration of ID Types such as 'Passport', 'Driving License', 'National ID Card'. Please refer to the VPL "API Solution Guide".
        /// </summary>
        [JsonProperty("idType")]
        public string IdType { get; set; }

        /// <summary>
        /// Valid supported ISO 3166 2-character country code. This represents the country of origin of the identification.
        /// </summary>
        [JsonProperty("identificationCountry")]
        public string IdentificationCountry { get; set; }

        /// <summary>
        /// An identification number for an individual. For example, a passport number can be an identification number type. The length of this field is limited to 50 bytes. 50 bytes can hold 50 normal English characters. This value will be truncated if it is too long.
        /// </summary>
        [JsonProperty("identificationNumber")]
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Valid ISO 8601 date format YYYY-MM-DD. This represents the valid-from date of the identification document.
        /// </summary>
        [JsonProperty("validFromDate", NullValueHandling = NullValueHandling.Ignore)]
        public string ValidFromDate { get; set; }

        /// <summary>
        /// Valid ISO 8601 date format YYYY-MM-DD. This represents the valid-to date of the identification document.
        /// </summary>
        [JsonProperty("validToDate", NullValueHandling = NullValueHandling.Ignore)]
        public string ValidToDate { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Identification : ({string.Join(", ", toStringOutput)})";
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

            return obj is Identification other &&
                ((this.IdType == null && other.IdType == null) || (this.IdType?.Equals(other.IdType) == true)) &&
                ((this.IdentificationCountry == null && other.IdentificationCountry == null) || (this.IdentificationCountry?.Equals(other.IdentificationCountry) == true)) &&
                ((this.IdentificationNumber == null && other.IdentificationNumber == null) || (this.IdentificationNumber?.Equals(other.IdentificationNumber) == true)) &&
                ((this.ValidFromDate == null && other.ValidFromDate == null) || (this.ValidFromDate?.Equals(other.ValidFromDate) == true)) &&
                ((this.ValidToDate == null && other.ValidToDate == null) || (this.ValidToDate?.Equals(other.ValidToDate) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdType = {(this.IdType == null ? "null" : this.IdType == string.Empty ? "" : this.IdType)}");
            toStringOutput.Add($"this.IdentificationCountry = {(this.IdentificationCountry == null ? "null" : this.IdentificationCountry == string.Empty ? "" : this.IdentificationCountry)}");
            toStringOutput.Add($"this.IdentificationNumber = {(this.IdentificationNumber == null ? "null" : this.IdentificationNumber == string.Empty ? "" : this.IdentificationNumber)}");
            toStringOutput.Add($"this.ValidFromDate = {(this.ValidFromDate == null ? "null" : this.ValidFromDate == string.Empty ? "" : this.ValidFromDate)}");
            toStringOutput.Add($"this.ValidToDate = {(this.ValidToDate == null ? "null" : this.ValidToDate == string.Empty ? "" : this.ValidToDate)}");
        }
    }
}