// <copyright file="QuotesBulkResponse.cs" company="APIMatic">
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
    /// QuotesBulkResponse.
    /// </summary>
    public class QuotesBulkResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuotesBulkResponse"/> class.
        /// </summary>
        public QuotesBulkResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuotesBulkResponse"/> class.
        /// </summary>
        /// <param name="fxTicketID">fxTicketID.</param>
        /// <param name="expiryTimestamp">expiryTimestamp.</param>
        /// <param name="bulkFXDetail">bulkFXDetail.</param>
        public QuotesBulkResponse(
            int? fxTicketID = null,
            string expiryTimestamp = null,
            List<Models.BulkFXDetail> bulkFXDetail = null)
        {
            this.FxTicketID = fxTicketID;
            this.ExpiryTimestamp = expiryTimestamp;
            this.BulkFXDetail = bulkFXDetail;
        }

        /// <summary>
        /// FxTicketID is the unique number within the VPL System representing the list of the FX Quotes presented to the Merchant. This is represented as an FX Ticket ID in Payment Request. Payout Request's specified with the optional FX Ticket Id will be validated against TTL (ExpiryTimestamp). The VPL system will throw a validation error if TTL is expired.
        /// </summary>
        [JsonProperty("fxTicketID", NullValueHandling = NullValueHandling.Ignore)]
        public int? FxTicketID { get; set; }

        /// <summary>
        /// A valid ISO 8601 timestamp, such as YYYY-MM-DDThh:mm:ss.sss±hh:mm. ExpiryTimestamp represents the datetime value till what the specified FxTicketID is valid. This means that all	rates in the ticket will be valid till this datetime.
        /// </summary>
        [JsonProperty("expiryTimestamp", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpiryTimestamp { get; set; }

        /// <summary>
        /// Represents the list of fxRates and their details.
        /// </summary>
        [JsonProperty("bulkFXDetail", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.BulkFXDetail> BulkFXDetail { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"QuotesBulkResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is QuotesBulkResponse other &&
                ((this.FxTicketID == null && other.FxTicketID == null) || (this.FxTicketID?.Equals(other.FxTicketID) == true)) &&
                ((this.ExpiryTimestamp == null && other.ExpiryTimestamp == null) || (this.ExpiryTimestamp?.Equals(other.ExpiryTimestamp) == true)) &&
                ((this.BulkFXDetail == null && other.BulkFXDetail == null) || (this.BulkFXDetail?.Equals(other.BulkFXDetail) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.FxTicketID = {(this.FxTicketID == null ? "null" : this.FxTicketID.ToString())}");
            toStringOutput.Add($"this.ExpiryTimestamp = {(this.ExpiryTimestamp == null ? "null" : this.ExpiryTimestamp == string.Empty ? "" : this.ExpiryTimestamp)}");
            toStringOutput.Add($"this.BulkFXDetail = {(this.BulkFXDetail == null ? "null" : $"[{string.Join(", ", this.BulkFXDetail)} ]")}");
        }
    }
}