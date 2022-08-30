// <copyright file="Environment.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RestApiClient.Standard
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    /// <summary>
    /// Available environments.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Environment
    {
        /// <summary>
        /// Production server..
        /// </summary>
        [EnumMember(Value = "production")]
        Production,

        /// <summary>
        /// Sandbox is used for both sandbox testing and customer UAT..
        /// </summary>
        [EnumMember(Value = "sandbox")]
        Sandbox,

        /// <summary>
        /// Customer integration is used by existing clients who need to test new functionality before it is released onto sandbox and production..
        /// </summary>
        [EnumMember(Value = "customer integration")]
        CustomerIntegration,
    }
}
