using GraphQL;
using GraphQL.Types;
using GraphQLServer.Repositories;
using GraphQLServer.Types;

namespace GraphQLServer.Mutations
{
    public class CreatePatient : ObjectGraphType
    {
        public CreatePatient(PatientRepository repository) //: base()
        {
            Field<PatientType>("createPatient",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<PatientInputType>> { Name = "patient" }
            ),
            resolve: context =>
            {
                var patient = context.GetArgument<Patient>("patient");
                return repository.Create(patient);
            });
        }


    }
}
