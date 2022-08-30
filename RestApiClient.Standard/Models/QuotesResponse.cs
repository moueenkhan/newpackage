// <copyright file="QuotesResponse.cs" company="APIMatic">
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
    /// QuotesResponse.
    /// </summary>
    public class QuotesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuotesResponse"/> class.
        /// </summary>
        public QuotesResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuotesResponse"/> class.
        /// </summary>
        /// <param name="fxTicketID">fxTicketID.</param>
        /// <param name="fxDetail">fxDetail.</param>
        public QuotesResponse(
            int fxTicketID,
            Models.FXDetail fxDetail)
        {
            this.FxTicketID = fxTicketID;
            this.FxDetail = fxDetail;
        }

        /// <summary>
        /// fxTicketID is the unique number within the VPL System representing the FX Quote presented to the Merchant. This is represented as an FX Ticket ID in Payment Request. Payout Request's specified with the optional FX Ticket Id will be validated against TTL. The VPL system will throw a validation error if TTL is expired.
        /// </summary>
        [JsonProperty("fxTicketID")]
        public int FxTicketID { get; set; }

        /// <summary>
        /// Represents the details of an FX transaction, encapsulating the sellAmount, buyAmount and fxRate into a single type.
        /// </summary>
        [JsonProperty("fxDetail")]
        public Models.FXDetail FxDetail { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"QuotesResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is QuotesResponse other &&
                this.FxTicketID.Equals(other.FxTicketID) &&
                ((this.FxDetail == null && other.FxDetail == null) || (this.FxDetail?.Equals(other.FxDetail) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.FxTicketID = {this.FxTicketID}");
            toStringOutput.Add($"this.FxDetail = {(this.FxDetail == null ? "null" : this.FxDetail.ToString())}");
        }
    }
}