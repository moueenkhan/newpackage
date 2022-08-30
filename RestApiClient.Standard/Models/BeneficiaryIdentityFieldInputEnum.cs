// <copyright file="BeneficiaryIdentityFieldInputEnum.cs" company="APIMatic">
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
    /// BeneficiaryIdentityFieldInputEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BeneficiaryIdentityFieldInputEnum
    {
        /// <summary>
        ///Text UI field.
        /// Text.
        /// </summary>
        [EnumMember(Value = "text")]
        Text,

        /// <summary>
        ///Date UI field.
        /// Date.
        /// </summary>
        [EnumMember(Value = "date")]
        Date,

        /// <summary>
        ///Number UI field.
        /// Number.
        /// </summary>
        [EnumMember(Value = "number")]
        Number,

        /// <summary>
        ///List UI field.
        /// List.
        /// </summary>
        [EnumMember(Value = "list")]
        List
    }
}