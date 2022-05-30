using GraphQL;
using GraphQL.Types;
using GraphQLServer.Models;
using GraphQLServer.Repositories;
using GraphQLServer.Types;
using System.Reflection;

namespace GraphQLServer.Queries
{
    public  class PatientQuery : ObjectGraphType
    {
        public PatientQuery(PatientRepository repository)
        {
            Field<ListGraphType<PatientModelType>>("patients",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "take" },
                    new QueryArgument<IntGraphType> { Name = "skip" },
                    new QueryArgument<SortInputType> { Name = "sort"}
                ),
                resolve: context =>
                {
                    IEnumerable<PatientModel> patients = repository.GetPatients();
                    if (context.HasArgument("sort"))
                    {
                        var sort = context.GetArgument<Sort>("sort");
                        var prop = typeof(PatientModel).GetProperty(sort.Field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                        if (prop is not null)
                        {
                            var exp = (PatientModel x) => prop.GetValue(x);
                            if (sort.Order.ToLower() == "decs")
                            {
                                patients = patients.OrderByDescending(exp);
                            }
                            else if (sort.Order.ToLower() == "acs")
                            {
                                patients = patients.OrderBy(exp);
                            }
                        }

                    }
                    if (context.HasArgument("skip"))
                    {
                        patients = patients.Skip(context.GetArgument<int>("skip"));
                    }
                    if (context.HasArgument("take"))
                    {
                        patients = patients.Take(context.GetArgument<int>("take"));
                    }
                    return patients.ToList();
                });
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
