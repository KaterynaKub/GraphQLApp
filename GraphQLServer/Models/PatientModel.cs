
namespace GraphQLServer.Models;

public class PatientModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsRecordActive { get; set; } // Whether this patient's record is in active use
    public string Gender { get; set; } //( male | female | other | unknown)
    public DateTime BirthDate { get; set; }
    public string Telecom { get; set; }  //  A contact detail for the person
    public bool IsDeceased { get; set; } // Indicates if the individual is deceased or not
    public DateTime? DeceasedDateTime { get; set; } // If IsDeceased is true only
    public string Adress { get; set; }
    public string MaritalStatus { get; set; }  // Marital (civil) status of a patient
    public bool IsMultipleBirth { get; set; }  // Whether patient is part of a multiple birth
    public int MultipleBirthCount { get; set; } // Specify multiple birth
    public string Photo { get; set; } //Should be base64 format
    public Contact Contact { get; set; }
    public ICollection<Communication> Communications { get; set; }
    public GeneralPractitioner GeneralPractitioner { get; set; }
    public string ManagingOrganization { get; set; }
}

public class Contact
{
    public string Name { get; set; }
    public string Relationship { get; set; }
    public string Telecom { get; set; }
    public string Address { get; set; }
    public string Organization { get; set; }
    public DateRange Period { get; set; }

}

public class DateRange
{
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

public class Communication
{
    public string Language { get; set; }
    public bool Preferred { get; set; }
}
public class GeneralPractitioner
{
    public string Name { get; set; }
    public string Organization { get; set; }
}
