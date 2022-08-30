// <copyright file="IBalancesController.cs" company="APIMatic">
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
    /// IBalancesController.
    /// </summary>
    public interface IBalancesController
    {
        /// <summary>
        /// Retrieves the balance of a merchant account. .
        /// This API can be used to retrieve a set of balances represented by a monetary amount for each currency registered with the merchant's central virtual account. .
        /// You can filter the AccountBalance resource by currency if you require a balance for a specific currency. .
        /// You can also filter the AccountBalance on managedMerchantName. If no managedMerchantName is specified, then the caller will be used to identify which balance to return. If a managedMerchantName is specified, then an authorisation check will occur to ensure that the caller has the right to view the balance information for that managed merchant.
        /// </summary>
        /// <param name="managedMerchantName">Optional parameter: The name of a managed merchant registered on Visa Payments Limited..</param>
        /// <param name="currency">Optional parameter: Valid supported ISO 4217 3-character currency code..</param>
        /// <returns>Returns the List<Models.AccountBalance> response from the API call.</returns>
        List<Models.AccountBalance> GetBalance(
                string managedMerchantName = null,
                string currency = null);

        /// <summary>
        /// Retrieves the balance of a merchant account. .
        /// This API can be used to retrieve a set of balances represented by a monetary amount for each currency registered with the merchant's central virtual account. .
        /// You can filter the AccountBalance resource by currency if you require a balance for a specific currency. .
        /// You can also filter the AccountBalance on managedMerchantName. If no managedMerchantName is specified, then the caller will be used to identify which balance to return. If a managedMerchantName is specified, then an authorisation check will occur to ensure that the caller has the right to view the balance information for that managed merchant.
        /// </summary>
        /// <param name="managedMerchantName">Optional parameter: The name of a managed merchant registered on Visa Payments Limited..</param>
        /// <param name="currency">Optional parameter: Valid supported ISO 4217 3-character currency code..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List<Models.AccountBalance> response from the API call.</returns>
        Task<List<Models.AccountBalance>> GetBalanceAsync(
                string managedMerchantName = null,
                string currency = null,
                CancellationToken cancellationToken = default);
    }
}