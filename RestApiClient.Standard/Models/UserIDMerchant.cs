// <copyright file="UserIDMerchant.cs" company="APIMatic">
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
    /// UserIDMerchant.
    /// </summary>
    public class UserIDMerchant
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserIDMerchant"/> class.
        /// </summary>
        public UserIDMerchant()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserIDMerchant"/> class.
        /// </summary>
        /// <param name="merchantUserID">merchantUserID.</param>
        public UserIDMerchant(
            string merchantUserID)
        {
            this.MerchantUserID = merchantUserID;
        }

        /// <summary>
        /// A unique reference for the merchant that identifies the person or company on behalf of which this account was set up. This needs to be used to reference KYC data held by the merchant (amongst other things). This is often a unique username or reference allocated by the merchant at user registration time.
        /// </summary>
        [JsonProperty("merchantUserID")]
        public string MerchantUserID { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UserIDMerchant : ({string.Join(", ", toStringOutput)})";
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

            return obj is UserIDMerchant other &&
                ((this.MerchantUserID == null && other.MerchantUserID == null) || (this.MerchantUserID?.Equals(other.MerchantUserID) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MerchantUserID = {(this.MerchantUserID == null ? "null" : this.MerchantUserID == string.Empty ? "" : this.MerchantUserID)}");
        }
    }
}