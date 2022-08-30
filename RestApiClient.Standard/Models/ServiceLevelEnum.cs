// <copyright file="ServiceLevelEnum.cs" company="APIMatic">
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
    /// ServiceLevelEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ServiceLevelEnum
    {
        /// <summary>
        ///Standard service level payments.
        /// Standard.
        /// </summary>
        [EnumMember(Value = "standard")]
        Standard,

        /// <summary>
        ///Express service level payments.
        /// Express.
        /// </summary>
        [EnumMember(Value = "express")]
        Express
    }
}