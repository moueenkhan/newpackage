// <copyright file="IAuthenticationController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RestApiClient.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using RestApiClient.Standard;
    using RestApiClient.Standard.Http.Client;
    using RestApiClient.Standard.Http.Request;
    using RestApiClient.Standard.Http.Response;
    using RestApiClient.Standard.Utilities;

    /// <summary>
    /// IAuthenticationController.
    /// </summary>
    public interface IAuthenticationController
    {
        /// <summary>
        /// Verify client credentials and returns a bearer token.
        /// </summary>
        /// <param name="grantType">Required parameter: The grant type for OAuth2.0..</param>
        /// <param name="clientId">Required parameter: Client ID..</param>
        /// <param name="clientSecret">Required parameter: Client Secret..</param>
        /// <returns>Returns the Models.AccessTokenResponse response from the API call.</returns>
        Models.AccessTokenResponse GetAccessToken(
                Models.GrantTypeEnum grantType,
                string clientId,
                string clientSecret);

        /// <summary>
        /// Verify client credentials and returns a bearer token.
        /// </summary>
        /// <param name="grantType">Required parameter: The grant type for OAuth2.0..</param>
        /// <param name="clientId">Required parameter: Client ID..</param>
        /// <param name="clientSecret">Required parameter: Client Secret..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.AccessTokenResponse response from the API call.</returns>
        Task<Models.AccessTokenResponse> GetAccessTokenAsync(
                Models.GrantTypeEnum grantType,
                string clientId,
                string clientSecret,
                CancellationToken cancellationToken = default);
    }
}