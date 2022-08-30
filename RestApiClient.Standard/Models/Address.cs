// <copyright file="Address.cs" company="APIMatic">
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
    /// Address.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        public Address()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        /// <param name="addressLine1">addressLine1.</param>
        /// <param name="city">city.</param>
        /// <param name="country">country.</param>
        /// <param name="addressLine2">addressLine2.</param>
        /// <param name="addressLine3">addressLine3.</param>
        /// <param name="postcode">postcode.</param>
        /// <param name="province">province.</param>
        public Address(
            string addressLine1,
            string city,
            string country,
            string addressLine2 = null,
            string addressLine3 = null,
            string postcode = null,
            string province = null)
        {
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
            this.AddressLine3 = addressLine3;
            this.City = city;
            this.Country = country;
            this.Postcode = postcode;
            this.Province = province;
        }

        /// <summary>
        /// A line of address information. The length of this field is limited to 254 bytes. This value will be truncated if it is too long.
        /// </summary>
        [JsonProperty("addressLine1")]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// A line of address information. The length of this field is limited to 254 bytes. This value will be truncated if it is too long.
        /// </summary>
        [JsonProperty("addressLine2", NullValueHandling = NullValueHandling.Ignore)]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// A line of address information. The length of this field is limited to 254 bytes. This value will be truncated if it is too long.
        /// </summary>
        [JsonProperty("addressLine3", NullValueHandling = NullValueHandling.Ignore)]
        public string AddressLine3 { get; set; }

        /// <summary>
        /// A line of address information. The length of this field is limited to 254 bytes. This value will be truncated if it is too long.
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// Valid supported ISO 3166 2-character country code.
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// A line of address information. The length of this field is limited to 10 bytes. 10 bytes can hold 10 normal English characters. This value will be truncated if it is too long.
        /// </summary>
        [JsonProperty("postcode", NullValueHandling = NullValueHandling.Ignore)]
        public string Postcode { get; set; }

        /// <summary>
        /// A line of address information. The length of this field is limited to 254 bytes. This value will be truncated if it is too long.
        /// </summary>
        [JsonProperty("province", NullValueHandling = NullValueHandling.Ignore)]
        public string Province { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Address : ({string.Join(", ", toStringOutput)})";
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

            return obj is Address other &&
                ((this.AddressLine1 == null && other.AddressLine1 == null) || (this.AddressLine1?.Equals(other.AddressLine1) == true)) &&
                ((this.AddressLine2 == null && other.AddressLine2 == null) || (this.AddressLine2?.Equals(other.AddressLine2) == true)) &&
                ((this.AddressLine3 == null && other.AddressLine3 == null) || (this.AddressLine3?.Equals(other.AddressLine3) == true)) &&
                ((this.City == null && other.City == null) || (this.City?.Equals(other.City) == true)) &&
                ((this.Country == null && other.Country == null) || (this.Country?.Equals(other.Country) == true)) &&
                ((this.Postcode == null && other.Postcode == null) || (this.Postcode?.Equals(other.Postcode) == true)) &&
                ((this.Province == null && other.Province == null) || (this.Province?.Equals(other.Province) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AddressLine1 = {(this.AddressLine1 == null ? "null" : this.AddressLine1 == string.Empty ? "" : this.AddressLine1)}");
            toStringOutput.Add($"this.AddressLine2 = {(this.AddressLine2 == null ? "null" : this.AddressLine2 == string.Empty ? "" : this.AddressLine2)}");
            toStringOutput.Add($"this.AddressLine3 = {(this.AddressLine3 == null ? "null" : this.AddressLine3 == string.Empty ? "" : this.AddressLine3)}");
            toStringOutput.Add($"this.City = {(this.City == null ? "null" : this.City == string.Empty ? "" : this.City)}");
            toStringOutput.Add($"this.Country = {(this.Country == null ? "null" : this.Country == string.Empty ? "" : this.Country)}");
            toStringOutput.Add($"this.Postcode = {(this.Postcode == null ? "null" : this.Postcode == string.Empty ? "" : this.Postcode)}");
            toStringOutput.Add($"this.Province = {(this.Province == null ? "null" : this.Province == string.Empty ? "" : this.Province)}");
        }
    }
}