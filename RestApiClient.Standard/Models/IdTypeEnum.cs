// <copyright file="IdTypeEnum.cs" company="APIMatic">
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
    /// IdTypeEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IdTypeEnum
    {
        /// <summary>
        ///{default} Uses VPL generated unique identifier (UID).
        /// Earthport.
        /// </summary>
        [EnumMember(Value = "earthport")]
        Earthport,

        /// <summary>
        ///Uses your own unique identifier (UID), however you must specify you are using your own UID by setting idType to merchant. Example: " /transactions/{transactionID}`?idType=merchant ` "
        /// Merchant.
        /// </summary>
        [EnumMember(Value = "merchant")]
        Merchant
    }
}