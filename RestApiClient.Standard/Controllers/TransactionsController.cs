// <copyright file="TransactionsController.cs" company="APIMatic">
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
    /// TransactionsController.
    /// </summary>
    internal class TransactionsController : BaseController, ITransactionsController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionsController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal TransactionsController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Cancels a Transaction (payout instruction) which is in a cancellable state in Visa Payments Limited Payments Service.
        /// ### Payout Status Table.
        /// | Payout External Status| Cancellable|  .
        /// | ----------|----------- |                            .
        /// INSUFFICIENT_MERCHANT_LIQUIDITY|YES|.
        /// PENDING_PROCESSING|YES |.
        /// IN_PROCESS|NO |.
        /// PAYMENT_SENT|NO|.
        /// WITH_PARTNER_BANK|NO|.
        /// REJECTED_PAYOUT|NO| .
        /// PAYMENT_SENT|NO|.
        /// RETURNED_PAYOUT|NO|.
        /// ### Responses.
        /// 1.  **"Pending Cancellation"** Response .
        /// This is returned when the payout to be cancelled status is "Held in Compliance".
        /// The payout will be set to a pending cancellation status, which will changed to rejected later on. Either by a compliance rejection or by the automatic cancellation rejection. (Example shown in the 'Example Response' section).
        /// 2. **"Cancelled"** : Successful Cancellation Response.
        /// This is returned when the transaction is in a cancellable status.
        ///  .
        /// 3. **"Validation error"** Response.
        /// There are 2 types of validation error responses:  .
        /// *"Payout not cancellable"* : This is the equivalent to an unsuccessful Cancellation Response and it is returned when the payout was not in a cancellable status ( VPL Error code = 11031) .
        /// *"Payout not found"*: This occurs when the system can not locate the payment to be cancelled or the transaction Ids not matching original transaction.
        /// </summary>
        /// <param name="transactionID">Required parameter: A unique transaction ID. You can use Visa Payments Limited transaction id or merchant transaction reference..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <param name="merchantCancellationReqID">Optional parameter: The ID provided by the merchant that will uniquely identify this cancellation request..</param>
        /// <returns>Returns the Models.TransactionsCancelResponse response from the API call.</returns>
        public Models.TransactionsCancelResponse CancelTransaction(
                string transactionID,
                Models.IdTypeEnum? idType = null,
                string merchantCancellationReqID = null)
        {
            Task<Models.TransactionsCancelResponse> t = this.CancelTransactionAsync(transactionID, idType, merchantCancellationReqID);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Cancels a Transaction (payout instruction) which is in a cancellable state in Visa Payments Limited Payments Service.
        /// ### Payout Status Table.
        /// | Payout External Status| Cancellable|  .
        /// | ----------|----------- |                            .
        /// INSUFFICIENT_MERCHANT_LIQUIDITY|YES|.
        /// PENDING_PROCESSING|YES |.
        /// IN_PROCESS|NO |.
        /// PAYMENT_SENT|NO|.
        /// WITH_PARTNER_BANK|NO|.
        /// REJECTED_PAYOUT|NO| .
        /// PAYMENT_SENT|NO|.
        /// RETURNED_PAYOUT|NO|.
        /// ### Responses.
        /// 1.  **"Pending Cancellation"** Response .
        /// This is returned when the payout to be cancelled status is "Held in Compliance".
        /// The payout will be set to a pending cancellation status, which will changed to rejected later on. Either by a compliance rejection or by the automatic cancellation rejection. (Example shown in the 'Example Response' section).
        /// 2. **"Cancelled"** : Successful Cancellation Response.
        /// This is returned when the transaction is in a cancellable status.
        ///  .
        /// 3. **"Validation error"** Response.
        /// There are 2 types of validation error responses:  .
        /// *"Payout not cancellable"* : This is the equivalent to an unsuccessful Cancellation Response and it is returned when the payout was not in a cancellable status ( VPL Error code = 11031) .
        /// *"Payout not found"*: This occurs when the system can not locate the payment to be cancelled or the transaction Ids not matching original transaction.
        /// </summary>
        /// <param name="transactionID">Required parameter: A unique transaction ID. You can use Visa Payments Limited transaction id or merchant transaction reference..</param>
        /// <param name="idType">Optional parameter: idType for the path parameters. This allows you to specify either your own UIDs or Visa Payments Limited generated UIDs. The Visa Payments Limited generated UIDs will be used by default..</param>
        /// <param name="merchantCancellationReqID">Optional parameter: The ID provided by the merchant that will uniquely identify this cancellation request..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.TransactionsCancelResponse response from the API call.</returns>
        public async Task<Models.TransactionsCancelResponse> CancelTransactionAsync(
                string transactionID,
                Models.IdTypeEnum? idType = null,
                string merchantCancellationReqID = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/transactions/{transactionID}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "transactionID", transactionID },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "idType", (idType.HasValue) ? ApiHelper.JsonSerialize(idType.Value).Trim('\"') : null },
                { "merchantCancellationReqID", merchantCancellationReqID },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
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
                throw new ApiException("An internal error has occurred in the VPL payment platform.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.TransactionsCancelResponse>(response.Body);
        }

        /// <summary>
        /// Retrieves a single Transaction based on TransactionID.
        /// </summary>
        /// <param name="transactionID">Required parameter: A unique transaction ID. You can use either Visa Payments Limited transaction ID or merchant transaction ID. Note when using the merchant transaction ID you must set the query parameter idType as merchant..</param>
        /// <param name="idType">Optional parameter: This allows you to specify either your own unique identifier (UID) or Visa Payments Limited generated unique identifier (UID). Visa Payments Limited generated UID will be used by default..</param>
        /// <param name="managedMerchantName">Optional parameter: The name of the managed merchant who created or owns the transaction. Do not supply if you either do not have any managed merchants configured or the managed merchant did not create this transaction. If this is not supplied and the managed merchant did create this transaction then you will receive a "Validation failure: Financial Transaction not found" error, even though the transaction does exist..</param>
        /// <returns>Returns the Models.FinancialTransaction response from the API call.</returns>
        public Models.FinancialTransaction GetTransaction(
                string transactionID,
                Models.IdTypeEnum? idType = null,
                string managedMerchantName = null)
        {
            Task<Models.FinancialTransaction> t = this.GetTransactionAsync(transactionID, idType, managedMerchantName);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a single Transaction based on TransactionID.
        /// </summary>
        /// <param name="transactionID">Required parameter: A unique transaction ID. You can use either Visa Payments Limited transaction ID or merchant transaction ID. Note when using the merchant transaction ID you must set the query parameter idType as merchant..</param>
        /// <param name="idType">Optional parameter: This allows you to specify either your own unique identifier (UID) or Visa Payments Limited generated unique identifier (UID). Visa Payments Limited generated UID will be used by default..</param>
        /// <param name="managedMerchantName">Optional parameter: The name of the managed merchant who created or owns the transaction. Do not supply if you either do not have any managed merchants configured or the managed merchant did not create this transaction. If this is not supplied and the managed merchant did create this transaction then you will receive a "Validation failure: Financial Transaction not found" error, even though the transaction does exist..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.FinancialTransaction response from the API call.</returns>
        public async Task<Models.FinancialTransaction> GetTransactionAsync(
                string transactionID,
                Models.IdTypeEnum? idType = null,
                string managedMerchantName = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/transactions/{transactionID}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "transactionID", transactionID },
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "idType", (idType.HasValue) ? ApiHelper.JsonSerialize(idType.Value).Trim('\"') : null },
                { "managedMerchantName", managedMerchantName },
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
                throw new ApiException("An internal error has occurred in the VPL payment platform.", context);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.FinancialTransaction>(response.Body);
        }

        /// <summary>
        /// This allows you to search for payments where you don't know the UID (paymentID) and also allows you to search for other financial transaction types on your account such as refunds, deposits (See Transaction Type). .
        /// This API supports sorting by "Timestamp" or "Amount" in a particular sort order (ASC or DESC) as well as paging across multiple pages of results.
        /// </summary>
        /// <param name="startDateTime">Required parameter: Start Date Time in yyyyy-MM-ddTHH:mm:ssZ. This is in UTC and allows you to search against the acceptedDate of the transaction..</param>
        /// <param name="endDateTime">Required parameter: End Date Time in yyyyy-MM-ddTHH:mm:ssZ. This is in UTC and allows you to search against the acceptedDate of the transaction..</param>
        /// <param name="sortOrder">Required parameter: Sort in either ascending or descending order..</param>
        /// <param name="sortFields">Required parameter: Sort Fields. It can be either Timestamp or Amount or a combination of both. If you want to sort the results based on both the sort fields please provide a comma seperated list of sort fields, i.e. Timestamp,Amount.</param>
        /// <param name="managedMerchantName">Optional parameter: Managed merchant whose transactions will be returned  when being called by the contracting merchant..</param>
        /// <param name="currency">Optional parameter: Transaction currency (valid supported ISO 4217 3-character currency code)..</param>
        /// <param name="amountFrom">Optional parameter: Decimal amount value. The number of decimal places is defined by the currency.This is the lower limit of transaction value (inclusive)..</param>
        /// <param name="amountTo">Optional parameter: Decimal amount value. The number of decimal places is defined by the currency.This is the upper limit of transaction value (inclusive)..</param>
        /// <param name="merchantTransactionID">Optional parameter: Merchant assigned transaction ID (transaction reference)..</param>
        /// <param name="transactionType">Optional parameter: Type of financial transactions. Please provide one of the following transaction types (if none specified all types are searched): Payout, Refund, User Deposit, Merchant Liquidity Deposit, Journal, Merchant Liquidity Movement, Visa Payments Limited Merchant Liquidity Transfer.</param>
        /// <param name="transactionStatusCode">Optional parameter: Status Code of the Transactions..</param>
        /// <param name="offset">Optional parameter: This is used for pagination of resultsets. 0-based starting offset of the page with respect to the entire resultset..</param>
        /// <param name="pageSize">Optional parameter: This is used for pagination of resultsets. Number of items per page to return. If empty the maximum allowable (25) number of records will be returned..</param>
        /// <returns>Returns the Models.TransactionsSearchResponse response from the API call.</returns>
        public Models.TransactionsSearchResponse SearchTransactions(
                string startDateTime,
                string endDateTime,
                Models.SortOrderEnum sortOrder,
                List<string> sortFields,
                string managedMerchantName = null,
                string currency = null,
                double? amountFrom = null,
                double? amountTo = null,
                string merchantTransactionID = null,
                Models.TransactionTypeEnum? transactionType = null,
                int? transactionStatusCode = null,
                int? offset = null,
                int? pageSize = null)
        {
            Task<Models.TransactionsSearchResponse> t = this.SearchTransactionsAsync(startDateTime, endDateTime, sortOrder, sortFields, managedMerchantName, currency, amountFrom, amountTo, merchantTransactionID, transactionType, transactionStatusCode, offset, pageSize);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// This allows you to search for payments where you don't know the UID (paymentID) and also allows you to search for other financial transaction types on your account such as refunds, deposits (See Transaction Type). .
        /// This API supports sorting by "Timestamp" or "Amount" in a particular sort order (ASC or DESC) as well as paging across multiple pages of results.
        /// </summary>
        /// <param name="startDateTime">Required parameter: Start Date Time in yyyyy-MM-ddTHH:mm:ssZ. This is in UTC and allows you to search against the acceptedDate of the transaction..</param>
        /// <param name="endDateTime">Required parameter: End Date Time in yyyyy-MM-ddTHH:mm:ssZ. This is in UTC and allows you to search against the acceptedDate of the transaction..</param>
        /// <param name="sortOrder">Required parameter: Sort in either ascending or descending order..</param>
        /// <param name="sortFields">Required parameter: Sort Fields. It can be either Timestamp or Amount or a combination of both. If you want to sort the results based on both the sort fields please provide a comma seperated list of sort fields, i.e. Timestamp,Amount.</param>
        /// <param name="managedMerchantName">Optional parameter: Managed merchant whose transactions will be returned  when being called by the contracting merchant..</param>
        /// <param name="currency">Optional parameter: Transaction currency (valid supported ISO 4217 3-character currency code)..</param>
        /// <param name="amountFrom">Optional parameter: Decimal amount value. The number of decimal places is defined by the currency.This is the lower limit of transaction value (inclusive)..</param>
        /// <param name="amountTo">Optional parameter: Decimal amount value. The number of decimal places is defined by the currency.This is the upper limit of transaction value (inclusive)..</param>
        /// <param name="merchantTransactionID">Optional parameter: Merchant assigned transaction ID (transaction reference)..</param>
        /// <param name="transactionType">Optional parameter: Type of financial transactions. Please provide one of the following transaction types (if none specified all types are searched): Payout, Refund, User Deposit, Merchant Liquidity Deposit, Journal, Merchant Liquidity Movement, Visa Payments Limited Merchant Liquidity Transfer.</param>
        /// <param name="transactionStatusCode">Optional parameter: Status Code of the Transactions..</param>
        /// <param name="offset">Optional parameter: This is used for pagination of resultsets. 0-based starting offset of the page with respect to the entire resultset..</param>
        /// <param name="pageSize">Optional parameter: This is used for pagination of resultsets. Number of items per page to return. If empty the maximum allowable (25) number of records will be returned..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.TransactionsSearchResponse response from the API call.</returns>
        public async Task<Models.TransactionsSearchResponse> SearchTransactionsAsync(
                string startDateTime,
                string endDateTime,
                Models.SortOrderEnum sortOrder,
                List<string> sortFields,
                string managedMerchantName = null,
                string currency = null,
                double? amountFrom = null,
                double? amountTo = null,
                string merchantTransactionID = null,
                Models.TransactionTypeEnum? transactionType = null,
                int? transactionStatusCode = null,
                int? offset = null,
                int? pageSize = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/transactions");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "startDateTime", startDateTime },
                { "endDateTime", endDateTime },
                { "sortOrder", ApiHelper.JsonSerialize(sortOrder).Trim('\"') },
                { "sortFields", sortFields },
                { "managedMerchantName", managedMerchantName },
                { "currency", currency },
                { "amountFrom", amountFrom },
                { "amountTo", amountTo },
                { "merchantTransactionID", merchantTransactionID },
                { "transactionType", (transactionType.HasValue) ? ApiHelper.JsonSerialize(transactionType.Value).Trim('\"') : null },
                { "transactionStatusCode", transactionStatusCode },
                { "offset", offset },
                { "pageSize", pageSize },
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

            return ApiHelper.JsonDeserialize<Models.TransactionsSearchResponse>(response.Body);
        }
    }
}