
namespace GraphQLServer.Models
{
    public class PatientModel
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public bool IsRecordActive { get; set; } // Whether this patient's record is in active use
        public string Gender { get; set; } //( male | female | other | unknown)
        public DateTime BirthDate { get; set; }
        public string Telecom { get; set; }  //  A contact detail for the person
        public bool IsDeceased { get; set; } // Indicates if the individual is deceased or not
        public DateTime DeceasedDateTime { get; set; } // If IsDeceased is true only
        public string Adress { get; set; }
        public string MaritalStatus { get; set; }  // Marital (civil) status of a patient
        public bool IsMultipleBirth { get; set; }  // Whether patient is part of a multiple birth
        public int MultipleBirthCount { get; set; } // Specify multiple birth
        public string Photo { get; set; } //Should be base64 format
        public Contact Contact { get; set; }
        public Communication Communication { get; set; }
        public GeneralPractitioner GeneralPractitioner { get; set; }
        public string ManagingOrganization { get; set; }
    }

    public class Contact
    {
      //"relationship": [ { "CodeableConcept" } ], // The kind of relationship
      //"name": { "HumanName" }, // A name associated with the contact person
      //"telecom": [ { "ContactPoint" } ], // A contact detail for the person
      //"address": { "Address" }, // Address for the contact person
      //"gender": "<code>", // male | female | other | unknown
      //"organization": { "Reference(Organization)" }, // C? Organization that is associated with the contact
      //"period": { "Period" } // The period during which this contact person or organization is valid to be contacted relating to this patient

        public string Name { get; set; }
        public string Relationship { get; set; }

    }

    public class Communication
    {
      //"language": { "CodeableConcept" }, // R!  The language which can be used to communicate with the patient about his or her health
      //"preferred": "<boolean>" // Language preference indicator
    }
    public class GeneralPractitioner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Organization { get; set; }
    }
}
