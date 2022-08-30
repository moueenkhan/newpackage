// <copyright file="AccessTokenResponse.cs" company="APIMatic">
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
    /// AccessTokenResponse.
    /// </summary>
    public class AccessTokenResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccessTokenResponse"/> class.
        /// </summary>
        public AccessTokenResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessTokenResponse"/> class.
        /// </summary>
        /// <param name="accessToken">access_token.</param>
        /// <param name="tokenType">token_type.</param>
        /// <param name="issuedAt">issued_at.</param>
        /// <param name="expiresIn">expires_in.</param>
        /// <param name="status">status.</param>
        public AccessTokenResponse(
            string accessToken,
            string tokenType = null,
            string issuedAt = null,
            string expiresIn = null,
            string status = null)
        {
            this.TokenType = tokenType;
            this.IssuedAt = issuedAt;
            this.AccessToken = accessToken;
            this.ExpiresIn = expiresIn;
            this.Status = status;
        }

        /// <summary>
        /// Type of token.
        /// </summary>
        [JsonProperty("token_type", NullValueHandling = NullValueHandling.Ignore)]
        public string TokenType { get; set; }

        /// <summary>
        /// Time the token was issued. This is milliseconds since epoch.
        /// </summary>
        [JsonProperty("issued_at", NullValueHandling = NullValueHandling.Ignore)]
        public string IssuedAt { get; set; }

        /// <summary>
        /// The actual token which needs to be used to authorize each subsequent API request.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// When this token expires in seconds.
        /// </summary>
        [JsonProperty("expires_in", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpiresIn { get; set; }

        /// <summary>
        /// The status of the token.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"AccessTokenResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is AccessTokenResponse other &&
                ((this.TokenType == null && other.TokenType == null) || (this.TokenType?.Equals(other.TokenType) == true)) &&
                ((this.IssuedAt == null && other.IssuedAt == null) || (this.IssuedAt?.Equals(other.IssuedAt) == true)) &&
                ((this.AccessToken == null && other.AccessToken == null) || (this.AccessToken?.Equals(other.AccessToken) == true)) &&
                ((this.ExpiresIn == null && other.ExpiresIn == null) || (this.ExpiresIn?.Equals(other.ExpiresIn) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.TokenType = {(this.TokenType == null ? "null" : this.TokenType == string.Empty ? "" : this.TokenType)}");
            toStringOutput.Add($"this.IssuedAt = {(this.IssuedAt == null ? "null" : this.IssuedAt == string.Empty ? "" : this.IssuedAt)}");
            toStringOutput.Add($"this.AccessToken = {(this.AccessToken == null ? "null" : this.AccessToken == string.Empty ? "" : this.AccessToken)}");
            toStringOutput.Add($"this.ExpiresIn = {(this.ExpiresIn == null ? "null" : this.ExpiresIn == string.Empty ? "" : this.ExpiresIn)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status == string.Empty ? "" : this.Status)}");
        }
    }
}