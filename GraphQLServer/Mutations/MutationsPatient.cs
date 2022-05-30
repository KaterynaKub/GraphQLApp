using GraphQL;
using GraphQL.Types;
using GraphQLServer.Models;
using GraphQLServer.Repositories;
using GraphQLServer.Types;

namespace GraphQLServer.Mutations
{
    public class MutationsPatient : ObjectGraphType
    {
        public MutationsPatient(PatientRepository repository)
        {
            Field<PatientModelType>("createPatient",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PatientModelInputType>> { Name = "patient" }
                ),
                resolve: context =>
                {
                    var patient = context.GetArgument<PatientModel>("patient");
                    return repository.Create(patient);
                });

            Field<PatientModelType>("updatePatient",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PatientModelInputType>> { Name = "patient" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "patientId" }
                ),
                resolve: context =>
                {
                    var patient = context.GetArgument<PatientModel>("patient");
                    var patientId = context.GetArgument<Guid>("patientId");
                    patient.Id = patientId;
                    try
                    {
                        return repository.Update(patient);
                    }
                    catch (KeyNotFoundException exception)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find patient with such id", exception));
                        return null;
                    }
                }
            );

            Field<StringGraphType>("deletePatient",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "patientId" }
                ),
                resolve: context =>
                {
                    var patientId = context.GetArgument<Guid>("patientId");
                    try
                    {
                        repository.Delete(patientId);
                        return $"The owner with the id: {patientId} has been successfully deleted";
                    }
                    catch (KeyNotFoundException exception)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find patient with such id", exception));
                        return null;
                    }
                }
            );
        }


    }
}
