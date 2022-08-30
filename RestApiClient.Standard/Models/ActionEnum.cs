// <copyright file="ActionEnum.cs" company="APIMatic">
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
    /// ActionEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ActionEnum
    {
        /// <summary>
        ///validate a resource(currently used for 'user' resource only)
        /// Validate.
        /// </summary>
        [EnumMember(Value = "validate")]
        Validate
    }
}