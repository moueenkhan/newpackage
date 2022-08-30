// <copyright file="Action1Enum.cs" company="APIMatic">
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
    /// Action1Enum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Action1Enum
    {
        /// <summary>
        /// Validate.
        /// </summary>
        [EnumMember(Value = "validate")]
        Validate
    }
}