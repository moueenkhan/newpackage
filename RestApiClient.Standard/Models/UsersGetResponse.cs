// <copyright file="UsersGetResponse.cs" company="APIMatic">
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
    /// UsersGetResponse.
    /// </summary>
    public class UsersGetResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersGetResponse"/> class.
        /// </summary>
        public UsersGetResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersGetResponse"/> class.
        /// </summary>
        /// <param name="userID">userID.</param>
        /// <param name="payerIdentity">payerIdentity.</param>
        /// <param name="createdDate">createdDate.</param>
        public UsersGetResponse(
            Models.UserID userID,
            Models.Identity payerIdentity,
            DateTime createdDate)
        {
            this.UserID = userID;
            this.PayerIdentity = payerIdentity;
            this.CreatedDate = createdDate;
        }

        /// <summary>
        /// This group consists of all possible user identifier types. The 'epUserID' field is the VPL generated unique identifier for a User and is the equivalent of a Virtual Account Number (VAN). The 'merchantUserID' is a merchant specified identifier for the User. The 'epUserID', 'merchantUserID' or both 'epUserID' and 'merchantUserID' can be supplied. A mapping will be performed to retrieve the merchant user ID from the supplied EP user ID and vice versa. If both the 'epUserID' and 'merchantUserID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated.
        /// </summary>
        [JsonProperty("userID")]
        public Models.UserID UserID { get; set; }

        /// <summary>
        /// Represents the identity of an individual or legal entity. You must specify one of either an individual identity or legal entity identity or unstructured identity.
        /// </summary>
        [JsonProperty("payerIdentity")]
        public Models.Identity PayerIdentity { get; set; }

        /// <summary>
        /// The Date the User was created.
        /// </summary>
        [JsonConverter(typeof(CustomDateTimeConverter), "yyyy'-'MM'-'dd")]
        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UsersGetResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is UsersGetResponse other &&
                ((this.UserID == null && other.UserID == null) || (this.UserID?.Equals(other.UserID) == true)) &&
                ((this.PayerIdentity == null && other.PayerIdentity == null) || (this.PayerIdentity?.Equals(other.PayerIdentity) == true)) &&
                this.CreatedDate.Equals(other.CreatedDate);
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.UserID = {(this.UserID == null ? "null" : this.UserID.ToString())}");
            toStringOutput.Add($"this.PayerIdentity = {(this.PayerIdentity == null ? "null" : this.PayerIdentity.ToString())}");
            toStringOutput.Add($"this.CreatedDate = {this.CreatedDate}");
        }
    }
}