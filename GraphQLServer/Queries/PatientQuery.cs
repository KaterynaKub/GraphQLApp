using GraphQL.Types;
using GraphQLServer.Repositories;
using GraphQLServer.Types;

namespace GraphQLServer.Queries
{
    public  class PatientQuery : ObjectGraphType
    {
        public PatientQuery(PatientRepository repository)
        {
            Field<ListGraphType<PatientType>>("patients", resolve: context => repository.GetPatients());
        }
    }
}
