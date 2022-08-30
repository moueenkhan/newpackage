// <copyright file="PaymentsCreateRequest.cs" company="APIMatic">
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
    /// PaymentsCreateRequest.
    /// </summary>
    public class PaymentsCreateRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsCreateRequest"/> class.
        /// </summary>
        public PaymentsCreateRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentsCreateRequest"/> class.
        /// </summary>
        /// <param name="user">user.</param>
        /// <param name="bankAccount">bankAccount.</param>
        /// <param name="payment">payment.</param>
        public PaymentsCreateRequest(
            Models.User user,
            Models.BankAccount bankAccount,
            Models.Payment payment)
        {
            this.User = user;
            this.BankAccount = bankAccount;
            this.Payment = payment;
        }

        /// <summary>
        /// A user Object.
        /// </summary>
        [JsonProperty("user")]
        public Models.User User { get; set; }

        /// <summary>
        /// The beneficiary bank account Object. This type provides all the possible information required to identify a beneficiary bank account.
        /// </summary>
        [JsonProperty("bankAccount")]
        public Models.BankAccount BankAccount { get; set; }

        /// <summary>
        /// This request is used to request a payout to a given beneficiary bank account. This message is used by VPL merchants who are requesting payouts on behalf of a customer.
        /// </summary>
        [JsonProperty("payment")]
        public Models.Payment Payment { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PaymentsCreateRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is PaymentsCreateRequest other &&
                ((this.User == null && other.User == null) || (this.User?.Equals(other.User) == true)) &&
                ((this.BankAccount == null && other.BankAccount == null) || (this.BankAccount?.Equals(other.BankAccount) == true)) &&
                ((this.Payment == null && other.Payment == null) || (this.Payment?.Equals(other.Payment) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.User = {(this.User == null ? "null" : this.User.ToString())}");
            toStringOutput.Add($"this.BankAccount = {(this.BankAccount == null ? "null" : this.BankAccount.ToString())}");
            toStringOutput.Add($"this.Payment = {(this.Payment == null ? "null" : this.Payment.ToString())}");
        }
    }
}