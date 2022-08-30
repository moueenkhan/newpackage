// <copyright file="TransactionIDMerchant.cs" company="APIMatic">
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
    /// TransactionIDMerchant.
    /// </summary>
    public class TransactionIDMerchant
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionIDMerchant"/> class.
        /// </summary>
        public TransactionIDMerchant()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionIDMerchant"/> class.
        /// </summary>
        /// <param name="merchantTransactionID">merchantTransactionID.</param>
        public TransactionIDMerchant(
            string merchantTransactionID = null)
        {
            this.MerchantTransactionID = merchantTransactionID;
        }

        /// <summary>
        /// The unique reference of a transaction provided by the merchant. This is unique per Contracting Merchant.
        /// </summary>
        [JsonProperty("merchantTransactionID", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchantTransactionID { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TransactionIDMerchant : ({string.Join(", ", toStringOutput)})";
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

            return obj is TransactionIDMerchant other &&
                ((this.MerchantTransactionID == null && other.MerchantTransactionID == null) || (this.MerchantTransactionID?.Equals(other.MerchantTransactionID) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MerchantTransactionID = {(this.MerchantTransactionID == null ? "null" : this.MerchantTransactionID == string.Empty ? "" : this.MerchantTransactionID)}");
        }
    }
}