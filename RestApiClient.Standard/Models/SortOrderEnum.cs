// <copyright file="SortOrderEnum.cs" company="APIMatic">
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
    /// SortOrderEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortOrderEnum
    {
        /// <summary>
        ///Sort result set by chosen field in ASCENDING order.
        /// ASC.
        /// </summary>
        [EnumMember(Value = "ASC")]
        ASC,

        /// <summary>
        ///Sort result set by chosen field in DESCENDING order.
        /// DESC.
        /// </summary>
        [EnumMember(Value = "DESC")]
        DESC
    }
}