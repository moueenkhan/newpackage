// <copyright file="UsersBankID.cs" company="APIMatic">
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
    /// UsersBankID.
    /// </summary>
    public class UsersBankID
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersBankID"/> class.
        /// </summary>
        public UsersBankID()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersBankID"/> class.
        /// </summary>
        /// <param name="userID">userID.</param>
        /// <param name="benBankID">benBankID.</param>
        public UsersBankID(
            Models.UserID userID,
            Models.BenBankID benBankID)
        {
            this.UserID = userID;
            this.BenBankID = benBankID;
        }

        /// <summary>
        /// This group consists of all possible user identifier types. The 'epUserID' field is the VPL generated unique identifier for a User and is the equivalent of a Virtual Account Number (VAN). The 'merchantUserID' is a merchant specified identifier for the User. The 'epUserID', 'merchantUserID' or both 'epUserID' and 'merchantUserID' can be supplied. A mapping will be performed to retrieve the merchant user ID from the supplied EP user ID and vice versa. If both the 'epUserID' and 'merchantUserID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated.
        /// </summary>
        [JsonProperty("userID")]
        public Models.UserID UserID { get; set; }

        /// <summary>
        /// This group consists of all possible beneficiary bank identifier types. The 'epBankID' field is a unique identifier for a beneficiary bank account. The 'merchantBankID' is an optional merchant specified identifier for the beneficiary bank account. The 'epBankID', 'merchantBankID' or both 'epBankID' and 'merchantBankID' can be supplied. A mapping will be performed to retrieve the merchant bank ID from the supplied EP bank ID and vice versa. If both the 'epBankID' and 'merchantBankID' are supplied, a check will be performed to ensure that the two are mapped. If the two provided fields are not mapped, then a validation error code will be returned. At least one of the fields must be populated.
        /// </summary>
        [JsonProperty("benBankID")]
        public Models.BenBankID BenBankID { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UsersBankID : ({string.Join(", ", toStringOutput)})";
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

            return obj is UsersBankID other &&
                ((this.UserID == null && other.UserID == null) || (this.UserID?.Equals(other.UserID) == true)) &&
                ((this.BenBankID == null && other.BenBankID == null) || (this.BenBankID?.Equals(other.BenBankID) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.UserID = {(this.UserID == null ? "null" : this.UserID.ToString())}");
            toStringOutput.Add($"this.BenBankID = {(this.BenBankID == null ? "null" : this.BenBankID.ToString())}");
        }
    }
}