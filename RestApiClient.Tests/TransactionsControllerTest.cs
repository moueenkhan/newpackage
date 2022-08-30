// <copyright file="TransactionsControllerTest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RestApiClient.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Converters;
    using NUnit.Framework;
    using RestApiClient.Standard;
    using RestApiClient.Standard.Controllers;
    using RestApiClient.Standard.Exceptions;
    using RestApiClient.Standard.Http.Client;
    using RestApiClient.Standard.Http.Response;
    using RestApiClient.Standard.Utilities;
    using RestApiClient.Tests.Helpers;

    /// <summary>
    /// TransactionsControllerTest.
    /// </summary>
    [TestFixture]
    public class TransactionsControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private ITransactionsController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.TransactionsController;
        }

        /// <summary>
        /// Cancels a Transaction (payout instruction) which is in a cancellable state in Visa Payments Limited Payments Service.
        ///
        ///### Payout Status Table
        ///| Payout External Status| Cancellable|  
        ///| ----------|----------- |                            
        ///INSUFFICIENT_MERCHANT_LIQUIDITY|YES|
        ///PENDING_PROCESSING|YES |
        ///IN_PROCESS|NO |
        ///PAYMENT_SENT|NO|
        ///WITH_PARTNER_BANK|NO|
        ///REJECTED_PAYOUT|NO| 
        ///PAYMENT_SENT|NO|
        ///RETURNED_PAYOUT|NO|
        ///
        ///### Responses
        ///1.  **"Pending Cancellation"** Response 
        ///
        ///This is returned when the payout to be cancelled status is "Held in Compliance"
        ///The payout will be set to a pending cancellation status, which will changed to rejected later on. Either by a compliance rejection or by the automatic cancellation rejection. (Example shown in the 'Example Response' section)
        ///
        ///2. **"Cancelled"** : Successful Cancellation Response
        ///
        ///This is returned when the transaction is in a cancellable status.
        /// 
        ///3. **"Validation error"** Response
        ///
        ///There are 2 types of validation error responses:  
        ///
        ///*"Payout not cancellable"* : This is the equivalent to an unsuccessful Cancellation Response and it is returned when the payout was not in a cancellable status ( VPL Error code = 11031) 
        ///
        ///*"Payout not found"*: This occurs when the system can not locate the payment to be cancelled or the transaction Ids not matching original transaction.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestCancelTransaction()
        {
            // Parameters for the API call
            string transactionID = "281474988434819";
            Standard.Models.IdTypeEnum? idType = null;
            string merchantCancellationReqID = "12345";

            // Perform API call
            Standard.Models.TransactionsCancelResponse result = null;
            try
            {
                result = await this.controller.CancelTransactionAsync(transactionID, idType, merchantCancellationReqID);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsJsonObjectProperSubsetOf(
                    "{\"status\":\"PendingCancellation\",\"statusDescription\":\"Cancellation Request received for a transaction that cannot be cancelled immediately. A refund notification will be issued if and when this transaction is successfully cancelled\",\"timestamp\":\"2018-11-24T14:08:52.985+00:00\"}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }

        /// <summary>
        /// Retrieves a single Transaction based on TransactionID..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestTestGetTransaction()
        {
            // Parameters for the API call
            string transactionID = "281474984525097";
            Standard.Models.IdTypeEnum? idType = null;
            string managedMerchantName = null;

            // Perform API call
            Standard.Models.FinancialTransaction result = null;
            try
            {
                result = await this.controller.GetTransactionAsync(transactionID, idType, managedMerchantName);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");

            // Test headers
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");

            Assert.IsTrue(
                    TestHelper.AreHeadersProperSubsetOf (
                    headers,
                    this.HttpCallBackHandler.Response.Headers),
                    "Headers should match");

            // Test whether the captured response is as we expected
            Assert.IsNotNull(result, "Result should exist");
            Assert.IsTrue(
                    TestHelper.IsJsonObjectProperSubsetOf(
                    "{\"transactionID\":{\"epTransactionID\":281474984525097,\"merchantTransactionID\":\"txID_1538474668029\"},\"timestamp\":\"2018-10-02T10:04:29.338+00:00\",\"transactionType\":\"Payout\",\"transactionStatus\":{\"code\":100,\"description\":\"Pending Processing\"},\"amount\":{\"amount\":11,\"currency\":\"GBP\"},\"movementType\":\"Debit\",\"usersBankID\":{\"userID\":{\"epUserID\":3409890146710,\"merchantUserID\":\"userID_1538473974001\"},\"benBankID\":{\"epBankID\":4024363,\"merchantBankID\":\"bankID_1538474577593\"}},\"payoutRequestAmount\":{\"amount\":11,\"currency\":\"GBP\"},\"settlementInstructionAmount\":{\"amount\":11,\"currency\":\"GBP\"},\"beneficiaryStatementNarrative\":\"Free Text Description\",\"payoutDetails\":[{\"Key\":\"K1\",\"Value\":\"V1\"},{\"Key\":\"K2\",\"Value\":\"V2\"}],\"expectedSettlementDate\":\"2018-11-26Z\",\"beneficiaryBankCountry\":\"GB\",\"beneficiaryBankCurrency\":\"GBP\",\"debitValueDate\":\"2018-10-02T10:04:29.338+00:00\",\"payerIdentity\":{\"individualIdentity\":{\"name\":{\"familyName\":\"Smith\",\"givenNames\":\"John\"},\"address\":{\"addressLine1\":\"ABC\",\"addressLine2\":\"ABC\",\"addressLine3\":\"ABC\",\"city\":\"ABC\",\"country\":\"GB\",\"postcode\":\"EC1A 4HY\",\"province\":\"ABC\"},\"birthInformation\":{\"cityOfBirth\":\"ABC\",\"countryOfBirth\":\"GB\",\"dateOfBirth\":\"2001-01-01Z\"},\"identification\":[{\"idType\":\"Passport\",\"identificationCountry\":\"GB\",\"identificationNumber\":\"ABC123\",\"validFromDate\":\"2001-01-01Z\",\"validToDate\":\"2001-01-01Z\"}]},\"additionalData\":[{\"Key\":\"NATIONAL_ID_CARD\",\"Value\":\"TT6789CC\"}]},\"payerCreatedDate\":\"2018-10-02Z\"}",
                    TestHelper.ConvertStreamToString(this.HttpCallBackHandler.Response.RawBody),
                    false,
                    true,
                    false),
                    "Response body should have matching keys");
        }
    }
}