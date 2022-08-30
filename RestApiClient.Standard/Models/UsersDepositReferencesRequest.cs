// <copyright file="UsersDepositReferencesRequest.cs" company="APIMatic">
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
    /// UsersDepositReferencesRequest.
    /// </summary>
    public class UsersDepositReferencesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersDepositReferencesRequest"/> class.
        /// </summary>
        public UsersDepositReferencesRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersDepositReferencesRequest"/> class.
        /// </summary>
        /// <param name="depositReference">depositReference.</param>
        public UsersDepositReferencesRequest(
            string depositReference)
        {
            this.DepositReference = depositReference;
        }

        /// <summary>
        /// A Merchant User Deposit Reference.
        /// </summary>
        [JsonProperty("depositReference")]
        public string DepositReference { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UsersDepositReferencesRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is UsersDepositReferencesRequest other &&
                ((this.DepositReference == null && other.DepositReference == null) || (this.DepositReference?.Equals(other.DepositReference) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DepositReference = {(this.DepositReference == null ? "null" : this.DepositReference == string.Empty ? "" : this.DepositReference)}");
        }
    }
}