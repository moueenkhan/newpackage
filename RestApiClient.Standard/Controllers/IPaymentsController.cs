// <copyright file="IPaymentsController.cs" company="APIMatic">
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
    /// IPaymentsController.
    /// </summary>
    public interface IPaymentsController
    {
        /// <summary>
        /// Returns the required fields for creating the payment request.
        /// </summary>
        /// <param name="countryCode">Required parameter: Valid supported ISO 3166 2-character country code..</param>
        /// <param name="currencyCode">Required parameter: Valid supported ISO 4217 3-character currency code..</param>
        /// <param name="beneficiaryIdentityEntityType">Optional parameter: Type of beneficiary identity..</param>
        /// <param name="locale">Optional parameter: Localization String e.g. en_GB, en_US..</param>
        /// <param name="serviceLevel">Optional parameter: Service Level. Allowed values are standard and express..</param>
        /// <returns>Returns the Models.GetPayoutRequiredDataResponse response from the API call.</returns>
        Models.GetPayoutRequiredDataResponse GetMetadataforPaymentRequest(
                string countryCode,
                string currencyCode,
                Models.IdentityEntityEnum? beneficiaryIdentityEntityType = null,
                string locale = null,
                string serviceLevel = null);

        /// <summary>
        /// Returns the required fields for creating the payment request.
        /// </summary>
        /// <param name="countryCode">Required parameter: Valid supported ISO 3166 2-character country code..</param>
        /// <param name="currencyCode">Required parameter: Valid supported ISO 4217 3-character currency code..</param>
        /// <param name="beneficiaryIdentityEntityType">Optional parameter: Type of beneficiary identity..</param>
        /// <param name="locale">Optional parameter: Localization String e.g. en_GB, en_US..</param>
        /// <param name="serviceLevel">Optional parameter: Service Level. Allowed values are standard and express..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetPayoutRequiredDataResponse response from the API call.</returns>
        Task<Models.GetPayoutRequiredDataResponse> GetMetadataforPaymentRequestAsync(
                string countryCode,
                string currencyCode,
                Models.IdentityEntityEnum? beneficiaryIdentityEntityType = null,
                string locale = null,
                string serviceLevel = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new payment for a previously registered beneficiary bank account (and user).
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="bankID">Required parameter: Unique ID for the beneficiary bank account. It can be either Visa Payments Limited id or merchant id..</param>
        /// <param name="body">Required parameter: Payment details.</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <returns>Returns the Models.PaymentsRegisteredBeneficiaryCreateResponse response from the API call.</returns>
        Models.PaymentsRegisteredBeneficiaryCreateResponse CreatePaymentRegisteredBeneficiary(
                string userID,
                string bankID,
                Models.Payment body,
                Models.IdTypeEnum? idType = null);

        /// <summary>
        /// Creates a new payment for a previously registered beneficiary bank account (and user).
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="bankID">Required parameter: Unique ID for the beneficiary bank account. It can be either Visa Payments Limited id or merchant id..</param>
        /// <param name="body">Required parameter: Payment details.</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.PaymentsRegisteredBeneficiaryCreateResponse response from the API call.</returns>
        Task<Models.PaymentsRegisteredBeneficiaryCreateResponse> CreatePaymentRegisteredBeneficiaryAsync(
                string userID,
                string bankID,
                Models.Payment body,
                Models.IdTypeEnum? idType = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// This service creates a payment without the need to pre-register either the User or Beneficiary Bank Account.
        /// Creates a User (or updates an existing User), adds a Beneficiary Bank Account to this user and creates a new payment.
        /// </summary>
        /// <param name="body">Required parameter: The payment request..</param>
        /// <returns>Returns the Models.PaymentsCreateResponse response from the API call.</returns>
        Models.PaymentsCreateResponse CreatePayment(
                Models.PaymentsCreateRequest body);

        /// <summary>
        /// This service creates a payment without the need to pre-register either the User or Beneficiary Bank Account.
        /// Creates a User (or updates an existing User), adds a Beneficiary Bank Account to this user and creates a new payment.
        /// </summary>
        /// <param name="body">Required parameter: The payment request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.PaymentsCreateResponse response from the API call.</returns>
        Task<Models.PaymentsCreateResponse> CreatePaymentAsync(
                Models.PaymentsCreateRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns Purpose of Payment metadata for a payment to a beneficiary bank account which has previously been registered.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="bankID">Required parameter: Unique ID for the beneficiary bank account. It can be either Visa Payments Limited id or merchant id..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <param name="amount">Optional parameter: Decimal amount value. The number of decimal places is defined by the currency..</param>
        /// <param name="currency">Optional parameter: Valid supported ISO 4217 3-character currency code..</param>
        /// <param name="payerType">Optional parameter: The type of Payer. Allowed values are authenticatedCaller, managedMerchant and user..</param>
        /// <param name="serviceLevel">Optional parameter: Service Level. Allowed values are standard and express..</param>
        /// <returns>Returns the Models.GetPayoutRequiredDataResponse response from the API call.</returns>
        Models.GetPayoutRequiredDataResponse GetPurposeofPaymentMetadata(
                string userID,
                string bankID,
                Models.IdTypeEnum? idType = null,
                int? amount = null,
                string currency = null,
                string payerType = null,
                string serviceLevel = null);

        /// <summary>
        /// Returns Purpose of Payment metadata for a payment to a beneficiary bank account which has previously been registered.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="bankID">Required parameter: Unique ID for the beneficiary bank account. It can be either Visa Payments Limited id or merchant id..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <param name="amount">Optional parameter: Decimal amount value. The number of decimal places is defined by the currency..</param>
        /// <param name="currency">Optional parameter: Valid supported ISO 4217 3-character currency code..</param>
        /// <param name="payerType">Optional parameter: The type of Payer. Allowed values are authenticatedCaller, managedMerchant and user..</param>
        /// <param name="serviceLevel">Optional parameter: Service Level. Allowed values are standard and express..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetPayoutRequiredDataResponse response from the API call.</returns>
        Task<Models.GetPayoutRequiredDataResponse> GetPurposeofPaymentMetadataAsync(
                string userID,
                string bankID,
                Models.IdTypeEnum? idType = null,
                int? amount = null,
                string currency = null,
                string payerType = null,
                string serviceLevel = null,
                CancellationToken cancellationToken = default);
    }
}