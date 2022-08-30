// <copyright file="AdditionalInformationEnum.cs" company="APIMatic">
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
    /// AdditionalInformationEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AdditionalInformationEnum
    {
        /// <summary>
        ///Unique Transaction Id
        /// UniqueTransactionId.
        /// </summary>
        [EnumMember(Value = "UniqueTransactionId")]
        UniqueTransactionId,

        /// <summary>
        ///Instructed Currency
        /// InstructedCurrency.
        /// </summary>
        [EnumMember(Value = "InstructedCurrency")]
        InstructedCurrency,

        /// <summary>
        ///Instructed Amount
        /// InstructedAmount.
        /// </summary>
        [EnumMember(Value = "InstructedAmount")]
        InstructedAmount,

        /// <summary>
        ///Settled Currency
        /// SettledCurrency.
        /// </summary>
        [EnumMember(Value = "SettledCurrency")]
        SettledCurrency,

        /// <summary>
        ///Settled Amount
        /// SettledAmount.
        /// </summary>
        [EnumMember(Value = "SettledAmount")]
        SettledAmount,

        /// <summary>
        ///Settled Date
        /// SettledDate.
        /// </summary>
        [EnumMember(Value = "SettledDate")]
        SettledDate,

        /// <summary>
        ///Debit/Credit Indicator
        /// DebitCreditIndicator.
        /// </summary>
        [EnumMember(Value = "DebitCreditIndicator")]
        DebitCreditIndicator,

        /// <summary>
        ///Transaction Type
        /// TransactionType.
        /// </summary>
        [EnumMember(Value = "TransactionType")]
        TransactionType,

        /// <summary>
        ///Transaction Narrative
        /// TransactionNarrative.
        /// </summary>
        [EnumMember(Value = "TransactionNarrative")]
        TransactionNarrative,

        /// <summary>
        ///Additional Narrative
        /// AdditionalNarrative.
        /// </summary>
        [EnumMember(Value = "AdditionalNarrative")]
        AdditionalNarrative,

        /// <summary>
        ///Originator Bank
        /// OriginatorBank.
        /// </summary>
        [EnumMember(Value = "OriginatorBank")]
        OriginatorBank,

        /// <summary>
        ///Originator Account Number
        /// OriginatorAccountNumber.
        /// </summary>
        [EnumMember(Value = "OriginatorAccountNumber")]
        OriginatorAccountNumber,

        /// <summary>
        ///Originator Name-Address Combined
        /// OriginatorNameAddressCombined.
        /// </summary>
        [EnumMember(Value = "OriginatorNameAddressCombined")]
        OriginatorNameAddressCombined,

        /// <summary>
        ///Originator Account Name
        /// OriginatorAccountName.
        /// </summary>
        [EnumMember(Value = "OriginatorAccountName")]
        OriginatorAccountName,

        /// <summary>
        ///Originator Address
        /// OriginatorAddress.
        /// </summary>
        [EnumMember(Value = "OriginatorAddress")]
        OriginatorAddress,

        /// <summary>
        ///Originator City
        /// OriginatorCity.
        /// </summary>
        [EnumMember(Value = "OriginatorCity")]
        OriginatorCity,

        /// <summary>
        ///Originator Country
        /// OriginatorCountry.
        /// </summary>
        [EnumMember(Value = "OriginatorCountry")]
        OriginatorCountry,

        /// <summary>
        ///Originator Date Of Birth
        /// OriginatorDOB.
        /// </summary>
        [EnumMember(Value = "OriginatorDOB")]
        OriginatorDOB,

        /// <summary>
        ///Originator National Id
        /// OriginatorNationalId.
        /// </summary>
        [EnumMember(Value = "OriginatorNationalId")]
        OriginatorNationalId,

        /// <summary>
        ///Beneficiary Name-Address Combined
        /// BeneficiaryNameAddressCombined.
        /// </summary>
        [EnumMember(Value = "BeneficiaryNameAddressCombined")]
        BeneficiaryNameAddressCombined,

        /// <summary>
        ///Beneficiary Name
        /// BeneficiaryName.
        /// </summary>
        [EnumMember(Value = "BeneficiaryName")]
        BeneficiaryName,

        /// <summary>
        ///Beneficiary Date Of Birth
        /// BeneficiaryDOB.
        /// </summary>
        [EnumMember(Value = "BeneficiaryDOB")]
        BeneficiaryDOB,

        /// <summary>
        ///Beneficiary National Id
        /// BeneficiaryNationalId.
        /// </summary>
        [EnumMember(Value = "BeneficiaryNationalId")]
        BeneficiaryNationalId,

        /// <summary>
        ///Beneficiary Address
        /// BeneficiaryAddress.
        /// </summary>
        [EnumMember(Value = "BeneficiaryAddress")]
        BeneficiaryAddress,

        /// <summary>
        ///Beneficiary City
        /// BeneficiaryCity.
        /// </summary>
        [EnumMember(Value = "BeneficiaryCity")]
        BeneficiaryCity,

        /// <summary>
        ///Beneficiary Country
        /// BeneficiaryCountry.
        /// </summary>
        [EnumMember(Value = "BeneficiaryCountry")]
        BeneficiaryCountry
    }
}