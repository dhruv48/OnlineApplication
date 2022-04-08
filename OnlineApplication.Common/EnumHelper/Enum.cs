using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineApplication.Common.EnumHelper
{


    [JsonConverter(typeof(StringEnumConverter))]
    public enum Status
    {
        IsSuccess = 1,
        IsError = 2

    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Capacity
    {

        INDIVIDUAL = 1,
        COMPANY
    }



    [JsonConverter(typeof(StringEnumConverter))]
    public enum CategoryOptions
    {
        [Display(Name = "Instant Test Technology (Close)")]
        InstantTestTechnologyClose = 1,
        [Display(Name = "Instant Test Product (Close)")]
        InstantTestProductClose,
        [Display(Name = "Instant Test Services (Open)")]
        InstantTestServicesOpen
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum EngagementWithPiolt
    {
        [Display(Name = "Government")]
        Government = 1,
        [Display(Name = "Start up Or Tech Company")]
        StartUpOrTechCompany,
        [Display(Name = "Funding And Grant Agency")]
        FundingAndGrantAgency,
        [Display(Name = "Outereach & Service Provider")]
        OutereachServiceProvider
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TechnicalParameters
    {
        [Display(Name = "Instant Test")]
        InstantTest = 1,
        [Display(Name = "ICMR/US/FDAVCE-IVD")]
        ICMRUSFDAVCEIVD,
        [Display(Name = "Accuracy")]
        Accuracy,
        [Display(Name = "Swab/gargle")]
        SwabGargle,
        [Display(Name = "Point Of Care")]
        PointOfCare,
        [Display(Name = "Portability")]
        Portaility,
        [Display(Name = "Reagent Free")]
        ReagentFree,
        [Display(Name = "Internet Connected")]
        InternetConnected,
        [Display(Name = "AI-Artificially intelligent algorithm")]
        AIArtificaiallyintelligentAlgorithum,
        [Display(Name = "Low cost")]
        LowCost,
        [Display(Name = "Simplicty")]
        Simplicty,
        [Display(Name = "Self tesing")]
        SelfTesting,
        [Display(Name = "Scalability")]
        Scalability,
        [Display(Name = "High Trhroughput")]
        HighThroughput,
        [Display(Name = "Emerging Variants")]
        EmergingVariants,
        [Display(Name = "Data Optimisation")]
        DataOptimisation,
        [Display(Name = "Testing at disembarkation")]
        TestingAtDisembarkation,
        [Display(Name = "Last Mile Testing")]
        LastMileTesting,
        [Display(Name = "Beyond Covid")]
        BeyondCovid,
        [Display(Name = "Data Falsification")]
        DataFalsification,
        [Display(Name = "NABL")]
        NABL
    }

}
