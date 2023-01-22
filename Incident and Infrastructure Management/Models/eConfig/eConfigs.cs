using System.ComponentModel.DataAnnotations;

namespace Incident_and_Infrastructure_Management.Models.eConfig
{

    public enum eAlerts 
    {
        error,
        success,
        warning,
        info
    }


    public enum eType
    {

    }
    public enum eCategory
    {
        [Display(Name = "High Level | Level 5")]
        HighLevel,

        [Display(Name = "Medium Level | Level 3")]
        MediumLevel,

        [Display(Name = "Low Level | Level 1")]
        LowLevel,

        [Display(Name = "Not Sure | Uncertain")]
        NotSure
    }

    public enum eCourse
    {
        Electrician,
        Plumber,
        Welder,
        Bricklayer,
        Painter,
        [Display(Name = "Plasterer & Tiler")]
        Plasterer
    }

    public enum eService
    {
        [Display(Name = "Electrical Related")]
        Electrical,

        [Display(Name = "Plumbing Related")]
        Plumber,

        [Display(Name = "Welding Related")]
        Welding
    }
    public enum eContactType
    {
        [Display(Name = "Cellphone | Call")]
        Cellphone,

        [Display(Name = "Email")]
        Email,

        [Display(Name = "SMS")]
        SMS
    }
    public enum eUrgency
    {
        Critical,
        Major,
        Medium,
        Minor
    }
    public enum eImpact
    {
        Severe,
        Mild,
        Minor,

    }
    public enum eResolveStatus
    {
        [Display(Name = "Resolved | Completed")]
        Resolved,
        Escalated,
        [Display(Name = "In Progress")]
        InProgress,
        Incomplete

    }
    public enum eState
    {
        Good,
        Bad,
        Worse,
        Irreparable

    }

    public enum eSpeciality
    {
        Electrical,
        Plumber,
        Welder

    }

    public enum eAvailability
    {
        Available,
        Unavailable,
        Unsure

    }

    public enum eStatus
    {
        Complete,
        Category2,
        Category3
       
    }

    public enum AddressType
    {
        Postal,
        Residential,
        Both
    }

    public enum eProvince
    {
        Gauteng,
        Mpumalanga,
        Limpopo,
        KZN,
        [Display(Name = "Northern Cape")]
        NorthernCape,
        [Display(Name = "Eastern Cape")]
        EasternCape,
        [Display(Name = "Western Cape")]
        WesternCape,
        [Display(Name = "Free State")]
        FreeState,
        [Display(Name = "North West")]
        NorthWest
    }

    public enum eCountry
    {
        [Display(Name = "South Africa")]
        SouthAfrica,
        Other
    }


}
