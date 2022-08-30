// <copyright file="BenBankID.cs" company="APIMatic">
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
    /// BenBankID.
    /// </summary>
    public class BenBankID
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BenBankID"/> class.
        /// </summary>
        public BenBankID()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BenBankID"/> class.
        /// </summary>
        /// <param name="epBankID">epBankID.</param>
        /// <param name="merchantBankID">merchantBankID.</param>
        public BenBankID(
            int? epBankID = null,
            string merchantBankID = null)
        {
            this.EpBankID = epBankID;
            this.MerchantBankID = merchantBankID;
        }

        /// <summary>
        /// The unique ID of a beneficiary bank account.
        /// </summary>
        [JsonProperty("epBankID", NullValueHandling = NullValueHandling.Ignore)]
        public int? EpBankID { get; set; }

        /// <summary>
        /// The merchant specified ID for a beneficiary bank account.
        /// </summary>
        [JsonProperty("merchantBankID", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchantBankID { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BenBankID : ({string.Join(", ", toStringOutput)})";
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

            return obj is BenBankID other &&
                ((this.EpBankID == null && other.EpBankID == null) || (this.EpBankID?.Equals(other.EpBankID) == true)) &&
                ((this.MerchantBankID == null && other.MerchantBankID == null) || (this.MerchantBankID?.Equals(other.MerchantBankID) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EpBankID = {(this.EpBankID == null ? "null" : this.EpBankID.ToString())}");
            toStringOutput.Add($"this.MerchantBankID = {(this.MerchantBankID == null ? "null" : this.MerchantBankID == string.Empty ? "" : this.MerchantBankID)}");
        }
    }
}