// <copyright file="IRestApiClientClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RestApiClient.Standard
{
    using System;
    using RestApiClient.Standard.Controllers;

    /// <summary>
    /// IRestApiClientClient.
    /// </summary>
    public interface IRestApiClientClient : IConfiguration
    {
        /// <summary>
        /// Gets instance for IUsersController.
        /// </summary>
        IUsersController UsersController { get; }

        /// <summary>
        /// Gets instance for IPaymentsController.
        /// </summary>
        IPaymentsController PaymentsController { get; }

        /// <summary>
        /// Gets instance for IAuthenticationController.
        /// </summary>
        IAuthenticationController AuthenticationController { get; }

        /// <summary>
        /// Gets instance for IBeneficiaryBankAccountsController.
        /// </summary>
        IBeneficiaryBankAccountsController BeneficiaryBankAccountsController { get; }

        /// <summary>
        /// Gets instance for IQuotesController.
        /// </summary>
        IQuotesController QuotesController { get; }

        /// <summary>
        /// Gets instance for ITransactionsController.
        /// </summary>
        ITransactionsController TransactionsController { get; }

        /// <summary>
        /// Gets instance for ISettlementCalendarsController.
        /// </summary>
        ISettlementCalendarsController SettlementCalendarsController { get; }

        /// <summary>
        /// Gets instance for IBalancesController.
        /// </summary>
        IBalancesController BalancesController { get; }

        /// <summary>
        /// Gets instance for IStatementsController.
        /// </summary>
        IStatementsController StatementsController { get; }
    }
}