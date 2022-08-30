// <copyright file="RequestedFXEnum.cs" company="APIMatic">
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
    /// RequestedFXEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RequestedFXEnum
    {
        /// <summary>
        ///(Fixed to Fixed) is where no FX will be performed as payout and beneficiary currencies are the same.
        /// FF.
        /// </summary>
        [EnumMember(Value = "FF")]
        FF,

        /// <summary>
        ///FV (Fixed to Variable) uses the supplied payout request amount in order to determine the beneficiary amount.
        /// FV.
        /// </summary>
        [EnumMember(Value = "FV")]
        FV,

        /// <summary>
        ///VF (Variable to Fixed) uses the supplied beneficiary amount in order to determine the payout amount.
        /// VF.
        /// </summary>
        [EnumMember(Value = "VF")]
        VF
    }
}