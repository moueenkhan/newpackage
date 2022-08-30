// <copyright file="User.cs" company="APIMatic">
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
    /// User.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="userID">userID.</param>
        /// <param name="accountCurrency">accountCurrency.</param>
        /// <param name="managedMerchantName">managedMerchantName.</param>
        /// <param name="payerIdentity">payerIdentity.</param>
        public User(
            Models.UserIDMerchant userID,
            string accountCurrency,
            string managedMerchantName = null,
            Models.Identity payerIdentity = null)
        {
            this.UserID = userID;
            this.ManagedMerchantName = managedMerchantName;
            this.AccountCurrency = accountCurrency;
            this.PayerIdentity = payerIdentity;
        }

        /// <summary>
        /// This group consists of merchant user identifier only.
        /// </summary>
        [JsonProperty("userID")]
        public Models.UserIDMerchant UserID { get; set; }

        /// <summary>
        /// Refers to the descriptive name used to identify a given merchant. It is unique across VPL merchants.
        /// </summary>
        [JsonProperty("managedMerchantName", NullValueHandling = NullValueHandling.Ignore)]
        public string ManagedMerchantName { get; set; }

        /// <summary>
        /// Valid supported ISO 4217 3-character currency code. This is used to set a default account currency.
        /// </summary>
        [JsonProperty("accountCurrency")]
        public string AccountCurrency { get; set; }

        /// <summary>
        /// Represents the identity of an individual or legal entity. You must specify one of either an individual identity or legal entity identity or unstructured identity.
        /// </summary>
        [JsonProperty("payerIdentity", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Identity PayerIdentity { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"User : ({string.Join(", ", toStringOutput)})";
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

            return obj is User other &&
                ((this.UserID == null && other.UserID == null) || (this.UserID?.Equals(other.UserID) == true)) &&
                ((this.ManagedMerchantName == null && other.ManagedMerchantName == null) || (this.ManagedMerchantName?.Equals(other.ManagedMerchantName) == true)) &&
                ((this.AccountCurrency == null && other.AccountCurrency == null) || (this.AccountCurrency?.Equals(other.AccountCurrency) == true)) &&
                ((this.PayerIdentity == null && other.PayerIdentity == null) || (this.PayerIdentity?.Equals(other.PayerIdentity) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.UserID = {(this.UserID == null ? "null" : this.UserID.ToString())}");
            toStringOutput.Add($"this.ManagedMerchantName = {(this.ManagedMerchantName == null ? "null" : this.ManagedMerchantName == string.Empty ? "" : this.ManagedMerchantName)}");
            toStringOutput.Add($"this.AccountCurrency = {(this.AccountCurrency == null ? "null" : this.AccountCurrency == string.Empty ? "" : this.AccountCurrency)}");
            toStringOutput.Add($"this.PayerIdentity = {(this.PayerIdentity == null ? "null" : this.PayerIdentity.ToString())}");
        }
    }
}