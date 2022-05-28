using GraphQL.Types;
using GraphQLServer.Repositories;

namespace GraphQLServer.Types
{
    public class PatientInputType : InputObjectGraphType<Patient>
    {
        public PatientInputType()
        {
            Name = "PatientInput";
            Description = "Patient Input Type";
            Field(d => d.Age, nullable: false, type: typeof(IntGraphType)).Description("Age");
            Field(d => d.FullName, nullable: false, type: typeof(StringGraphType)).Description("Patient`s  full name");
            Field(d => d.Analyses, nullable: false, type: typeof(ListGraphType<AnalyseInputType>)).Description("Analyses");
        }
    }
}
