// <copyright file="PayerTypeEnum.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RestApiClient.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using RestApiClient.Standard;
    using RestApiClient.Standard.Utilities;

    /// <summary>
    /// PayerTypeEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PayerTypeEnum
    {
        /// <summary>
        ///Payout is being requested on behalf of the requesting merchant.
        /// AuthenticatedCaller.
        /// </summary>
        [EnumMember(Value = "authenticatedCaller")]
        AuthenticatedCaller,

        /// <summary>
        ///Payout is being requested on behalf of a managed merchant.
        /// ManagedMerchant.
        /// </summary>
        [EnumMember(Value = "managedMerchant")]
        ManagedMerchant,

        /// <summary>
        ///Payout is being requested on behalf of a user.
        /// User.
        /// </summary>
        [EnumMember(Value = "user")]
        User
    }
}