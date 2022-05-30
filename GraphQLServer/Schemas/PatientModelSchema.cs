
using GraphQL.Types;
using GraphQLServer.Mutations;
using GraphQLServer.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLServer.Schemas;

class PatientModelSchema : Schema
{
    public PatientModelSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Query = serviceProvider.GetRequiredService<PatientQuery>();

        Mutation = serviceProvider.GetRequiredService<MutationsPatient>();
    }
}