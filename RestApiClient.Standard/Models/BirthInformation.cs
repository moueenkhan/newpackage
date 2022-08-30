// <copyright file="BirthInformation.cs" company="APIMatic">
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
    /// BirthInformation.
    /// </summary>
    public class BirthInformation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BirthInformation"/> class.
        /// </summary>
        public BirthInformation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BirthInformation"/> class.
        /// </summary>
        /// <param name="countryOfBirth">countryOfBirth.</param>
        /// <param name="dateOfBirth">dateOfBirth.</param>
        /// <param name="cityOfBirth">cityOfBirth.</param>
        public BirthInformation(
            string countryOfBirth,
            string dateOfBirth,
            string cityOfBirth = null)
        {
            this.CityOfBirth = cityOfBirth;
            this.CountryOfBirth = countryOfBirth;
            this.DateOfBirth = dateOfBirth;
        }

        /// <summary>
        /// This represents the city of birth. The length of this field is limited to 254 bytes. This value will be truncated if it is too long.
        /// </summary>
        [JsonProperty("cityOfBirth", NullValueHandling = NullValueHandling.Ignore)]
        public string CityOfBirth { get; set; }

        /// <summary>
        /// Valid supported ISO 3166 2-character country code. This represents the country of birth.
        /// </summary>
        [JsonProperty("countryOfBirth")]
        public string CountryOfBirth { get; set; }

        /// <summary>
        /// Valid ISO 8601 date format YYYY-MM-DD. This represents the date of birth.
        /// </summary>
        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BirthInformation : ({string.Join(", ", toStringOutput)})";
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

            return obj is BirthInformation other &&
                ((this.CityOfBirth == null && other.CityOfBirth == null) || (this.CityOfBirth?.Equals(other.CityOfBirth) == true)) &&
                ((this.CountryOfBirth == null && other.CountryOfBirth == null) || (this.CountryOfBirth?.Equals(other.CountryOfBirth) == true)) &&
                ((this.DateOfBirth == null && other.DateOfBirth == null) || (this.DateOfBirth?.Equals(other.DateOfBirth) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CityOfBirth = {(this.CityOfBirth == null ? "null" : this.CityOfBirth == string.Empty ? "" : this.CityOfBirth)}");
            toStringOutput.Add($"this.CountryOfBirth = {(this.CountryOfBirth == null ? "null" : this.CountryOfBirth == string.Empty ? "" : this.CountryOfBirth)}");
            toStringOutput.Add($"this.DateOfBirth = {(this.DateOfBirth == null ? "null" : this.DateOfBirth == string.Empty ? "" : this.DateOfBirth)}");
        }
    }
}