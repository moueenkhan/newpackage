// <copyright file="MoneyMovementTypeEnum.cs" company="APIMatic">
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
    /// MoneyMovementTypeEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MoneyMovementTypeEnum
    {
        /// <summary>
        ///Debit type money movement.
        /// Debit.
        /// </summary>
        [EnumMember(Value = "Debit")]
        Debit,

        /// <summary>
        ///Credit type money movement.
        /// Credit.
        /// </summary>
        [EnumMember(Value = "Credit")]
        Credit
    }
}