// <copyright file="IUsersController.cs" company="APIMatic">
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
    /// IUsersController.
    /// </summary>
    public interface IUsersController
    {
        /// <summary>
        /// Use this API to validate the payer identity details of the User.
        /// </summary>
        /// <param name="action">Required parameter: This determines that the supplied User should be validated only and not persisted..</param>
        /// <param name="beneficiaryCountryCode">Required parameter: Valid supported ISO 3166 2-character country code for the payer being validated. This is the country, which the payer needs to send a payment to..</param>
        /// <param name="body">Required parameter: The user details to be validated..</param>
        void ValidateUser(
                Models.Action1Enum action,
                string beneficiaryCountryCode,
                Models.UsersCreateorValidateRequest body);

        /// <summary>
        /// Use this API to validate the payer identity details of the User.
        /// </summary>
        /// <param name="action">Required parameter: This determines that the supplied User should be validated only and not persisted..</param>
        /// <param name="beneficiaryCountryCode">Required parameter: Valid supported ISO 3166 2-character country code for the payer being validated. This is the country, which the payer needs to send a payment to..</param>
        /// <param name="body">Required parameter: The user details to be validated..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        Task ValidateUserAsync(
                Models.Action1Enum action,
                string beneficiaryCountryCode,
                Models.UsersCreateorValidateRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a User/Payer. This API only returns the identity details of a User/Payer.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <returns>Returns the Models.UsersGetResponse response from the API call.</returns>
        Models.UsersGetResponse GetUser(
                string userID,
                Models.IdTypeEnum? idType = null);

        /// <summary>
        /// Get a User/Payer. This API only returns the identity details of a User/Payer.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UsersGetResponse response from the API call.</returns>
        Task<Models.UsersGetResponse> GetUserAsync(
                string userID,
                Models.IdTypeEnum? idType = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Disables a User - you cannot register new bank accounts against a disabled User or create payments for a disabled User.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        void DisableUser(
                string userID,
                Models.IdTypeEnum? idType = null);

        /// <summary>
        /// Disables a User - you cannot register new bank accounts against a disabled User or create payments for a disabled User.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        Task DisableUserAsync(
                string userID,
                Models.IdTypeEnum? idType = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a User/Payer. This API only supports updating the identity details of a User/Payer.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="body">Required parameter: The user details to be updated..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        void UpdateUser(
                string userID,
                Models.UsersUpdateRequest body,
                Models.IdTypeEnum? idType = null);

        /// <summary>
        /// Updates a User/Payer. This API only supports updating the identity details of a User/Payer.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="body">Required parameter: The user details to be updated..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        Task UpdateUserAsync(
                string userID,
                Models.UsersUpdateRequest body,
                Models.IdTypeEnum? idType = null,
                CancellationToken cancellationToken = default);
    }
}