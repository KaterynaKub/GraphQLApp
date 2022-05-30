using GraphQL.Types;
using GraphQLServer.Models;

namespace GraphQLServer.Types;

class PatientModelType : ObjectGraphType<PatientModel>
{
    public PatientModelType()
    {
        Name = "Patient";
        Description = "Patient Type";
        Field(d => d.Id, false, typeof(GuidGraphType)).Description("Patient Id");
        Field(d => d.Adress, true, typeof(StringGraphType)).Description("Patient Adress");
        Field(d => d.BirthDate, false, typeof(DateTimeGraphType)).Description("Patient BirthDate");
        Field(d => d.DeceasedDateTime, true, typeof(DateTimeGraphType)).Description("Patient DeceasedDateTime");
        Field(d => d.Gender, true, typeof(StringGraphType)).Description("Patient Gender");
        Field(d => d.IsDeceased, false, typeof(BooleanGraphType)).Description("Patient IsDeceased");
        Field(d => d.IsMultipleBirth, false, typeof(BooleanGraphType)).Description("Patient IsMultipleBirth");
        Field(d => d.IsRecordActive, false, typeof(BooleanGraphType)).Description("Patient IsRecordActive");
        Field(d => d.ManagingOrganization, true, typeof(StringGraphType)).Description("Patient ManagingOrganization");
        Field(d => d.MaritalStatus, true, typeof(StringGraphType)).Description("Patient MaritalStatus");
        Field(d => d.MultipleBirthCount, false, typeof(IntGraphType)).Description("Patient MultipleBirthCount");
        Field(d => d.Name, false, typeof(StringGraphType)).Description("Patient Name");
        Field(d => d.Photo, true, typeof(StringGraphType)).Description("Patient Photo");
        Field(d => d.Telecom, true, typeof(StringGraphType)).Description("Patient Telecom");
        Field(d => d.Contact, true, typeof(ContactType)).Description("Patient Contact");
        Field(d => d.Communications, false, typeof(ListGraphType<CommunicationType>)).Description("Patient Communication");
        Field(d => d.GeneralPractitioner, false, typeof(GeneralPractitionerType)).Description("Patient GeneralPractitioner");
    }
}
class ContactType : ObjectGraphType<Contact>
{
    public ContactType()
    {
        Name = "Contact";
        Description = "Contact Type";
        Field(d => d.Address, true, typeof(StringGraphType)).Description("Contact Address");
        Field(d => d.Name, true, typeof(StringGraphType)).Description("Contact Name");
        Field(d => d.Organization, true, typeof(StringGraphType)).Description("Contact Organization");
        Field(d => d.Relationship, true, typeof(StringGraphType)).Description("Contact Relationship");
        Field(d => d.Telecom, true, typeof(StringGraphType)).Description("Contact Telecom");
        Field(d => d.Period, false, typeof(DateRangeType)).Description("Contact Period");
    }
}
class DateRangeType : ObjectGraphType<DateRange>
{
    public DateRangeType()
    {
        Name = "DateRange";
        Description = "DateRange Type";
        Field(d => d.EndDate, true, typeof(DateTimeGraphType)).Description("DateRange EndDate");
        Field(d => d.StartDate, false, typeof(DateTimeGraphType)).Description("DateRange StartDate");
    }
}
class CommunicationType : ObjectGraphType<Communication>
{
    public CommunicationType()
    {
        Name = "Communication";
        Description = "Communication Type";
        Field(d => d.Language, false, typeof(StringGraphType)).Description("Communication Language");
        Field(d => d.Preferred, false, typeof(BooleanGraphType)).Description("Communication Preferred");
    }
}
class GeneralPractitionerType : ObjectGraphType<GeneralPractitioner>
{
    public GeneralPractitionerType()
    {
        Name = "GeneralPractitioner";
        Description = "GeneralPractitioner Type";
        Field(d => d.Name, true, typeof(StringGraphType)).Description("GeneralPractitioner Language");
        Field(d => d.Organization, true, typeof(StringGraphType)).Description("GeneralPractitioner Language");
    }
}
