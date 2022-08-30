// <copyright file="UsersController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RestApiClient.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Converters;
    using RestApiClient.Standard;
    using RestApiClient.Standard.Authentication;
    using RestApiClient.Standard.Exceptions;
    using RestApiClient.Standard.Http.Client;
    using RestApiClient.Standard.Http.Request;
    using RestApiClient.Standard.Http.Request.Configuration;
    using RestApiClient.Standard.Http.Response;
    using RestApiClient.Standard.Utilities;

    /// <summary>
    /// UsersController.
    /// </summary>
    internal class UsersController : BaseController, IUsersController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal UsersController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Use this API to validate the payer identity details of the User.
        /// </summary>
        /// <param name="action">Required parameter: This determines that the supplied User should be validated only and not persisted..</param>
        /// <param name="beneficiaryCountryCode">Required parameter: Valid supported ISO 3166 2-character country code for the payer being validated. This is the country, which the payer needs to send a payment to..</param>
        /// <param name="body">Required parameter: The user details to be validated..</param>
        public void ValidateUser(
                Models.Action1Enum action,
                string beneficiaryCountryCode,
                Models.UsersCreateorValidateRequest body)
        {
            Task t = this.ValidateUserAsync(action, beneficiaryCountryCode, body);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Use this API to validate the payer identity details of the User.
        /// </summary>
        /// <param name="action">Required parameter: This determines that the supplied User should be validated only and not persisted..</param>
        /// <param name="beneficiaryCountryCode">Required parameter: Valid supported ISO 3166 2-character country code for the payer being validated. This is the country, which the payer needs to send a payment to..</param>
        /// <param name="body">Required parameter: The user details to be validated..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task ValidateUserAsync(
                Models.Action1Enum action,
                string beneficiaryCountryCode,
                Models.UsersCreateorValidateRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/users");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "action", ApiHelper.JsonSerialize(action).Trim('\"') },
                { "beneficiaryCountryCode", beneficiaryCountryCode },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "Content-Type", "application/json" },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 400)
            {
                throw new ValidationException("The requested operation could not be performed. Input Request is invalid or incorrect.", context);
            }

            if (response.StatusCode == 401)
            {
                throw new ApiException("Unauthorized - Invalid API Key and Token.", context);
            }

            if (response.StatusCode == 403)
            {
                throw new ApiException("Forbidden. Access to requested data is forbidden.", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ApiException("Not Found. Requested resource does not exist.", context);
            }

            if (response.StatusCode == 408)
            {
                throw new ApiException("Timeout. Operation timed out.", context);
            }

            if (response.StatusCode == 413)
            {
                throw new ApiException("Request Entity Too Large. Earthport limits the request payload size to 100KB.", context);
            }

            if (response.StatusCode == 415)
            {
                throw new ApiException("Unsupported media type. This is probably due to submitting incorrect data format. e.g. XML instead of JSON.", context);
            }

            if (response.StatusCode == 429)
            {
                throw new ApiException("Too many requests hit the API too quickly. We recommend an exponential backoff of your requests.", context);
            }

            if (response.StatusCode == 500)
            {
                throw new ApiException("An internal error has occurred in the Earthport payment platform.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }

        /// <summary>
        /// Get a User/Payer. This API only returns the identity details of a User/Payer.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <returns>Returns the Models.UsersGetResponse response from the API call.</returns>
        public Models.UsersGetResponse GetUser(
                string userID,
                Models.IdTypeEnum? idType = null)
        {
            Task<Models.UsersGetResponse> t = this.GetUserAsync(userID, idType);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Get a User/Payer. This API only returns the identity details of a User/Payer.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UsersGetResponse response from the API call.</returns>
        public async Task<Models.UsersGetResponse> GetUserAsync(
                string userID,
                Models.IdTypeEnum? idType = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/users/{userID}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "userID", userID },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "idType", (idType.HasValue) ? ApiHelper.JsonSerialize(idType.Value).Trim('\"') : null },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 400)
            {
                throw new ValidationException("The requested operation could not be performed. Input Request is invalid or incorrect.", context);
            }

            if (response.StatusCode == 401)
            {
                throw new ApiException("Unauthorized - Invalid API Key and Token.", context);
            }

            if (response.StatusCode == 403)
            {
                throw new ApiException("Forbidden. Access to requested data is forbidden.", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ApiException("Not Found. Requested resource does not exist.", context);
            }

            if (response.StatusCode == 408)
            {
                throw new ApiException("Timeout. Operation timed out.", context);
            }

            if (response.StatusCode == 413)
            {
                throw new ApiException("Request Entity Too Large. Earthport limits the request payload size to 100KB.", context);
            }

            if (response.StatusCode == 415)
            {
                throw new ApiException("Unsupported media type. This is probably due to submitting incorrect data format. e.g. XML instead of JSON.", context);
            }

            if (response.StatusCode == 429)
            {
                throw new ApiException("Too many requests hit the API too quickly. We recommend an exponential backoff of your requests.", context);
            }

            if (response.StatusCode == 500)
            {
                throw new ApiException("An internal error has occurred in the Earthport payment platform.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.UsersGetResponse>(response.Body);
        }

        /// <summary>
        /// Disables a User - you cannot register new bank accounts against a disabled User or create payments for a disabled User.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        public void DisableUser(
                string userID,
                Models.IdTypeEnum? idType = null)
        {
            Task t = this.DisableUserAsync(userID, idType);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Disables a User - you cannot register new bank accounts against a disabled User or create payments for a disabled User.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task DisableUserAsync(
                string userID,
                Models.IdTypeEnum? idType = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/users/{userID}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "userID", userID },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "idType", (idType.HasValue) ? ApiHelper.JsonSerialize(idType.Value).Trim('\"') : null },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Delete(queryBuilder.ToString(), headers, null, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 400)
            {
                throw new ValidationException("The requested operation could not be performed. Input Request is invalid or incorrect.", context);
            }

            if (response.StatusCode == 401)
            {
                throw new ApiException("Unauthorized - Invalid API Key and Token.", context);
            }

            if (response.StatusCode == 403)
            {
                throw new ApiException("Forbidden. Access to requested data is forbidden.", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ApiException("Not Found. Requested resource does not exist.", context);
            }

            if (response.StatusCode == 408)
            {
                throw new ApiException("Timeout. Operation timed out.", context);
            }

            if (response.StatusCode == 413)
            {
                throw new ApiException("Request Entity Too Large. Earthport limits the request payload size to 100KB.", context);
            }

            if (response.StatusCode == 415)
            {
                throw new ApiException("Unsupported media type. This is probably due to submitting incorrect data format. e.g. XML instead of JSON.", context);
            }

            if (response.StatusCode == 429)
            {
                throw new ApiException("Too many requests hit the API too quickly. We recommend an exponential backoff of your requests.", context);
            }

            if (response.StatusCode == 500)
            {
                throw new ApiException("An internal error has occurred in the Earthport payment platform.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }

        /// <summary>
        /// Updates a User/Payer. This API only supports updating the identity details of a User/Payer.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="body">Required parameter: The user details to be updated..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        public void UpdateUser(
                string userID,
                Models.UsersUpdateRequest body,
                Models.IdTypeEnum? idType = null)
        {
            Task t = this.UpdateUserAsync(userID, body, idType);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Updates a User/Payer. This API only supports updating the identity details of a User/Payer.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="body">Required parameter: The user details to be updated..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task UpdateUserAsync(
                string userID,
                Models.UsersUpdateRequest body,
                Models.IdTypeEnum? idType = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/users/{userID}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "userID", userID },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "idType", (idType.HasValue) ? ApiHelper.JsonSerialize(idType.Value).Trim('\"') : null },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "Content-Type", "application/json" },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PutBody(queryBuilder.ToString(), headers, bodyText, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            if (response.StatusCode == 400)
            {
                throw new ValidationException("The requested operation could not be performed. Input Request is invalid or incorrect.", context);
            }

            if (response.StatusCode == 401)
            {
                throw new ApiException("Unauthorized - Invalid API Key and Token.", context);
            }

            if (response.StatusCode == 403)
            {
                throw new ApiException("Forbidden. Access to requested data is forbidden.", context);
            }

            if (response.StatusCode == 404)
            {
                throw new ApiException("Not Found. Requested resource does not exist.", context);
            }

            if (response.StatusCode == 408)
            {
                throw new ApiException("Timeout. Operation timed out.", context);
            }

            if (response.StatusCode == 413)
            {
                throw new ApiException("Request Entity Too Large. Earthport limits the request payload size to 100KB.", context);
            }

            if (response.StatusCode == 415)
            {
                throw new ApiException("Unsupported media type. This is probably due to submitting incorrect data format. e.g. XML instead of JSON.", context);
            }

            if (response.StatusCode == 429)
            {
                throw new ApiException("Too many requests hit the API too quickly. We recommend an exponential backoff of your requests.", context);
            }

            if (response.StatusCode == 500)
            {
                throw new ApiException("An internal error has occurred in the VPL payment platform.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }
    }
}