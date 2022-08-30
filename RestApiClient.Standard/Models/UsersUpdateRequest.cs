// <copyright file="UsersUpdateRequest.cs" company="APIMatic">
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
    /// UsersUpdateRequest.
    /// </summary>
    public class UsersUpdateRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersUpdateRequest"/> class.
        /// </summary>
        public UsersUpdateRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersUpdateRequest"/> class.
        /// </summary>
        /// <param name="payerIdentity">payerIdentity.</param>
        public UsersUpdateRequest(
            Models.Identity payerIdentity)
        {
            this.PayerIdentity = payerIdentity;
        }

        /// <summary>
        /// Represents the identity of an individual or legal entity. You must specify one of either an individual identity or legal entity identity or unstructured identity.
        /// </summary>
        [JsonProperty("payerIdentity")]
        public Models.Identity PayerIdentity { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UsersUpdateRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is UsersUpdateRequest other &&
                ((this.PayerIdentity == null && other.PayerIdentity == null) || (this.PayerIdentity?.Equals(other.PayerIdentity) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PayerIdentity = {(this.PayerIdentity == null ? "null" : this.PayerIdentity.ToString())}");
        }
    }
}