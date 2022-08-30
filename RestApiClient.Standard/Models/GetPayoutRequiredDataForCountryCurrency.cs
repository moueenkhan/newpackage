// <copyright file="GetPayoutRequiredDataForCountryCurrency.cs" company="APIMatic">
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
    /// GetPayoutRequiredDataForCountryCurrency.
    /// </summary>
    public class GetPayoutRequiredDataForCountryCurrency
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetPayoutRequiredDataForCountryCurrency"/> class.
        /// </summary>
        public GetPayoutRequiredDataForCountryCurrency()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPayoutRequiredDataForCountryCurrency"/> class.
        /// </summary>
        /// <param name="countryCode">countryCode.</param>
        /// <param name="currencyCode">currencyCode.</param>
        /// <param name="beneficiaryIdentityEntity">beneficiaryIdentityEntity.</param>
        /// <param name="locale">locale.</param>
        /// <param name="serviceLevel">serviceLevel.</param>
        public GetPayoutRequiredDataForCountryCurrency(
            string countryCode,
            string currencyCode,
            Models.IdentityEntityEnum? beneficiaryIdentityEntity = null,
            string locale = null,
            Models.ServiceLevelEnum? serviceLevel = null)
        {
            this.BeneficiaryIdentityEntity = beneficiaryIdentityEntity;
            this.CountryCode = countryCode;
            this.CurrencyCode = currencyCode;
            this.Locale = locale;
            this.ServiceLevel = serviceLevel;
        }

        /// <summary>
        /// Supported identity entity types.
        /// </summary>
        [JsonProperty("beneficiaryIdentityEntity", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.IdentityEntityEnum? BeneficiaryIdentityEntity { get; set; }

        /// <summary>
        /// Valid supported ISO 3166 2-character country code.
        /// </summary>
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Valid supported ISO 4217 3-character currency code.
        /// </summary>
        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Supports a comma separated list of locales. for example en_GB, en_US in order of preferred locale.
        /// </summary>
        [JsonProperty("locale", NullValueHandling = NullValueHandling.Ignore)]
        public string Locale { get; set; }

        /// <summary>
        /// Supported service levels for a payout request (standard or express).
        /// </summary>
        [JsonProperty("serviceLevel", ItemConverterType = typeof(StringEnumConverter), NullValueHandling = NullValueHandling.Ignore)]
        public Models.ServiceLevelEnum? ServiceLevel { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"GetPayoutRequiredDataForCountryCurrency : ({string.Join(", ", toStringOutput)})";
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

            return obj is GetPayoutRequiredDataForCountryCurrency other &&
                ((this.BeneficiaryIdentityEntity == null && other.BeneficiaryIdentityEntity == null) || (this.BeneficiaryIdentityEntity?.Equals(other.BeneficiaryIdentityEntity) == true)) &&
                ((this.CountryCode == null && other.CountryCode == null) || (this.CountryCode?.Equals(other.CountryCode) == true)) &&
                ((this.CurrencyCode == null && other.CurrencyCode == null) || (this.CurrencyCode?.Equals(other.CurrencyCode) == true)) &&
                ((this.Locale == null && other.Locale == null) || (this.Locale?.Equals(other.Locale) == true)) &&
                ((this.ServiceLevel == null && other.ServiceLevel == null) || (this.ServiceLevel?.Equals(other.ServiceLevel) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BeneficiaryIdentityEntity = {(this.BeneficiaryIdentityEntity == null ? "null" : this.BeneficiaryIdentityEntity.ToString())}");
            toStringOutput.Add($"this.CountryCode = {(this.CountryCode == null ? "null" : this.CountryCode == string.Empty ? "" : this.CountryCode)}");
            toStringOutput.Add($"this.CurrencyCode = {(this.CurrencyCode == null ? "null" : this.CurrencyCode == string.Empty ? "" : this.CurrencyCode)}");
            toStringOutput.Add($"this.Locale = {(this.Locale == null ? "null" : this.Locale == string.Empty ? "" : this.Locale)}");
            toStringOutput.Add($"this.ServiceLevel = {(this.ServiceLevel == null ? "null" : this.ServiceLevel.ToString())}");
        }
    }
}