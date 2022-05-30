using GraphQL;
using GraphQL.Types;
using GraphQLServer.Repositories;
using GraphQLServer.Types;

namespace GraphQLServer.Queries
{
    public  class PatientQuery : ObjectGraphType
    {
        public PatientQuery(PatientRepository repository)
        {
            Field<ListGraphType<PatientModelType>>("patients", resolve: context => repository.GetPatients());
            Field<PatientModelType>("patient",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "patientId"}      
                ),
                resolve: context =>
                {
                    try
                    {
                        return repository.GetPatientById(context.GetArgument<Guid>("patientId"));
                    }
                    catch (KeyNotFoundException exception)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find patient with such id", exception));
                        return null;
                    }
                });
        }
    }
}
