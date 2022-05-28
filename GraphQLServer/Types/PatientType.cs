using GraphQL.Types;
using GraphQLServer.Repositories;

namespace GraphQLServer.Types
{
    public class PatientType : ObjectGraphType<Patient>
    {
        public PatientType()
        {
            Name = "Patient";
            Description = "Patient Type";
            Field(d => d.Id, nullable: false, type: typeof(GuidGraphType)).Description("Patient Id");
            Field(d => d.Age, nullable: false, type: typeof(IntGraphType)).Description("Age");
            Field(d => d.FullName, nullable: false, type: typeof(StringGraphType)).Description("Patient`s full name");
            Field(d => d.Analyses, nullable: false, type: typeof(ListGraphType<AnalyseType>)).Description("Analyses");
        }
    }
}
