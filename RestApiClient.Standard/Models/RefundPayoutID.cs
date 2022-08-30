// <copyright file="RefundPayoutID.cs" company="APIMatic">
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
    /// RefundPayoutID.
    /// </summary>
    public class RefundPayoutID
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RefundPayoutID"/> class.
        /// </summary>
        public RefundPayoutID()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RefundPayoutID"/> class.
        /// </summary>
        /// <param name="paymentID">paymentID.</param>
        public RefundPayoutID(
            long? paymentID = null)
        {
            this.PaymentID = paymentID;
        }

        /// <summary>
        /// VPL transaction ID for the returned transaction.
        /// </summary>
        [JsonProperty("paymentID", NullValueHandling = NullValueHandling.Ignore)]
        public long? PaymentID { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RefundPayoutID : ({string.Join(", ", toStringOutput)})";
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

            return obj is RefundPayoutID other &&
                ((this.PaymentID == null && other.PaymentID == null) || (this.PaymentID?.Equals(other.PaymentID) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PaymentID = {(this.PaymentID == null ? "null" : this.PaymentID.ToString())}");
        }
    }
}