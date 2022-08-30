// <copyright file="IBeneficiaryBankAccountsController.cs" company="APIMatic">
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
    /// IBeneficiaryBankAccountsController.
    /// </summary>
    public interface IBeneficiaryBankAccountsController
    {
        /// <summary>
        /// Validates a new beneficiary bank account against a User.
        /// </summary>
        /// <param name="body">Required parameter: The beneficiary bank account..</param>
        /// <returns>Returns the Models.BeneficiaryBankAccountValidateResponse response from the API call.</returns>
        Models.BeneficiaryBankAccountValidateResponse ValidateBeneficiaryBankAccount(
                Models.BeneficiaryBankAccountValidateRequest body);

        /// <summary>
        /// Validates a new beneficiary bank account against a User.
        /// </summary>
        /// <param name="body">Required parameter: The beneficiary bank account..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BeneficiaryBankAccountValidateResponse response from the API call.</returns>
        Task<Models.BeneficiaryBankAccountValidateResponse> ValidateBeneficiaryBankAccountAsync(
                Models.BeneficiaryBankAccountValidateRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Deactivates a Beneficiary Bank Account. You will not be able to send a payment to a deactivated bank account.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="bankID">Required parameter: Unique ID for the beneficiary bank account. It can be either Visa Payments Limited id or merchant id..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        void DeactivateBeneficiaryBankAccount(
                string userID,
                string bankID,
                Models.IdTypeEnum? idType = null);

        /// <summary>
        /// Deactivates a Beneficiary Bank Account. You will not be able to send a payment to a deactivated bank account.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="bankID">Required parameter: Unique ID for the beneficiary bank account. It can be either Visa Payments Limited id or merchant id..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        Task DeactivateBeneficiaryBankAccountAsync(
                string userID,
                string bankID,
                Models.IdTypeEnum? idType = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a Beneficiary Bank Account.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="bankID">Required parameter: Unique ID for the beneficiary bank account. It can be either Visa Payments Limited id or merchant id..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <returns>Returns the Models.BeneficiaryBankAccountGetResponse response from the API call.</returns>
        Models.BeneficiaryBankAccountGetResponse GetBeneficiaryBankAccount(
                string userID,
                string bankID,
                Models.IdTypeEnum? idType = null);

        /// <summary>
        /// Gets a Beneficiary Bank Account.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="bankID">Required parameter: Unique ID for the beneficiary bank account. It can be either Visa Payments Limited id or merchant id..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BeneficiaryBankAccountGetResponse response from the API call.</returns>
        Task<Models.BeneficiaryBankAccountGetResponse> GetBeneficiaryBankAccountAsync(
                string userID,
                string bankID,
                Models.IdTypeEnum? idType = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Validates a new beneficiary bank account and gets the expected settlement date.
        /// </summary>
        /// <param name="body">Required parameter: The beneficiary bank account..</param>
        /// <returns>Returns the Models.BankAccountExpectedSettlementResponse response from the API call.</returns>
        Models.BankAccountExpectedSettlementResponse GetExpectedSettlementDate(
                Models.BankAccountExpectedSettlementRequest body);

        /// <summary>
        /// Validates a new beneficiary bank account and gets the expected settlement date.
        /// </summary>
        /// <param name="body">Required parameter: The beneficiary bank account..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BankAccountExpectedSettlementResponse response from the API call.</returns>
        Task<Models.BankAccountExpectedSettlementResponse> GetExpectedSettlementDateAsync(
                Models.BankAccountExpectedSettlementRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets all Beneficiary Bank Accounts registered by this User.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <param name="offset">Optional parameter: This is used for pagination of resultsets. 0-based starting offset of the page with respect to the entire resultset..</param>
        /// <param name="pageSize">Optional parameter: This is used for pagination of resultsets. Number of items per page to return. If empty the maximum allowable (25) number of records will be returned..</param>
        /// <returns>Returns the Models.BeneficiaryBankAccountListResponse response from the API call.</returns>
        Models.BeneficiaryBankAccountListResponse ListBankAccounts(
                string userID,
                Models.IdTypeEnum? idType = null,
                int? offset = null,
                int? pageSize = null);

        /// <summary>
        /// Gets all Beneficiary Bank Accounts registered by this User.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <param name="offset">Optional parameter: This is used for pagination of resultsets. 0-based starting offset of the page with respect to the entire resultset..</param>
        /// <param name="pageSize">Optional parameter: This is used for pagination of resultsets. Number of items per page to return. If empty the maximum allowable (25) number of records will be returned..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BeneficiaryBankAccountListResponse response from the API call.</returns>
        Task<Models.BeneficiaryBankAccountListResponse> ListBankAccountsAsync(
                string userID,
                Models.IdTypeEnum? idType = null,
                int? offset = null,
                int? pageSize = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Registers a new beneficiary bank account against this User.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="body">Required parameter: The beneficiary bank account..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <returns>Returns the Models.UsersBankID response from the API call.</returns>
        Models.UsersBankID CreateBeneficiaryBankAccount(
                string userID,
                Models.BeneficiaryBankAccountCreateRequest body,
                Models.IdTypeEnum? idType = null);

        /// <summary>
        /// Registers a new beneficiary bank account against this User.
        /// </summary>
        /// <param name="userID">Required parameter: The payer's unique id. It can be either VAN or merchant id..</param>
        /// <param name="body">Required parameter: The beneficiary bank account..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UsersBankID response from the API call.</returns>
        Task<Models.UsersBankID> CreateBeneficiaryBankAccountAsync(
                string userID,
                Models.BeneficiaryBankAccountCreateRequest body,
                Models.IdTypeEnum? idType = null,
                CancellationToken cancellationToken = default);
    }
}