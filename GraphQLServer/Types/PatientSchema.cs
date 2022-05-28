using GraphQL.Types;
using GraphQLServer.Mutations;
using GraphQLServer.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLServer.Example
{
    public class PatientSchema : Schema
    {
        public PatientSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<PatientQuery>();
            
            Mutation = serviceProvider.GetRequiredService<CreatePatient>();
        }
    }
}
